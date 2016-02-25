using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel
{
    public enum UserType { Client, Trainer }

    public class MainWindowVM : ViewModelBase
    {
        private User _user;
        private Trainer _trainer;
        private Client _client;

        public bool IsChangeUser { get; set; }

        public UserType UserType
        {
            get
            {
                if(User.TrainerId != Guid.Empty) return UserType.Trainer;
                return UserType.Client;
            }
        }

        public Trainer Trainer => _trainer;//Trainer.GetByID(User.TrainerId);
        public Client Client => _client;//Client.GetByID(User.ClientId);

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                if (User.TrainerId != Guid.Empty)
                {
                    _trainer = Trainer.GetByID(User.TrainerId);
                    _client = null;
                }
                else if (User.ClientId != Guid.Empty)
                {
                    _client = Client.GetByID(User.ClientId);
                    _trainer = null;
                }
            }
        }

        public Visibility Visibility
        {
            get
            {
                if(UserType == UserType.Trainer) return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public string Welcome
        {
            get
            {
                if(UserType == UserType.Trainer)
                    return "Welcome : " + Trainer.ToString(); 
                if(UserType == UserType.Client)
                    return "Welcome : " + Client.ToString();
                return String.Empty;
            }
        }
        
    }
}
