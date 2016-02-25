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
    public class TrainingController : Controller
    {
        public ActionResult Trainings(string type)
        {
            var id = User.Identity.GetUserId();
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
            var user = db.User.First(t => (t.ApplicationUserId == id));

            IEnumerable<Training> trainings;
            if (type == "mytrainings")
            {
                ViewData["my"] = "active";
                trainings = User.IsInRole("Trainer") ? db.Training.Where(t => (t.Trainer == user.Trainer)) : db.Training.Where(t => (t.Trainer == user.Client));
            }
            else if (type == "alltrainings")
            {
                ViewData["all"] = "active";
                trainings = db.Training.ToList();
            }
            else return HttpNotFound();

            var model = TrainingModel.InitTrainings(db, trainings);

            if (!trainings.Any()) TempData["null"] = true;
            else TempData["null"] = false;

            return View(model);
        }

        [Authorize(Roles = "Trainer")]
        public ActionResult CreateTraining()
        {
            TempData["mode"] = "create";
            return View();
        }

        [HttpPost]
        public ActionResult CreateTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var user = db.User.First(t => (t.ApplicationUserId == id));
                training.Id = Guid.NewGuid();
                training.Trainer = (Guid)user.Trainer;
                db.Training.Add(training);
                db.SaveChanges();
                return Redirect("Trainings?type=mytrainings");
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult EditTraining(string trainingId)
        {
            Guid id;
            if (ModelState.IsValid && Guid.TryParse(trainingId, out id))
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var training = db.Training.First(t => (t.Id == id));
                TempData["mode"] = "edit";
                return View("CreateTraining", training);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditTraining(Training training, Guid id)
        {
            if (ModelState.IsValid)
            {
                var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();
                var tr = db.Training.First(t => (t.Id == id));
                tr.Description = training.Description;
                tr.Hours = training.Hours;
                tr.Minage = training.Minage;
                tr.Name = training.Name;
                tr.Price = training.Price;
                db.SaveChanges();
                return Redirect("Trainings?type=mytrainings");
            }
            return HttpNotFound();
        }

        public ActionResult Training(Guid id)
        {
            var db = HttpContext.GetOwinContext().GetUserManager<ApplicationDbContext>();

            return View(TrainingModel.InitTraining(db, id));
        }
    }
}