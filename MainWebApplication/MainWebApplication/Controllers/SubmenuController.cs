using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainWebApplication.Models;

namespace MainWebApplication.Controllers
{
    //[Authorize]
    public class SubmenuController : Controller
    {
        //TCSystemModel db = new TCSystemModel();
        
        /*public ActionResult Profile1()
        
            
            //if (user.TrainerId != Guid.Empty)
            //{
            //    var trainer = Trainer.GetByID(user.TrainerId);
            //    ViewData["AccountType"] = "Trainer";
            //    return View(trainer);
            //}
            //if (user.ClientId != Guid.Empty)
            //{
            //    var client = Trainer.GetByID(user.ClientId);
            //    ViewData["AccountType"] = "Client";
            //    return View(client);
            //}
            return View(db.Trainer.ToList()[0]);
        }*/
        
        public ActionResult Profile()
        {
            //Guid userid = Guid.Parse(TempData["UserId"].ToString());
            //User user = db.User.First(u => (u.Id == userid));
            
            /*var user = db.User.ToList()[0];
            if (user.Trainer != null)
            {
                var trainer = db.Trainer.First(tr => (tr.Id == user.Trainer));
                return View(trainer);
            }
            if (user.Client != null)
            {
                var client = db.Client.First(cl => (cl.Id == user.Client));
                return View(client);
            }*/
            return View();
        }
    }
}