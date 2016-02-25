using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic.ApplicationServices;

namespace MainWebApplication.Models.Authentication
{
    public class AuthenticateAttribute : AuthorizeAttribute
    {
        public bool AllowAnonymus { get; set; }

        public UserRoles AccessTole { get; set; }

        public AuthenticateAttribute()
        {
        }

        public AuthenticateAttribute(bool allowAnonymus)
        {
            AllowAnonymus = allowAnonymus;
        }

        public AuthenticateAttribute(UserRoles accessRole) { AccessTole = accessRole; }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            /*if (AllowAnonymus)
                return true;


            User user = DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;
            if (user == null)
                return false;

            if (AccessTole == 0)
                return true;

            return user.IsInRole(AccessTole);*/
            return true;
        }

        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.Result = new System.Web.Mvc.RedirectResult("/login", false);
        }

    }
}