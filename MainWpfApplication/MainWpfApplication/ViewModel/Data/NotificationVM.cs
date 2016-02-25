
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Model;

namespace MainWpfApplication.ViewModel.Data
{
    public class NotificationVM
    {
        private Notification _notification;

        public NotificationVM(Notification notification)
        {
            _notification = notification;
        }

        public User Sender => User.GetByID(SenderId);
        public string SenderName
        {
            get
            {
                try
                {
                    return Trainer.GetByID(Sender.TrainerId).ToString();
                }
                catch
                {
                    try
                    {
                        return Client.GetByID(Sender.ClientId).ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
            }
        }
        public User Receiver => User.GetByID(ReceiverId);
        public NotificationType Type => NotificationType.GetByID(TypeId);
        public Notification Notification => _notification;

        public string Msg
        {
            get { return _notification.Msg; }
            set { _notification.Msg = value; }
        }

        public string Time
        {
            get { return _notification.Time; }
            set { _notification.Time = value; }
        }

        public Guid TypeId
        {
            get { return _notification.TypeId; }
            set { _notification.TypeId = value; }
        }

        public bool Status
        {
            get { return _notification.Status; }
            set { _notification.Status = value; }
        }

        public Guid SenderId
        {
            get { return _notification.SenderId; }
            set { _notification.SenderId = value; }
        }

        public Guid ReceiverId
        {
            get { return _notification.ReceiverId; }
            set { _notification.ReceiverId = value; }
        }

        public Guid TrainingId
        {
            get { return _notification.TrainingId; }
            set { _notification.TrainingId = value; }
        }

        public Guid GroupId
        {
            get { return _notification.GroupId; }
            set { _notification.GroupId = value; }
        }
    }
}
