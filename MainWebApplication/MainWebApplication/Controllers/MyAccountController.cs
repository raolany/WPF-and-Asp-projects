using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ninject;

namespace MainWebApplication.Controllers
{
    public class MyAccountController : Controller
    {
        //TCSystemModel db = new TCSystemModel();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                /*var mainUser = db.User.First(u => (u.Login == user.Login && u.Password == user.Password));
                if (mainUser != null)
                {
                    //FormsAuthentication.SetAuthCookie(mainUser.Id.ToString(), createPersistentCookie: true);
                    TempData["UserId"] = mainUser.Id;
                    return RedirectToAction("Profile", "Submenu");
                }*/
            }
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IAsyncResult>().To<Trainer>();
            return View();
        }
    }
}