using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel.MainPanelsVM
{
    public class NotificationsListVM
    {
        private ObservableCollection<NotificationVM> _notificationCollection = new ObservableCollection<NotificationVM>();
        private User _user;

        public NotificationsListVM(User user)
        {
            _user = user;
            LoadData();
        }

        public ObservableCollection<NotificationVM> NotificationCollection
        {
            get { return _notificationCollection; }
        }

        private void LoadData()
        {
            _notificationCollection.Clear();

            foreach (var ntfc in Notification.GetByQuery("receiver = '"+_user.Id+"'"))
                _notificationCollection.Add(new NotificationVM(ntfc));
        }
    }
}
