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
using MainWpfApplication.View;

namespace MainWpfApplication.ViewModel.Data
{
    public class TrainingVM : ViewModelBase, IDataErrorInfo
    {
        private Training _training;
        private bool _selected = false;
        private string error;

        public TrainingVM(Training training)
        {
            _training = training;
        }

        public Training Training => _training;

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
                if(Selected) 
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public string Name
        {
            get { return _training.Name; }
            set { _training.Name = value; OnPropertyChanged("Name"); }
        }

        public string Description
        {
            get { return _training.Description; }
            set { _training.Description = value; OnPropertyChanged("Description"); }
        }

        public int Hours
        {
            get { return _training.Hours; }
            set { _training.Hours = value; OnPropertyChanged("Hours"); }
        }

        public int MinAge
        {
            get { return _training.MinAge; }
            set { _training.MinAge = value; OnPropertyChanged("MinAge"); }
        }

        public double Price
        {
            get { return _training.Price; }
            set { _training.Price = value; OnPropertyChanged("Price"); }
        }

        public Guid TrainerId
        {
            get { return _training.TrainerId; }
            set { _training.TrainerId = value; }
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
                    case "MinAge":
                        if (MinAge < 1 || MinAge >= 100)
                        {
                            error = ErrorList.Age;
                        }
                        break;
                    case "Hours":
                        if (Hours < 1 || Hours >= 1000)
                        {
                            error = ErrorList.Hours;
                        }
                        break;
                    case "Price":
                        if (Price < 0 || Price >= 10000)
                        {
                            error = ErrorList.Price;
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
