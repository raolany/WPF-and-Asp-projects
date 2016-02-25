using System;
using System.Collections.Generic;
using System.IO;
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
using MainWpfApplication.ViewModel;
using MainWpfApplication.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MainWpfApplication.View
{
    public partial class VerificationWindow : Window
    {
        private MainWindowVM _mainWindowVM;

        public VerificationWindow(MainWindowVM mainWindowVM)
        {
            _mainWindowVM = mainWindowVM;
            InitializeComponent();
            Log.Instance.Info("VerificationWindow", "Created verification window");
        }

        private void BtnLoginOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = User.GetByQuery("login = '" + Login.Text + "' and password = '" + Password.Text + "'")[0];
                _mainWindowVM.User = user;
                Log.Instance.Info("VerificationWindow", "User enter in system");
                _mainWindowVM.IsChangeUser = true;
                Close();
            }
            catch (Exception ex)
            {
                Log.Instance.Error("VerificationWindow", "Incorrect login or password "+ex.Message);
                MessageBox.Show("Incorrect login or password");
                _mainWindowVM.IsChangeUser = false;
            }
        }

        private void BtnCancelOnClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.Info("VerificationWindow", "User has not been verified and close program");
            _mainWindowVM.IsChangeUser = false;
            Close();
        }

        private void BtnRegisterOnClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.Info("VerificationWindow", "User begin register");
            RegisterWindow regWindow = new RegisterWindow();
            regWindow.ShowDialog();
        }
    }
}
