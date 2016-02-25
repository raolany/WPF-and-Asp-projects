using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MainWebApplication.Models.Entity;

namespace MainWebApplication.Models.Authentication
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private const string AuthCookieName = "AuthCookie";

        private TCSystemModel _accountRepository;

        public FormsAuthenticationService(TCSystemModel accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public void Login(User user, bool rememberMe)
        {
            DateTime expiresDate = DateTime.Now.AddMinutes(30);
            if (rememberMe)
                expiresDate = expiresDate.AddDays(10);


            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.Id.ToString(),
                DateTime.Now,
                expiresDate, rememberMe, user.Id.ToString());

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            SetValue(AuthCookieName, encryptedTicket, expiresDate);
            
            _currentUser = user;
        }

        public void Logoff()
        {
            SetValue(AuthCookieName, null, DateTime.Now.AddYears(-1));
            _currentUser = null;
        }

        /// <summary>
        /// Generate password
        /// </summary>
        /// <param name="pass">Original password</param>
        /// <param name="salt">User ID + " " + User.ID</param>
        /// <returns></returns>
        public string GeneratePassword(string pass, string salt)
        {
            //return OxoCrypt.MD5(pass + OxoCrypt.MD5(pass + salt + " " + salt));
            return "";
        }

        private User _currentUser;
        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        object cookie = HttpContext.Current.Request.Cookies[AuthCookieName] != null ? HttpContext.Current.Request.Cookies[AuthCookieName].Value : null;
                        if (cookie != null && !string.IsNullOrEmpty(cookie.ToString()))
                        {
                            var ticket = FormsAuthentication.Decrypt(cookie.ToString());
                            _currentUser = _accountRepository.User.First(u => (u.Id == Guid.Parse(ticket.Name)));
                        }

                    }
                    catch (Exception ex)
                    {
                        _currentUser = null;
                    }
                }
                return _currentUser;
            }
        }

        public static void SetValue(string cookieName, string cookieObject, DateTime dateStoreTo)
        {

            HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookieName);
                cookie.Path = "/";
            }

            cookie.Value = cookieObject;
            cookie.Expires = dateStoreTo;

            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}