using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebAppAsp1.Models;
using WebAppAsp1.Models.EntetiesModel;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Controllers
{
    [Authorize]
    public class SubmenuController : Controller
    {
        //public ActionResult Profile()
        //{
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var myuser = db.User.First(u => (u.ApplicationUserId == id));
        //    if (User.IsInRole("Trainer"))
        //    {
        //        var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
        //        return View(profile);
        //    }
        //    else if (User.IsInRole("Client"))
        //    {
        //        var profile = db.Client.First(c => (c.Id == myuser.Client));
        //        return View(profile);
        //    }
        //    return View();
        //}

        //public ActionResult EditProfile()
        //{
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var myuser = db.User.First(u => (u.ApplicationUserId == id));
        //    if (User.IsInRole("Trainer"))
        //    {
        //        var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
        //        ProfileViewModel trainer = new ProfileViewModel()
        //        {
        //            Address = profile.Address,
        //            Age = profile.Age,
        //            City = profile.City,
        //            Gender = profile.Gender,
        //            Name = profile.Name,
        //            Patronymicname = profile.Patronymicname,
        //            Phone = profile.Phone,
        //            Surname = profile.Surname
        //        };
        //        return View(trainer);
        //    }
        //    if (User.IsInRole("Client"))
        //    {
        //        var profile = db.Client.First(t => (t.Id == myuser.Client));
        //        ProfileViewModel client = new ProfileViewModel()
        //        {
        //            Address = profile.Address,
        //            Age = profile.Age,
        //            City = profile.City,
        //            Gender = profile.Gender,
        //            Name = profile.Name,
        //            Patronymicname = profile.Patronymicname,
        //            Phone = profile.Phone,
        //            Surname = profile.Surname
        //        };
        //        return View(client);
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]
        //public ActionResult EditProfile(ProfileViewModel model)
        //{
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var myuser = db.User.First(u => (u.ApplicationUserId == id));
        //    if (User.IsInRole("Client"))
        //    {
        //        var profile = db.Client.First(t => (t.Id == myuser.Client));
        //        profile.Name = model.Name;
        //        profile.Surname = model.Surname;
        //        profile.Patronymicname = model.Patronymicname;
        //        profile.Age = model.Age;
        //        profile.Address = model.Address;
        //        profile.City = model.City;
        //        profile.Gender = model.Gender;
        //        profile.Phone = model.Phone;
        //        db.SaveChanges();
        //        return RedirectToAction("Profile");
        //    }
        //    if (User.IsInRole("Trainer"))
        //    {
        //        var profile = db.Trainer.First(t => (t.Id == myuser.Trainer));
        //        profile.Name = model.Name;
        //        profile.Surname = model.Surname;
        //        profile.Patronymicname = model.Patronymicname;
        //        profile.Age = model.Age;
        //        profile.Address = model.Address;
        //        profile.City = model.City;
        //        profile.Gender = model.Gender;
        //        profile.Phone = model.Phone;
        //        db.SaveChanges();
        //        return RedirectToAction("Profile");
        //    }
        //    return View();
        //}
        
        //public ActionResult Trainings(string type)
        //{
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var user = db.User.First(t => (t.ApplicationUserId == id));

        //    IEnumerable<Training> trainings;
        //    if (type == "mytrainings")
        //    {
        //        ViewData["my"] = "active";
        //        if(User.IsInRole("Trainer"))
        //        {
        //            trainings = db.Training.Where(t => (t.Trainer == user.Trainer));
        //        }
        //        else
        //        {
        //            trainings = db.Training.Where(t => (t.Trainer == user.Client));
        //        }
        //    }
        //    else if (type == "alltrainings")
        //    {
        //        ViewData["all"] = "active";
        //        trainings = db.Training.ToList();
        //    }
        //    else return HttpNotFound();

        //    List<TrainingModel> trainingsModel = new List<TrainingModel>();
        //    foreach (var training in trainings)
        //    {
        //        var trainer = db.Trainer.First(t => (t.Id == training.Trainer));
        //        trainingsModel.Add(new TrainingModel()
        //        {
        //            Id = training.Id,
        //            Name = training.Name,
        //            Trainer = training.Trainer,
        //            TrainerName = trainer.Surname + " " + trainer.Name,
        //            Description = training.Description,
        //            Price = training.Price,
        //            Minage = training.Minage,
        //            Hours = training.Minage
        //        });
        //    }

        //    if (!trainings.Any()) TempData["null"] = true;
        //    else TempData["null"] = false ;

        //    return View(trainingsModel);
        //}

        //[Authorize(Roles = "Trainer")]
        //public ActionResult CreateTraining()
        //{
        //    TempData["mode"] = "create";
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateTraining(Training training)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var id = User.Identity.GetUserId();
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var user = db.User.First(t => (t.ApplicationUserId == id));
        //        training.Id = Guid.NewGuid();
        //        training.Trainer = (Guid) user.Trainer;
        //        db.Training.Add(training);
        //        db.SaveChanges();
        //        return Redirect("Trainings?type=mytrainings");
        //    }
        //    return HttpNotFound();
        //}
        
        //[HttpGet]
        //public ActionResult EditTraining(string trainingId)
        //{
        //    Guid id;
        //    if (ModelState.IsValid && Guid.TryParse(trainingId, out id))
        //    {
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var training = db.Training.First(t => (t.Id == id));
        //        TempData["mode"] = "edit";
        //        return View("CreateTraining", training);
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]
        //public ActionResult EditTraining(Training training, Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var tr = db.Training.First(t => (t.Id == id));
        //        tr.Description = training.Description;
        //        tr.Hours = training.Hours;
        //        tr.Minage = training.Minage;
        //        tr.Name = training.Name;
        //        tr.Price = training.Price;
        //        db.SaveChanges();
        //        return Redirect("Trainings?type=mytrainings");
        //    }
        //    return HttpNotFound();
        //}

        //public ActionResult Groups(string type)
        //{
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var user = db.User.First(t => (t.ApplicationUserId == id));
        //    IEnumerable<Group> groups;
        //    if (type == "mygroups")
        //    {
        //        ViewData["my"] = "active";
        //        groups = db.Group.Where(gr => (gr.Trainer == user.Trainer));
        //    }
        //    else if (type == "allgroups")
        //    {
        //        ViewData["all"] = "active";
        //        groups = db.Group.ToList();
        //    }
        //    else return HttpNotFound();

        //    List<GroupModel> list = new List<GroupModel>();
        //    foreach (var gr in groups)
        //    {
        //        var trainer = db.Trainer.First(t => (t.Id == gr.Trainer));
        //        list.Add(new GroupModel()
        //        {
        //            Id = gr.Id,
        //            Name = gr.Name,
        //            Trainer = gr.Trainer,
        //            TrainerName = trainer.Surname + " " + trainer.Name,
        //            Training = gr.Training,
        //            TrainingName = ((Training)db.Training.First(t => (t.Id == gr.Training))).Name,
        //            Clientmax = gr.Clientmax,
        //            Clientsnow = gr.Clientsnow,
        //            Description = gr.Description
        //        });
        //    }

        //    return View(list);
        //}

        //public ActionResult CreateGroup()
        //{
        //    TempData["mode"] = "create";
        //    var id = User.Identity.GetUserId();
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var user = db.User.First(t => (t.ApplicationUserId == id));

        //    var trainings = db.Training.Where(tr => (tr.Trainer == user.Trainer));
        //    if (trainings.Any())
        //    {
        //        List<ShortTrainingModel> list = new List<ShortTrainingModel>();
        //        foreach (var training in trainings)
        //        {
        //            list.Add(new ShortTrainingModel()
        //            {
        //                Id = training.Id,
        //                Name = training.Name
        //            });
        //        }

                
        //        return View(new GroupModel() {AllTrainings = list});
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult CreateGroup(GroupModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var id = User.Identity.GetUserId();
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var user = db.User.First(t => (t.ApplicationUserId == id));

        //        if (user.Trainer != null)
        //        {
        //            Group group = new Group()
        //            {
        //                Id = Guid.NewGuid(),
        //                Name = model.Name,
        //                Trainer = (Guid) user.Trainer,
        //                Training = model.SelectedTraining,
        //                Clientmax = model.Clientmax,
        //                Clientsnow = 0,
        //                Description = model.Description
        //            };

        //            db.Group.Add(group);
        //            db.SaveChanges();
        //            return Redirect("Groups?type=mygroups");
        //        }
        //    }
        //    return HttpNotFound();
        //}

        //[HttpGet]
        //public ActionResult EditGroup(string groupId)
        //{
        //    Guid id;
        //    if (ModelState.IsValid && Guid.TryParse(groupId, out id))
        //    {
        //        var _id = User.Identity.GetUserId();
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var user = db.User.First(t => (t.ApplicationUserId == _id));
        //        var group = db.Group.First(g => (g.Id == id));
        //        TempData["mode"] = "edit";
                
        //        var trainings = db.Training.Where(tr => (tr.Trainer == user.Trainer));
        //        if (trainings.Any())
        //        {
        //            List<ShortTrainingModel> list = new List<ShortTrainingModel>();
        //            foreach (var training in trainings)
        //            {
        //                list.Add(new ShortTrainingModel()
        //                {
        //                    Id = training.Id,
        //                    Name = training.Name
        //                });
        //            }

        //            GroupModel model = new GroupModel()
        //            {
        //                Id = group.Id,
        //                Name = group.Name,
        //                Clientmax = group.Clientmax,
        //                Description = group.Description,
        //                AllTrainings = list,
        //                SelectedTraining = group.Training
        //            };

        //            return View("CreateGroup", model);
        //        }
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]
        //public ActionResult EditGroup(GroupModel model, Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //        var gr = db.Group.First(g => (g.Id == id));
        //        gr.Name = model.Name;
        //        gr.Clientmax = model.Clientmax;
        //        gr.Description = model.Description;
        //        gr.Training = model.SelectedTraining;
        //        db.SaveChanges();
        //        return Redirect("Groups?type=mygroups");
        //    }
        //    return HttpNotFound();
        //}

        //public ActionResult Trainer(Guid id)
        //{
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var tr = db.Trainer.First(t => (t.Id == id));

        //    var trainings = db.Training.Where(t => (t.Trainer == id));
        //    List<TrainingModel> trainingsModel = new List<TrainingModel>();
        //    foreach (var training in trainings)
        //    {
        //        trainingsModel.Add(new TrainingModel()
        //        {
        //            Id = training.Id,
        //            Name = training.Name,
        //            Trainer = training.Trainer,
        //            TrainerName = tr.Surname + " "+tr.Name,
        //            Description = training.Description,
        //            Price = training.Price,
        //            Minage = training.Minage,
        //            Hours = training.Minage
        //        });
        //    }

        //    var groups = db.Group.Where(t => (t.Trainer == id));
        //    List<GroupModel> groupsModel = new List<GroupModel>();
        //    foreach (var group in groups)
        //    {
        //        groupsModel.Add(new GroupModel()
        //        {
        //            Id = group.Id,
        //            Name = group.Name,
        //            Clientmax = group.Clientmax,
        //            Description = group.Description,
        //            Trainer = id,
        //            TrainerName = tr.Surname + " " + tr.Name,
        //            Training = group.Training,
        //            TrainingName = db.Training.First(t => (t.Id == group.Training)).Name,
        //            Clientsnow = group.Clientsnow
        //        });
        //    }

        //    TrainerModel model = new TrainerModel()
        //    {
        //        Trainer = tr,
        //        Trainings = trainingsModel,
        //        Groups = groupsModel
        //    };
        //    return View(model);
        //}

        //public ActionResult Training(Guid id)
        //{
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var training = db.Training.First(t => (t.Id == id));
        //    var trainer = db.Trainer.First(t => (t.Id == training.Trainer));

        //    TrainingModel model = new TrainingModel()
        //    {
        //        Id = training.Id,
        //        Trainer = trainer.Id,
        //        TrainerName = trainer.Surname + " " +trainer.Name,
        //        Name = training.Name, 
        //        Hours = training.Hours,
        //        Price = training.Price,
        //        Minage = training.Minage,
        //        Description = training.Description
        //    };
        //    return View(model);
        //}

        //public ActionResult Group(Guid id)
        //{
        //    var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
        //    var gr = db.Group.First(t => (t.Id == id));

        //    var trainer = db.Trainer.First(t => (t.Id == gr.Trainer));
        //    var model = new GroupModel()
        //        {
        //            Id = gr.Id,
        //            Name = gr.Name,
        //            Trainer = gr.Trainer,
        //            TrainerName = trainer.Surname+" " + trainer.Name,
        //            Training = gr.Training,
        //            TrainingName = ((Training)db.Training.First(t => (t.Id == gr.Training))).Name,
        //            Clientmax = gr.Clientmax,
        //            Clientsnow = gr.Clientsnow,
        //            Description = gr.Description
        //        };
            
        //    return View(model);
        //}

        public ActionResult Messages()
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var id = User.Identity.GetUserId();
            var user = db.User.First(u => (u.ApplicationUserId == id));

            var ntfs = db.Notification.Where(n => (n.Receiver == user.Id));

            List<NotifificationModel> model = new List<NotifificationModel>();
            foreach (var item in ntfs)
            {
                string sn = "";
                var sender = db.User.First(u => (u.Id == item.Sender));
                if (sender.Trainer != null)
                {
                    var tr = db.Trainer.First(t => (t.Id == sender.Trainer));
                    sn = tr.Name +" "+ tr.Surname;
                }
                else
                {
                    var cl = db.Client.First(t => (t.Id == sender.Client));
                    sn = cl.Name+ " "+ cl.Surname;
                }
                var ntfsModel = new NotifificationModel()
                {
                    Id = item.Id,
                    Type = db.NotificationType.First(n => (n.Id == item.Type)).Name,
                    //TrainingName = db.Training.First(t => (t.Id == (item.Trainingid ?? Guid.Empty))).Name,
                    //Trainingid = item.Trainingid ?? Guid.Empty,
                    Receiver = item.Receiver,
                    Sender = item.Sender,
                    //Groupid = item.Groupid ?? Guid.Empty,
                    //GroupName = db.Group.First(t => (t.Id == (item.Groupid ?? Guid.Empty))).Name,
                    Msg = item.Msg,
                    Status = item.Status,
                    Time = DateTime.Parse(item.Time),
                    SenderName = sn
                };
                var dt = DateTime.Parse(item.Time);
                if (item.Trainingid != null)
                {
                    ntfsModel.TrainingName = db.Training.First(t => (t.Id == item.Trainingid)).Name;
                    ntfsModel.Trainingid = (Guid) item.Trainingid;
                }
                if (item.Groupid != null)
                {
                    ntfsModel.Groupid = (Guid) item.Groupid;
                    ntfsModel.GroupName = db.Group.First(t => (t.Id == item.Groupid)).Name;
                }
                model.Add(ntfsModel);
            }
            
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
                Notification ntf = new Notification()
                {
                    Id = Guid.NewGuid(),
                    Type = db.NotificationType.First(t => (t.Value == 0)).Id,
                    Msg = msg,
                    Sender = sender.Id,
                    Status = false,
                    Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                    Receiver = rec.Id
                };
                db.Notification.Add(ntf);
                db.SaveChanges();
                return Redirect("Trainer?id=" + receiver);
            }
            else
            {
                Notification ntf = new Notification()
                {
                    Id = Guid.NewGuid(),
                    Type = db.NotificationType.First(t => (t.Value == 0)).Id,
                    Msg = msg,
                    Sender = sender.Id,
                    Status = false,
                    Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                    Receiver = receiver
                };
                db.Notification.Add(ntf);
                db.SaveChanges();
                return Redirect(url);
            }
            
            //return HttpNotFound();
        }

        public ActionResult Subscribe(Guid id, Guid obj, string type)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var _id = User.Identity.GetUserId();
            var sender = db.User.First(u => (u.ApplicationUserId == _id));

            Notification ntf = new Notification()
            {
                Id = Guid.NewGuid(),
                Sender = sender.Id,
                Type = db.NotificationType.First(t => (t.Value == 1)).Id,
                Receiver = db.User.First(u => (u.Trainer == id)).Id,
                Status = false,
                Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
            };

            string url = "";
            if (type == "training")
            {
                ntf.Trainingid = obj;
                ntf.Msg = "User want subscribe on your training";
                url = "Training?id=" + obj;
            }
            if (type == "group")
            {
                ntf.Groupid = obj;
                ntf.Msg = "User want subscribe on your group";
                url = "Group?id=" + obj;
            }

            db.Notification.Add(ntf);
            db.SaveChanges();

            return Redirect(url);
        }

        public ActionResult AcceptSub(NotifificationModel model)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var _id = User.Identity.GetUserId();



            return RedirectToAction("Messages");
        }
    }
}
