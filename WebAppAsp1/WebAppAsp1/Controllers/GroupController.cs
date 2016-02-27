using System;
using System.Collections.Generic;
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
    public class GroupController : Controller
    {
        public ActionResult Groups(string type)
        {
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var user = db.User.First(t => (t.ApplicationUserId == id));
            IEnumerable<Group> groups;
            if (type == "mygroups")
            {
                ViewData["my"] = "active";
                if (User.IsInRole("Trainer"))
                {
                    groups = db.Group.Where(gr => (gr.Trainer == user.Trainer));
                }
                else
                {
                    var tmp = db.GroupClient.Where(gc => (gc.Clientid == user.Client));
                    var lst = new List<Group>();
                    foreach (GroupClient grcl in tmp)
                    {
                        lst.Add(db.Group.First(g => g.Id == grcl.Groupid));
                    }
                    groups = lst;
                }
            }
            else if (type == "allgroups")
            {
                ViewData["all"] = "active";
                groups = db.Group.ToList();
            }
            else return HttpNotFound();

            var list = GroupModel.InitGroups(db, groups);

            return View(list);
        }

        public ActionResult CreateGroup()
        {
            TempData["mode"] = "create";
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var user = db.User.First(t => (t.ApplicationUserId == id));

            var trainings = db.Training.Where(tr => (tr.Trainer == user.Trainer));
            if (trainings.Any())
            {
                var list = ShortTrainingModel.Init(trainings);
                return View(new GroupModel() { AllTrainings = list });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateGroup(GroupModel model)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var user = db.User.First(t => (t.ApplicationUserId == id));

                if (user.Trainer != null)
                {
                    Group group = new Group()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Trainer = (Guid)user.Trainer,
                        Training = model.SelectedTraining,
                        Clientmax = model.Clientmax,
                        Clientsnow = 0,
                        Description = model.Description
                    };

                    db.Group.Add(group);
                    db.SaveChanges();
                    return Redirect("Groups?type=mygroups");
                }
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult EditGroup(string groupId)
        {
            Guid id;
            if (ModelState.IsValid && Guid.TryParse(groupId, out id))
            {
                var _id = User.Identity.GetUserId();
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var user = db.User.First(t => (t.ApplicationUserId == _id));
                var group = db.Group.First(g => (g.Id == id));
                TempData["mode"] = "edit";

                var trainings = db.Training.Where(tr => (tr.Trainer == user.Trainer));
                if (trainings.Any())
                {
                    var list = ShortTrainingModel.Init(trainings);
                    var model = GroupModel.InitEditGroupModel(group, list);

                    return View("CreateGroup", model);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditGroup(GroupModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var gr = db.Group.First(g => (g.Id == id));
                gr.Name = model.Name;
                gr.Clientmax = model.Clientmax;
                gr.Description = model.Description;
                gr.Training = model.SelectedTraining;
                db.SaveChanges();
                return Redirect("Groups?type=mygroups");
            }
            return HttpNotFound();
        }

        public ActionResult Group(Guid id)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var gr = db.Group.First(t => (t.Id == id));
            
            var model = GroupModel.InitGroup(db, gr);

            return View(model);
        }
    }
}