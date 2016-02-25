using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using Group = MainWpfApplication.Model.Group;

namespace MainWpfApplication.ViewModel.Data
{
    public class GroupVM : ViewModelBase, IDataErrorInfo
    {
        private Group _group;
        private bool _selected = false;
        private string error;

        public GroupVM(Group group)
        {
            _group = group;
        }

        public Group Group => _group;
        public TrainingVM TrainingVm => new TrainingVM(Training.GetByID(_group.Training));
        public TrainerVM TrainerVm => new TrainerVM(Trainer.GetByID(_group.Trainer));

        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
                OnPropertyChanged("IsSelected");
            }
        }

        public Visibility IsSelected
        {
            get
            {
                if (Selected)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public string Name
        {
            get { return _group.Name; }
            set { _group.Name = value; OnPropertyChanged("Name"); }
        }
        public string Description
        {
            get { return _group.Description; }
            set { _group.Description = value; OnPropertyChanged("Description"); }
        }

        public int ClientMax
        {
            get { return _group.ClientMax; }
            set { _group.ClientMax = value; OnPropertyChanged("ClientMax"); }
        }
        public int ClientsNow
        {
            get { return _group.ClientsNow; }
            set { _group.ClientsNow = value; OnPropertyChanged("ClientsNow"); }
        }
        public Guid TrainingId
        {
            get { return _group.Training; }
            set
            {
                _group.Training = value; 
                OnPropertyChanged("TrainingVm");
            }
        }
        public Guid TrainerId
        {
            get { return _group.Trainer; }
            set
            {
                _group.Trainer = value;
                OnPropertyChanged("TrainerVm");
            }
        }

        public string Error => error;

        public string this[string columnName]
        {
            get
            {
                error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (!Regex.IsMatch(Name, RegexMask.Name))
                        {
                            error = ErrorList.Name;
                        }
                        break;
                    case "Description":
                        if (!Regex.IsMatch(Description, RegexMask.Text))
                        {
                            error = ErrorList.OnlyText;
                        }
                        break;
                    case "ClientMax":
                        if (ClientMax < 2 || ClientMax >= 30)
                        {
                            error = ErrorList.ClientMax;
                        }
                        break;

                    default:
                        throw new ArgumentException("Unrecognized property: " + columnName);
                }

                return error;
            }
        }
    }
}
