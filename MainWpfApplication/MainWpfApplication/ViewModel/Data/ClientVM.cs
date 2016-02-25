using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using EO.Internal;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using Group = MainWpfApplication.Model.Group;

namespace MainWpfApplication.ViewModel.Data
{
    public class ClientVM : ViewModelBase, IDataErrorInfo
    {
        private Client _client;
        private string error;

        public ClientVM(Client client)
        {
            _client = client;
        }

        public Client Client => _client;

        public string Name
        {
            get { return _client.Name; }
            set { _client.Name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _client.Surname; }
            set { _client.Surname = value; OnPropertyChanged("Surname"); }
        }

        public string PatronymicName
        {
            get { return _client.PatronymicName; }
            set { _client.PatronymicName = value; OnPropertyChanged("PatronymicName"); }
        }

        public GenderType Gender
        {
            get { return _client.Gender; }
            set { _client.Gender = value; OnPropertyChanged("Gender"); }
        }

        public string City
        {
            get { return _client.City; }
            set { _client.City = value; OnPropertyChanged("City"); }
        }

        public string Address
        {
            get { return _client.Address; }
            set { _client.Address = value; OnPropertyChanged("Address"); }
        }

        public string Phone
        {
            get { return _client.Phone; }
            set { _client.Phone = value; OnPropertyChanged("Phone"); }
        }

        public int Age
        {
            get { return _client.Age; }
            set { _client.Age = value; OnPropertyChanged("Age"); }
        }

        public string Mail
        {
            get { return _client.Mail; }
            set { _client.Mail = value; OnPropertyChanged("Mail"); }
        }

        public List<Group> Groups
        {
            get
            {
                var res = new List<Group>();
                foreach (GroupClient gc in GroupClient.AllItems)
                    if (gc.ClientId == Client.Id)
                        res.Add(Group.GetByID(gc.GroupId));
                return res;
            }
        }

        public List<Training> Trainings
        {
            get
            {
                var res = new List<Training>();
                foreach (TrainingClient tc in TrainingClient.AllItems)
                    if (tc.ClientId == Client.Id)
                        res.Add(Training.GetByID(tc.TrainingId));
                return res;
            }
        }

        public Visibility TrainerVisibility => Visibility.Collapsed;

        public Visibility ClientVisibility => Visibility.Visible;

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
