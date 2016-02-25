
using System;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using MainWpfApplication.Model;
using MainWpfApplication.View.SearchPanels;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel.MainPanelsVM
{
    public class SearchVM : ViewModelBase
    {
        private ObservableCollection<TrainerVM> _trainersCollection = new ObservableCollection<TrainerVM>();
        private ObservableCollection<ClientVM> _clientsCollection = new ObservableCollection<ClientVM>();
        private ObservableCollection<TrainingVM> _trainingsCollection = new ObservableCollection<TrainingVM>();
        private ObservableCollection<GroupVM> _groupsCollection = new ObservableCollection<GroupVM>();

        private object _selectedObj;
        private string _searchStr = "";

        private TrainerSearchPnl _trainerSearchPnl;
        private TrainingSearchPanel _trainingSearchPanel;
        private GroupSearchPanel _groupSearchPanel;

        public ObservableCollection<TrainerVM> TrainersCollection => _trainersCollection;
        public ObservableCollection<ClientVM> ClientsCollection => _clientsCollection;
        public ObservableCollection<TrainingVM> TrainingsCollection => _trainingsCollection;
        public ObservableCollection<GroupVM> GroupsCollection => _groupsCollection;

        public TrainerSearchPnl TrainerSearchPnl
        {
            get
            {
                _trainingSearchPanel = null;
                _groupSearchPanel = null;
                _trainerSearchPnl = new TrainerSearchPnl();
                return _trainerSearchPnl;
            }
        }
        public TrainingSearchPanel TrainingSearchPanel
        {
            get
            {
                _trainerSearchPnl = null;
                _trainingSearchPanel = new TrainingSearchPanel();
                _groupSearchPanel = null;
                return _trainingSearchPanel;
            }
        }
        public GroupSearchPanel GroupSearchPanel
        {
            get
            {
                _trainerSearchPnl = null;
                _trainingSearchPanel = null;
                _groupSearchPanel = new GroupSearchPanel();
                return _groupSearchPanel;
            }
        }

        public string SearchString
        {
            get { return _searchStr; }
            set { _searchStr = value; }
        }

        public void SearchTrainers()
        {
            _trainersCollection.Clear();
            foreach (Trainer trainer in Trainer.GetByQuery(WhereParams("trainer")))
            {
                _trainersCollection.Add(new TrainerVM(trainer));
            }
        }

        public void SearchClients()
        {
            _clientsCollection.Clear();
            foreach (Client client in Client.GetByQuery(WhereParams("client")))
            {
                _clientsCollection.Add(new ClientVM(client));
            }
        }

        public void SearchTrainings()
        {
            _trainingsCollection.Clear();
            foreach (Training training in Training.GetByQuery(WhereParams("training")))
            {
                _trainingsCollection.Add(new TrainingVM(training));
            }
        }

        public void SearchGroups()
        {
            _groupsCollection.Clear();
            foreach (Group group in Group.GetByQuery(WhereParams("group")))
            {
                _groupsCollection.Add(new GroupVM(group));
            }
        }

        private string WhereParams(string type)
        {
            string whereParams = "";
            if (SearchString != string.Empty)
            {
                if (type == "trainer" || type == "client")
                {
                    whereParams = "((name like '%" + SearchString + "%') " +
                                  "or (surname like '%" + SearchString + "%') " +
                                  "or (patronymicname like '%" + SearchString + "%'))";
                }
                else if (type == "training")
                {
                    whereParams = "((name like '%" + SearchString + "%'))";
                }
                else if (type == "group")
                {
                    whereParams = "((name like '%" + SearchString + "%'))";
                }
            }

            if (type == "trainer" || type == "client")
            {
                if (_trainerSearchPnl.WhereParams != string.Empty && whereParams != string.Empty)
                    whereParams += " and " + _trainerSearchPnl.WhereParams;
                else
                    whereParams += _trainerSearchPnl.WhereParams;
            }
            else if (type == "training")
            {
                if (_trainingSearchPanel.WhereParams != string.Empty && whereParams != string.Empty)
                    whereParams += " and " + _trainingSearchPanel.WhereParams;
                else
                    whereParams += _trainingSearchPanel.WhereParams;
            }
            else if (type == "group")
            {
                if (_groupSearchPanel.WhereParams != string.Empty && whereParams != string.Empty)
                    whereParams += " and " + _groupSearchPanel.WhereParams;
                else
                    whereParams += _groupSearchPanel.WhereParams;
            }
            return whereParams;
        }

    }
}
