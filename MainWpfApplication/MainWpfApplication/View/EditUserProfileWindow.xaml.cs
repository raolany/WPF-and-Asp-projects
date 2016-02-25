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
using Data;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel;
using MainWpfApplication.ViewModel.Data;
using GenderType = MainWpfApplication.Model.GenderType;
using MessageBox = System.Windows.Forms.MessageBox;
using Trainer = MainWpfApplication.Model.Trainer;

namespace MainWpfApplication.View
{
    public partial class EditUserProfileWindow : Window
    {
        private EditTrainerProfileVM _editTrainerProfileVm;
        private EditClientProfileVM _editClientProfileVm;
        private Guid _userId;
        private Guid _trId;
        private Guid _clId;

        public EditUserProfileWindow(TrainerVM trainer)
        {
            InitializeComponent();
            
            _editTrainerProfileVm = new EditTrainerProfileVM(trainer);
            DataContext = _editTrainerProfileVm.TrainerVm;
            Gender.SelectedIndex = (int)_editTrainerProfileVm.TrainerVm.Gender; 
        }

        public EditUserProfileWindow(ClientVM client)
        {
            InitializeComponent();

            _editClientProfileVm = new EditClientProfileVM(client);
            DataContext = _editClientProfileVm.ClientVm;
            Gender.SelectedIndex = (int)_editClientProfileVm.ClientVm.Gender;
        }

        public EditUserProfileWindow(TrainerVM trainer, bool flag, Guid userId) : this(trainer)
        {
            _userId = userId;
            _trId = trainer.Trainer.Id;
            SaveBtn.Visibility = Visibility.Collapsed;
            if(!flag)
                SendMsgBtn.Visibility = Visibility.Visible;
            MainGrid.IsEnabled = flag;
        }

        public EditUserProfileWindow(ClientVM client, bool flag, Guid userId) : this(client)
        {
            _userId = userId;
            _clId = client.Client.Id;
            SaveBtn.Visibility = Visibility.Collapsed;
            if (!flag)
                SendMsgBtn.Visibility = Visibility.Visible;
            MainGrid.IsEnabled = flag;
        }

        private void BtnCancelOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSaveOnClick(object sender, RoutedEventArgs e)
        {
            if (_editTrainerProfileVm != null)
            {
                if (_editTrainerProfileVm.BtnSaveOnClick())
                {
                    MessageBox.Show("New profile saved");
                    Close();
                }
                else
                    MessageBox.Show("Fix all errors!!!");
            }
            else if (_editClientProfileVm != null)
            {
                if (_editClientProfileVm.BtnSaveOnClick())
                {
                    MessageBox.Show("New profile saved");
                    Close();
                }
                else
                    MessageBox.Show("Fix all errors!!!");
            }
        }

        private void GenderOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (_editTrainerProfileVm != null)
            {
                if(Gender.SelectedIndex == 0)
                    _editTrainerProfileVm.TrainerVm.Gender = GenderType.Male;
                else
                    _editTrainerProfileVm.TrainerVm.Gender = GenderType.Female;
            }
            else if (_editClientProfileVm != null)
            {
                if (Gender.SelectedIndex == 0)
                    _editClientProfileVm.ClientVm.Gender = GenderType.Male;
                else
                    _editClientProfileVm.ClientVm.Gender = GenderType.Female;
            }
        }

        private void SendMsgBtnOnClick(object sender, RoutedEventArgs e)
        {
            if (_editTrainerProfileVm != null)
            {
                User receiver = User.GetByQuery("trainer = '"+ _trId +"'")[0];
                NotificationWindow notificationWindow = new NotificationWindow(_userId, receiver.Id, 0);
                notificationWindow.ShowDialog();
                Close();
            }
            else if (_editClientProfileVm != null)
            {
                User receiver = User.GetByQuery("client = '" + _clId + "'")[0];
                NotificationWindow notificationWindow = new NotificationWindow(_userId, receiver.Id, 0);
                notificationWindow.ShowDialog();
                Close();
            }
        }
    }
}
