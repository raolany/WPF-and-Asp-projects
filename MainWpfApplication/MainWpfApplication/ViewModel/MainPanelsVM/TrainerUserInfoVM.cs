using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using MainWpfApplication.View;
using MainWpfApplication.ViewModel.Data;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MainWpfApplication.ViewModel.MainPanelsVM
{
    public class TrainerUserInfoVM : ViewModelBase
    {
        private ObservableCollection<ClientVM> _clientsCollection = new ObservableCollection<ClientVM>();
        private ObservableCollection<TrainingVM> _trainingsCollection = new ObservableCollection<TrainingVM>();
        private ObservableCollection<GroupVM> _groupsCollection = new ObservableCollection<GroupVM>();
        private TrainingVM _selectedTraining;
        private GroupVM _selectedGroup;
        private TrainerVM _trainer;

        public TrainerUserInfoVM(Trainer trainer)
        {
            Trainer = new TrainerVM(trainer);
            LoadData();
        }

        public ObservableCollection<ClientVM> UserCollection
        {
            get { return _clientsCollection; }
        }

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

        public TrainerVM Trainer
        {
            get { return _trainer; }
            set
            {
                _trainer = value;
                OnPropertyChanged("Trainer");
            }
        }

        public string HeaderList
        {
            get { return "My clients"; }
        }

        public Visibility TrainerVisibility => Visibility.Visible;

        public Visibility ClientVisibility => Visibility.Collapsed;

        public void BtnAddTrainingOnClick()
        {
            Log.Instance.Info("MainWindow", "Click on add Training button");
            CreateTrainingWindow window = new CreateTrainingWindow(Trainer.Trainer.Id);
            window.ShowDialog();
            LoadTrainings();
            OnPropertyChanged("TrainingsCollection");
        }

        public void EditSelectedTraining()
        {
            Log.Instance.Info("MainWindow", "Click on edit training button");
            CreateTrainingWindow window = new CreateTrainingWindow(SelectedTraining);
            window.ShowDialog();
            LoadGroups();
            OnPropertyChanged("GroupsCollection");
        }

        public void DeleteSelectedTraining()
        {
            DialogResult result = MessageBox.Show("Delete training " + SelectedTraining.Training.ToString(), "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                _selectedTraining.Training.Delete();
                LoadTrainings();
                OnPropertyChanged("TrainingsCollection");
            }
        }

        public void BtnAddGroupOnClick()
        {
            Log.Instance.Info("MainWindow", "Click on add group button");
            if (TrainingsCollection.Count > 0)
            {
                GroupWindow window = new GroupWindow(TrainingsCollection.ToList(), Trainer.Trainer.Id);
                window.ShowDialog();
                LoadGroups();
                OnPropertyChanged("GroupsCollection");
            }
            else
            {
                MessageBox.Show("You have not any training, please add training","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Instance.Warning("MainWindow", "Trainer click add group without trainings");
            }
        }

        public void EditSelectedGroup()
        {
            Log.Instance.Info("MainWindow", "Click on edit training button");
            GroupWindow window = new GroupWindow(TrainingsCollection.ToList(), SelectedGroup);
            window.ShowDialog();
        }

        public void DeleteSelectedGroup()
        {
            DialogResult result = MessageBox.Show("Delete group " + SelectedGroup.Group.ToString(), "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                _selectedGroup.Group.Delete();
                LoadGroups();
                OnPropertyChanged("GroupsCollection");
            }
        }

        private void LoadData()
        {
            LoadTrainings();
            LoadGroups();
        }

        private void LoadTrainings()
        {
            _trainingsCollection.Clear();

            foreach (Training training in Training.GetByQuery("trainer = '" + _trainer.Trainer.Id + "'"))
                _trainingsCollection.Add(new TrainingVM(training));
        }

        private void LoadGroups()
        {
            _groupsCollection.Clear();

            foreach (Group group in Group.GetByQuery("trainer = '" + _trainer.Trainer.Id + "'"))
                _groupsCollection.Add(new GroupVM(group));
        }



    }
}
