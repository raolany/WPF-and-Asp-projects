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

namespace MainWpfApplication.ViewModel.Data
{
    public class TrainerVM : ViewModelBase, IDataErrorInfo
    {
        private Trainer _trainer;
        private string error;

        public TrainerVM(Trainer trainer)
        {
            _trainer = trainer;
        }

        public Trainer Trainer => _trainer;

        public string Name
        {
            get { return _trainer.Name; }
            set { _trainer.Name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _trainer.Surname; }
            set { _trainer.Surname = value; OnPropertyChanged("Surname"); }
        }

        public string PatronymicName
        {
            get { return _trainer.PatronymicName; }
            set { _trainer.PatronymicName = value; OnPropertyChanged("PatronymicName"); }
        }

        public GenderType Gender
        {
            get { return _trainer.Gender; }
            set { _trainer.Gender = value; OnPropertyChanged("Gender"); }
        }

        public string City
        {
            get { return _trainer.City; }
            set { _trainer.City = value; OnPropertyChanged("City"); }
        }

        public string Address
        {
            get { return _trainer.Address; }
            set { _trainer.Address = value; OnPropertyChanged("Address"); }
        }

        public string Phone
        {
            get { return _trainer.Phone; }
            set { _trainer.Phone = value; OnPropertyChanged("Phone"); }
        }

        public int Age
        {
            get { return _trainer.Age; }
            set { _trainer.Age = value; OnPropertyChanged("Age"); }
        }

        public string Mail
        {
            get { return _trainer.Mail; }
            set { _trainer.Mail = value; OnPropertyChanged("Mail"); }
        }

        public Visibility TrainerVisibility => Visibility.Visible;

        public Visibility ClientVisibility => Visibility.Collapsed;

        public string Error => error;

        public string this[string columnName]
        {
            get
            {
                error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (!Regex.IsMatch(Name, RegexMask.FioMask))
                        {
                            error = ErrorList.Name;
                        }
                        break;
                    case "Surname":
                        if (!Regex.IsMatch(Surname, RegexMask.FioMask))
                        {
                            error = ErrorList.Surname;
                        }
                        break;
                    case "PatronymicName":
                        if (!Regex.IsMatch(PatronymicName, RegexMask.FioMask))
                        {
                            error = ErrorList.PatronymicName;
                        }
                        break;
                    case "Age":
                        try
                        {
                            int age = Age;
                            if (age < 1 || age > 100)
                            {
                                error = ErrorList.Age;
                            }
                        }
                        catch
                        {
                            error = ErrorList.AgeNotNumber;
                        }
                        break;
                    case "Address":
                        if (!Regex.IsMatch(Address, RegexMask.AddressMask))
                        {
                            error = ErrorList.Address;
                        }
                        break;
                    case "Phone":
                        if (!Regex.IsMatch(Phone, RegexMask.PhoneMask))
                        {
                            error = ErrorList.Phone;
                        }
                        break;
                    case "City":
                        if (!Regex.IsMatch(City, RegexMask.CityMask))
                        {
                            error = ErrorList.City;
                        }
                        break;
                    case "Mail":
                        if (!Regex.IsMatch(Mail, RegexMask.MailMask))
                        {
                            error = ErrorList.Mail;
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

