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
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel;
using MainWpfApplication.ViewModel.Data;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MainWpfApplication.View
{
    public partial class RegisterWindow : Window
    {
        private RegisterTrainerVM _registerTrainerVm;
        //private RegisterClientVM _registerClientVm;
        //private UserType _user;

        public RegisterWindow()
        {
            _registerTrainerVm = new RegisterTrainerVM();
            DataContext = _registerTrainerVm;
            InitializeComponent();
            /*if (_user == UserType.Trainer)
            {
                _registerTrainerVm = new RegisterTrainerVM();
                DataContext = _registerTrainerVm;
            }
            else if (_user == UserType.Client)
            {
                _registerClientVm = new RegisterClientVM();
                DataContext = _registerClientVm;
            }*/

        }

        private void BtnCancelOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRegisterOnClick(object sender, RoutedEventArgs e)
        {
            UserTypecb.IsEnabled = false;
            if (_registerTrainerVm.Register())
            {
                MessageBox.Show("Register was successful");
                Log.Instance.Info("RegisterWindow", "New user registered in system");
                Close();
            }
            else
            {
                MessageBox.Show("Fix errors");
                Log.Instance.Info("RegisterWindow", "New user enter incorrect data");
            }
            /*if (_user == UserType.Trainer)
            {
                if (_registerTrainerVm.Register())
                {
                    MessageBox.Show("Register was successful");
                    Close();
                }
                else MessageBox.Show("Fix errors");
            }
            else if (_user == UserType.Client)
            {
                if (_registerClientVm.Register())
                {
                    MessageBox.Show("Register was successful");
                    Close();
                }
                else MessageBox.Show("Fix errors");
            }*/
        }

        private void GenderOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Gender.SelectedIndex == 0)
                _registerTrainerVm.Gender = GenderType.Male;
            else
                _registerTrainerVm.Gender = GenderType.Female;
            /*if (_user == UserType.Trainer)
            {
                if (Gender.SelectedIndex == 0 && _registerTrainerVm != null)
                    _registerTrainerVm.Gender = GenderType.Male;
                else
                    _registerTrainerVm.Gender = GenderType.Female;
            }
            else if (_user == UserType.Client && _registerClientVm != null)
            {
                if (Gender.SelectedIndex == 0)
                    _registerClientVm.Gender = GenderType.Male;
                else
                    _registerClientVm.Gender = GenderType.Female;
            }*/
        }

        private void UserTypeOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserTypecb.SelectedIndex == 0)
                _registerTrainerVm.UserType = UserType.Trainer;
            else
                _registerTrainerVm.UserType = UserType.Client;
            /*if (UserTypecb.SelectedIndex == 0)
            {
                _user = UserType.Trainer;
                _registerClientVm = null;
                _registerTrainerVm = new RegisterTrainerVM();
            }
            else if (UserTypecb.SelectedIndex == 1)
            {
                _user = UserType.Client;
                _registerTrainerVm = null;
                _registerClientVm = new RegisterClientVM();
            }*/
        }
    }
}
