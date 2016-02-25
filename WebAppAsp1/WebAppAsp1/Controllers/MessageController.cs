using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebAppAsp1.Models;
using WebAppAsp1.Models.EntetiesModel;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Messages()
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var id = User.Identity.GetUserId();
            var user = db.User.First(u => (u.ApplicationUserId == id));
            var ntfs = db.Notification.Where(n => (n.Receiver == user.Id));
            var model = NotifificationModel.InitMsgs(db, ntfs);

            return View(model.OrderByDescending(m => m.Time));
        }

        [HttpPost]
        public ActionResult SendMsg(Guid receiver, string rectype, string msg, string url)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var id = User.Identity.GetUserId();
            var sender = db.User.First(u => (u.ApplicationUserId == id));

            if (rectype == "trainer")
            {
                var rec = db.User.First(u => (u.Trainer == receiver));
                var ntf = NotifificationModel.InitNtfNotifificationFromModel(sender.Id, rec.Id, msg, db);
                db.Notification.Add(ntf);
                db.SaveChanges();
                return RedirectToAction("Trainer","Profile", new { id = receiver});
            }
            else
            {
                var ntf = NotifificationModel.InitNtfNotifificationFromModel(sender.Id, receiver, msg, db);
                db.Notification.Add(ntf);
                db.SaveChanges();
                return Redirect(url);
            }
        }

        public ActionResult Subscribe(Guid id, Guid obj, string type)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var _id = User.Identity.GetUserId();
            var sender = db.User.First(u => (u.ApplicationUserId == _id));

            var ntf = NotifificationModel.InitNtfNotifificationFromModel(sender.Id, db.User.First(u => (u.Trainer == id)).Id, String.Empty, db);

            string url = "";
            if (type == "training")
            {
                ntf.Trainingid = obj;
                ntf.Msg = "User want subscribe on your training";
                url = "Training";
            }
            if (type == "group")
            {
                ntf.Groupid = obj;
                ntf.Msg = "User want subscribe on your group";
                url = "Group";
            }

            db.Notification.Add(ntf);
            db.SaveChanges();

            return RedirectToAction(url, url, new {id = obj});
        }

        public ActionResult AcceptSub(NotifificationModel model)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var _id = User.Identity.GetUserId();



            return RedirectToAction("Messages");
        }
    }
}