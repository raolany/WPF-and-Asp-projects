using System;
using System.Collections.Generic;
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
using MainWpfApplication.ViewModel;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.View
{
    public partial class GroupWindow : Window
    {
        private GroupWindowVM _groupWindowVm;
        private Guid _userId;
        private Guid _trId;
        private Group _group;

        public GroupWindow(List<TrainingVM> trainings, Guid trId)
        {
            InitializeComponent();
            _groupWindowVm = new GroupWindowVM(trainings, trId);
            DataContext = _groupWindowVm.GroupVm;
            TrainingsCb.DataContext = _groupWindowVm;
        }

        public GroupWindow(List<TrainingVM> trainings, GroupVM group)
        {
            InitializeComponent();
            _groupWindowVm = new GroupWindowVM(trainings, group);
            DataContext = _groupWindowVm.GroupVm;
            TrainingsCb.DataContext = _groupWindowVm;
            _groupWindowVm.Training = _groupWindowVm.GroupVm.TrainingVm;
            //TrainingsCb.SelectedItem = _groupWindowVm.GroupVm.TrainingVm;
            //for (int i = 0; i < trainings.Count; i++)
            //{
            //    TrainingVM training = trainings[i];
            //    if (training.Training.Id == _groupWindowVm.Training.Training.Id)
            //    {
            //        TrainingsCb.SelectedIndex = i;
            //        break;
            //    }
            //}
        }

        public GroupWindow(List<TrainingVM> trainings, GroupVM group, bool flag, Guid userId) : this(trainings, group)
        {
            _userId = userId;
            _group = group.Group;
            _trId = _group.Trainer;
            SaveBtn.Visibility = Visibility.Collapsed;
            MainGrid.IsEnabled = false;
            if (!flag)
                SendOfferBtn.Visibility = Visibility.Visible;
        }

        private void BtnCreateOnClick(object sender, RoutedEventArgs e)
        {
            if (_groupWindowVm.BtnSaveOnClick())
            {
                MessageBox.Show("Saved");
                Close();
            }
            else MessageBox.Show("Fix all errors");
        }

        private void BtnCancelOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SendOfferBtnOnClick(object sender, RoutedEventArgs e)
        {
            User receiver = User.GetByQuery("trainer = '" + _trId + "'")[0];
            NotificationWindow notificationWindow = new NotificationWindow(_userId, receiver.Id, 1, _group);
            notificationWindow.ShowDialog();
        }
    }
}
