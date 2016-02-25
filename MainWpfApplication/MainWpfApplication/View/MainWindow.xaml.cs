using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using MainWpfApplication.View;
using MainWpfApplication.View.SearchPanels;
using MainWpfApplication.ViewModel;
using MainWpfApplication.ViewModel.Data;
using MainWpfApplication.ViewModel.MainPanelsVM;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MainWpfApplication
{
    public partial class MainWindow : Window
    {
        private MainWindowVM _mainWindowVM;
        private TrainerUserInfoVM _trainerUserInfoVm;
        private ClientUserInfoVM _clientUserInfoVm;
        private SearchVM _searchVm;
        private NotificationsListVM _notificationsListVm;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowVM = new MainWindowVM();
                        
            VerificationWindow verificationWindow = new VerificationWindow(_mainWindowVM);
            verificationWindow.ShowDialog();

            if (!_mainWindowVM.IsChangeUser) Close();
            else
            {
                DataContext = _mainWindowVM;
                Log.Instance.Info("MainWindow", "Created Main Window");
            }
        }
        
        private void Tabs_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshMainView();
        }

        private void BtnExitClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.Info("MainWindow", "Exit program");
            Close();
        }

        private void MenuItemChangeUserOnClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.Info("MainWindow", "Change user");
            
            MainWindowVM mainWindowVM = new MainWindowVM();
            VerificationWindow verificationWindow = new VerificationWindow(mainWindowVM);
            verificationWindow.ShowDialog();

            if (mainWindowVM.IsChangeUser)
            {
                _mainWindowVM = mainWindowVM;
                DataContext = _mainWindowVM;
                _trainerUserInfoVm = null;
                _clientUserInfoVm = null;
                RefreshMainView();
            }
        }

        private void RefreshMainView()
        {
            if (Tabs.SelectedIndex == 0)
            {
                _notificationsListVm = null;
                Log.Instance.Info("MainWindow", "Choose tab #0");
                if (_mainWindowVM.UserType == UserType.Trainer)
                {
                    if (_trainerUserInfoVm == null)
                        _trainerUserInfoVm = new TrainerUserInfoVM(_mainWindowVM.Trainer);
                    _clientUserInfoVm = null;
                    MyInfoTI.DataContext = _trainerUserInfoVm;
                    MyInfo.DataContext = _trainerUserInfoVm.Trainer;
                }
                if (_mainWindowVM.UserType == UserType.Client)
                {
                    if(_clientUserInfoVm == null)
                        _clientUserInfoVm = new ClientUserInfoVM(_mainWindowVM.Client);
                    _trainerUserInfoVm = null;
                    MyInfoTI.DataContext = _clientUserInfoVm;
                    MyInfo.DataContext = _clientUserInfoVm.Client;
                }
            }
            else if (Tabs.SelectedIndex == 1)
            {
                _notificationsListVm = null;
                Log.Instance.Info("MainWindow", "Choose tab #1");
                if (_searchVm == null)
                {
                    _searchVm = new SearchVM();
                    SearchTI.DataContext = _searchVm;
                    SearchFrame.Navigate(_searchVm.TrainerSearchPnl);
                }
            }
            else if (Tabs.SelectedIndex == 2)
            {
                Log.Instance.Info("MainWindow", "Choose tab #2");
                if (_notificationsListVm == null)
                    _notificationsListVm = new NotificationsListVM(_mainWindowVM.User);
                NotificationsTI.DataContext = _notificationsListVm;
            }
        }

        private void BtnEditProfileOnClick(object sender, RoutedEventArgs e)
        {
            Log.Instance.Info("MainWindow", "Begin edit profile");
            if (_trainerUserInfoVm != null)
            {
                EditUserProfileWindow window = new EditUserProfileWindow(_trainerUserInfoVm.Trainer);
                window.ShowDialog();
            }
            if (_clientUserInfoVm != null)
            {
                EditUserProfileWindow window = new EditUserProfileWindow(_clientUserInfoVm.Client);
                window.ShowDialog();
            }
            Log.Instance.Info("MainWindow", "End edit profile");
        }

        private void BtnAddTrainingOnClick(object sender, RoutedEventArgs e)
        {
            _trainerUserInfoVm.BtnAddTrainingOnClick();
        }

        private void EditTrainingOnClick(object sender, RoutedEventArgs e)
        {
            if (_trainerUserInfoVm.SelectedTraining != null)
            { 
                _trainerUserInfoVm.EditSelectedTraining();
            }
        }

        private void DeleteTrainingOnClick(object sender, RoutedEventArgs e)
        {
            _trainerUserInfoVm.DeleteSelectedTraining();
        }

        private void BtnAddGroupOnClick(object sender, RoutedEventArgs e)
        {
            _trainerUserInfoVm.BtnAddGroupOnClick();
        }

        private void BtnEditGroupOnClick(object sender, RoutedEventArgs e)
        {
            _trainerUserInfoVm.EditSelectedGroup();
        }

        private void BtnDeleteGroupOnClick(object sender, RoutedEventArgs e)
        {
            _trainerUserInfoVm.DeleteSelectedGroup();
        }
        
        private void SearchTypeObjOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox cb = (System.Windows.Controls.ComboBox) sender;
            if (SearchFrame != null && _searchVm != null)
            {
                if (cb.SelectedIndex == 0 || cb.SelectedIndex == 1)
                    SearchFrame.Navigate(_searchVm.TrainerSearchPnl);
                if (cb.SelectedIndex == 2)
                    SearchFrame.Navigate(_searchVm.TrainingSearchPanel);
                if (cb.SelectedIndex == 3)
                    SearchFrame.Navigate(_searchVm.GroupSearchPanel);
            }
        }

        private void BtnSearchOnClick(object sender, RoutedEventArgs e)
        {
            if (SearchTypeCb.SelectedIndex == 0)
            {
                _searchVm.SearchTrainers();
                SearchListBox.ItemsSource = _searchVm.TrainersCollection;
            }
            if (SearchTypeCb.SelectedIndex == 1)
            {
                _searchVm.SearchClients();
                SearchListBox.ItemsSource = _searchVm.ClientsCollection;
            }
            if (SearchTypeCb.SelectedIndex == 2)
            {
                _searchVm.SearchTrainings();
                SearchListBox.ItemsSource = _searchVm.TrainingsCollection;
            }
            if (SearchTypeCb.SelectedIndex == 3)
            {
                _searchVm.SearchGroups();
                SearchListBox.ItemsSource = _searchVm.GroupsCollection;
            }
        }

        private void MouseDCOnIyem_OnHandler(object sender, MouseButtonEventArgs e)
        { 
            ListBoxItem item = sender as ListBoxItem;

            if (item.Content is TrainerVM)
            {
                EditUserProfileWindow profileWindow = new EditUserProfileWindow((TrainerVM)item.Content, false, _mainWindowVM.User.Id);
                profileWindow.ShowDialog();
            }
            if (item.Content is ClientVM)
            {
                EditUserProfileWindow profileWindow = new EditUserProfileWindow((ClientVM)item.Content, false, _mainWindowVM.User.Id);
                profileWindow.ShowDialog();
            }
            if (item.Content is TrainingVM)
            {
                CreateTrainingWindow trainingWindow;
                if(_mainWindowVM.UserType == UserType.Trainer)
                    trainingWindow = new CreateTrainingWindow((TrainingVM)item.Content, true, _mainWindowVM.User.Id);
                else
                    trainingWindow = new CreateTrainingWindow((TrainingVM)item.Content, false, _mainWindowVM.User.Id);
                trainingWindow.ShowDialog();
            }
            if (item.Content is GroupVM)
            {
                GroupWindow groupWindow;
                if (_mainWindowVM.UserType == UserType.Trainer)
                    groupWindow = new GroupWindow(new List<TrainingVM>() { ((GroupVM)item.Content).TrainingVm }, (GroupVM)item.Content, true, _mainWindowVM.User.Id);
                else
                    groupWindow = new GroupWindow(new List<TrainingVM>() { ((GroupVM)item.Content).TrainingVm }, (GroupVM)item.Content, false, _mainWindowVM.User.Id);
                groupWindow.ShowDialog();
            }
            if (item.Content is NotificationVM)
            {
                NotificationVM notif = (NotificationVM)item.Content;
                if (notif.Type.Value == 0)
                {
                    NotificationWindow notificationWindow = new NotificationWindow(notif.ReceiverId, notif.SenderId, 0, (Training) null);
                    notificationWindow.ShowDialog();
                }
                if (notif.Type.Value == 1 && _mainWindowVM.UserType == UserType.Trainer)
                {
                    NotificationWindow notificationWindow = new NotificationWindow(notif.ReceiverId, notif.SenderId, notif);
                    notificationWindow.ShowDialog();
                }
            }

        }
    }
}
