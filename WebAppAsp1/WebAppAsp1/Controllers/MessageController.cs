using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
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

            return View(model.OrderBy(m => m.Status).ThenByDescending(m => m.Time));
        }

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
            ntf.Type = db.NotificationType.First(t => (t.Value == 1)).Id;

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

        [Authorize(Roles = "Trainer")]
        public ActionResult AcceptTrainingSubscribe(bool value, Guid sender, Guid receiver, Guid id)
        {
            if (ModelState.IsValid)
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();

                if (value)
                {
                    var ucl = db.User.First(u => (u.Id == receiver));
                    var cl = db.Client.First(c => (c.Id == ucl.Client));

                    var trainingcl = new TrainingClient()
                    {
                        Id = Guid.NewGuid(),
                        Client = cl.Id,
                        Training = id
                    };
                    db.TrainingClient.Add(trainingcl);

                    var ntf = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        Status = false,
                        Msg = "Trainer accept you in training",
                        Sender = sender,
                        Receiver = receiver,
                        Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                        Type = db.NotificationType.First(t => (t.Value == 1)).Id
                    };

                    db.Notification.Add(ntf);
                    db.SaveChanges();

                }
            }

            return RedirectToAction("Messages");
        }

        [Authorize(Roles = "Trainer")]
        public ActionResult AcceptGroupSubscribe(bool value, Guid sender, Guid receiver, Guid id)
        {
            if (ModelState.IsValid)
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();

                if (value)
                {
                    var ucl = db.User.First(u => (u.Id == receiver));
                    var cl = db.Client.First(c => (c.Id == ucl.Client));

                    var groupcl = new GroupClient()
                    {
                        Id = Guid.NewGuid(),
                        Clientid = cl.Id,
                        Groupid = id
                    };
                    db.GroupClient.Add(groupcl);

                    db.Group.First(g => g.Id == id).Clientsnow += 1;

                    var ntf = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        Status = false,
                        Msg = "Trainer accept you in group",
                        Sender = sender,
                        Receiver = receiver,
                        Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                        Type = db.NotificationType.First(t => (t.Value == 1)).Id
                    };

                    db.Notification.Add(ntf);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Messages");
        }

        [Authorize(Roles = "Trainer")]
        public ActionResult RefuseSubscribe(Guid sender, Guid receiver, Guid id)
        {
            if (ModelState.IsValid)
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                
                var ntf = new Notification()
                {
                    Id = Guid.NewGuid(),
                    Status = false,
                    Msg = "Trainer refuse your offer",
                    Sender = sender,
                    Receiver = receiver,
                    Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                    Type = db.NotificationType.First(t => (t.Value == 1)).Id
                };

                db.Notification.Add(ntf);
                db.SaveChanges();
            }

            return RedirectToAction("ReadMsg", new {id = id});
        }

        public ActionResult ReadMsg(Guid id)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var msg = db.Notification.First(n => (n.Id == id));
            msg.Status = true;
            db.SaveChanges();           
            return RedirectToAction("Messages");
        }

        public int MessageCount()
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var id = User.Identity.GetUserId();
            var user = db.User.First(u => (u.ApplicationUserId == id));
            var count = db.Notification.Count(n => (n.Receiver == user.Id && !n.Status));
            return count;
        }

        public string NewMessages()
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var id = User.Identity.GetUserId();
            var user = db.User.First(u => (u.ApplicationUserId == id));
            var ntfs = db.Notification.Where(n => (n.Receiver == user.Id && !n.Status && !n.Sended));

            var obj = "";
            foreach (var ntf in ntfs)
            {
                var delta = DateTime.Now - DateTime.Parse(ntf.Time);
                if (delta.TotalSeconds < 300)
                {
                    ntf.Sended = true;
                    obj = JsonConvert.SerializeObject(ntf);
                    break;
                }
            }
            db.SaveChanges();
            return obj;
        }
    }
}