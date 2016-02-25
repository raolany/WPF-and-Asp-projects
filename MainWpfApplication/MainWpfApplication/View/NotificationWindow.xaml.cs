using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MainWpfApplication.View
{
    public partial class NotificationWindow : Window
    {
        private NotificationVM _notificationVm;
        private NotificationVM _sendedNotif;

        public NotificationWindow(Guid sender, Guid receiver, int type)
        {
            InitializeComponent();
            _notificationVm = new NotificationVM(new Notification())
            {
                SenderId = sender,
                ReceiverId = receiver,
                TypeId = NotificationType.GetByQuery("value = "+type)[0].Id
            };
            if (type == 1) SendBtn.Content = "Send offer";
        }

        public NotificationWindow(Guid sender, Guid receiver, int type, Training training) : this(sender, receiver, type)
        {
            if (type == 0) SendBtn.Content = "Answer";
            else
            {
                _notificationVm.TrainingId = training.Id;
                TrainingGrid.DataContext = new TrainingVM(training);
                TrainingGrid.Visibility = Visibility.Visible;
            }
        }

        public NotificationWindow(Guid sender, Guid receiver, NotificationVM notif) : this(sender, receiver, 0)
        {
            SendBtn.Content = "Accept";
            _sendedNotif = notif;
        }

        public NotificationWindow(Guid sender, Guid receiver, int type, Group group) : this(sender, receiver, type)
        {
            _notificationVm.GroupId = group.Id;
            GroupGrid.DataContext = new GroupVM(group);
            GroupGrid.Visibility = Visibility.Visible;
        }

        private void BtnCancelOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SendBtnOnClick(object sender, RoutedEventArgs e)
        {
            _notificationVm.Msg = TextBox.Text;
            if (SendBtn.Content.ToString() == "Accept")
            {
                _notificationVm.Msg += "\n"+Trainer.GetByID(_notificationVm.Sender.TrainerId).ToString()+" Accept your offer";
                if(_sendedNotif.TrainingId != Guid.Empty)
                {
                    TrainingClient trainingClient = new TrainingClient();
                    trainingClient.TrainingId = _sendedNotif.TrainingId;
                    trainingClient.ClientId = User.GetByID(_sendedNotif.SenderId).ClientId;
                    trainingClient.Save();
                }
                if (_sendedNotif.GroupId != Guid.Empty)
                {
                    GroupClient groupClient = new GroupClient();
                    groupClient.GroupId = _sendedNotif.GroupId;
                    groupClient.ClientId = User.GetByID(_sendedNotif.SenderId).ClientId;
                    groupClient.Save();
                }
            }
            _notificationVm.Time = DateTime.Now.ToString("hh:mm:ss tt dd-MMMM-yyyy", CultureInfo.InvariantCulture);
            _notificationVm.Notification.Save();
            MessageBox.Show("Message sent");
            Close();
        }
    }
}
