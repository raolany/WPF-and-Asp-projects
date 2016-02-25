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
    public partial class CreateTrainingWindow : Window
    {
        private CreateTrainingVM _createTrainingVm;
        private Guid _userId;
        private Guid _trId;
        private Training _training;

        public CreateTrainingWindow(Guid trId)
        {
            InitializeComponent();
            _createTrainingVm = new CreateTrainingVM(trId);
            DataContext = _createTrainingVm.TrainingVm;
        }

        public CreateTrainingWindow(TrainingVM training)
        {
            InitializeComponent();
            _createTrainingVm = new CreateTrainingVM(training);
            DataContext = _createTrainingVm.TrainingVm;
        }

        public CreateTrainingWindow(TrainingVM training, bool flag, Guid userId) : this(training)
        {
            _userId = userId;
            _trId = training.TrainerId;
            _training = training.Training;
            SaveBtn.Visibility = Visibility.Collapsed;
            MainGrid.IsEnabled = false;
            if (!flag)
                SendOfferBtn.Visibility = Visibility.Visible;
            
        }

        private void BtnCreateOnClick(object sender, RoutedEventArgs e)
        {
            if (_createTrainingVm.BtnSaveOnClick())
            {
                MessageBox.Show("New training saved");
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
            NotificationWindow notificationWindow = new NotificationWindow(_userId, receiver.Id, 1, _training);
            notificationWindow.ShowDialog();
        }
    }
}
