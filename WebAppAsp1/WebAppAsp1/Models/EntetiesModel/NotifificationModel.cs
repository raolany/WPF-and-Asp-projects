using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models.EntetiesModel
{
    public class NotifificationModel
    {
        public static List<NotifificationModel> InitMsgs(ApplicationDbContext db, IEnumerable<Notification> ntfs)
        {
            List<NotifificationModel> model = new List<NotifificationModel>();
            foreach (var item in ntfs)
            {
                string sn = "";
                var sender = db.User.First(u => (u.Id == item.Sender));
                if (sender.Trainer != null)
                {
                    var tr = db.Trainer.First(t => (t.Id == sender.Trainer));
                    sn = tr.Name + " " + tr.Surname;
                }
                else
                {
                    var cl = db.Client.First(t => (t.Id == sender.Client));
                    sn = cl.Name + " " + cl.Surname;
                }
                var ntfsModel = new NotifificationModel()
                {
                    Id = item.Id,
                    Type = db.NotificationType.First(n => (n.Id == item.Type)).Name,
                    Receiver = item.Receiver,
                    Sender = item.Sender,
                    Msg = item.Msg,
                    Status = item.Status,
                    Time = DateTime.Parse(item.Time),
                    SenderName = sn
                };
                var dt = DateTime.Parse(item.Time);
                if (item.Trainingid != null)
                {
                    ntfsModel.TrainingName = db.Training.First(t => (t.Id == item.Trainingid)).Name;
                    ntfsModel.Trainingid = (Guid)item.Trainingid;
                }
                if (item.Groupid != null)
                {
                    ntfsModel.Groupid = (Guid)item.Groupid;
                    ntfsModel.GroupName = db.Group.First(t => (t.Id == item.Groupid)).Name;
                }
                model.Add(ntfsModel);
            }
            return model;
        }

        public static Notification InitNtfNotifificationFromModel(Guid sender, Guid receiver, string msg, ApplicationDbContext db)
        {
            Notification ntf = new Notification()
            {
                Id = Guid.NewGuid(),
                Type = db.NotificationType.First(t => (t.Value == 0)).Id,
                Msg = msg,
                Sender = sender,
                Status = false,
                Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture),
                Receiver = receiver
            };

            return ntf;
        }

        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Msg { get; set; }

        public bool Status { get; set; }

        public Guid Sender { get; set; }

        public string SenderName { get; set; }

        public Guid Receiver { get; set; }

        public string ReceiverName { get; set; }
        
        public DateTime Time { get; set; }

        public Guid Trainingid { get; set; }

        public string TrainingName { get; set; }

        public Guid Groupid { get; set; }

        public string GroupName { get; set; }
    }
}