using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel.MainPanelsVM
{
    public class ClientUserInfoVM : ViewModelBase
    {
        //private ObservableCollection<TrainerVM> _trainersCollection = new ObservableCollection<TrainerVM>();
        private ObservableCollection<TrainingVM> _trainingsCollection = new ObservableCollection<TrainingVM>();
        private ObservableCollection<GroupVM> _groupsCollection = new ObservableCollection<GroupVM>();
        private TrainingVM _selectedTraining;
        private GroupVM _selectedGroup;
        //private TrainerVM _selectedTrainer;

        private ClientVM _client;

        public ClientUserInfoVM(Client client)
        {
            Client = new ClientVM(client);
            LoadData();
        }

        /*public ObservableCollection<TrainerVM> UserCollection
        {
            get { return _trainersCollection; }
        }*/

        public ObservableCollection<TrainingVM> TrainingsCollection
        {
            get { return _trainingsCollection; }
        }

        public TrainingVM SelectedTraining
        {
            get { return _selectedTraining; }
            set
            {
                if (_selectedTraining != null)
                {
                    _selectedTraining.Selected = false;
                }
                _selectedTraining = value;
                if (_selectedTraining != null)
                {
                    _selectedTraining.Selected = true;
                }
                OnPropertyChanged("SelectedTraining");
            }
        }

        public ObservableCollection<GroupVM> GroupsCollection
        {
            get { return _groupsCollection; }
        }

        public GroupVM SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != null)
                {
                    _selectedGroup.Selected = false;
                }
                _selectedGroup = value;
                if (_selectedGroup != null)
                {
                    _selectedGroup.Selected = true;
                }
                OnPropertyChanged("SelectedGroup");
            }
        }

        public ClientVM Client
        {
            get { return _client; }
            set
            {
                _client = value;
            }
        }

        public string HeaderList
        {
            get { return "My trainers"; }
        }

        public Visibility TrainerVisibility => Visibility.Collapsed;

        public Visibility ClientVisibility => Visibility.Visible;

        private void LoadData()
        {
            _trainingsCollection.Clear();
            foreach (Training tr in Client.Trainings)
                _trainingsCollection.Add(new TrainingVM(tr));

            _groupsCollection.Clear();
            foreach (Group gr in Client.Groups)
                _groupsCollection.Add(new GroupVM(gr));
        }
    }
}
