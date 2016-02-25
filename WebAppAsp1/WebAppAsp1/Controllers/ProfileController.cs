using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebAppAsp1.Models;
using WebAppAsp1.Models.EntetiesModel;

namespace WebAppAsp1.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var myuser = db.User.First(u => (u.ApplicationUserId == id));
            if (User.IsInRole("Trainer"))
            {
                var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
                return View(profile);
            }
            else if (User.IsInRole("Client"))
            {
                var profile = db.Client.First(c => (c.Id == myuser.Client));
                return View(profile);
            }
            return View();
        }

        public ActionResult EditProfile()
        {
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var myuser = db.User.First(u => (u.ApplicationUserId == id));
            if (User.IsInRole("Trainer"))
            {
                var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
  
                return View(ProfileViewModel.Init(profile));
            }
            if (User.IsInRole("Client"))
            {
                var profile = db.Client.First(t => (t.Id == myuser.Client));
                
                return View(ProfileViewModel.Init(profile));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditProfile(ProfileViewModel model)
        {
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var myuser = db.User.First(u => (u.ApplicationUserId == id));
            if (User.IsInRole("Client"))
            {
                var profile = db.Client.First(t => (t.Id == myuser.Client));
                ProfileViewModel.InitFromModel(model, profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (User.IsInRole("Trainer"))
            {
                var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
                ProfileViewModel.InitFromModel(model, profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Trainer(Guid id)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            
            return View(TrainerModel.Init(db, id));
        }
    }
}