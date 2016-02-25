using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MainWpfApplication.Core;
using MainWpfApplication.DL;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel
{
    public class RegisterTrainerVM : IDataErrorInfo //delete
    {
        private string error = "";

        public RegisterTrainerVM()
        {
            InitilizeData();
        }

        public UserType UserType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PatronymicName { get; set; }
        public GenderType Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Mail { get; set; }

        private void InitilizeData()
        {
            Login = "";
            Password = "";
            Name = "";
            Surname = "";
            PatronymicName = "";
            Gender = GenderType.Male;
            City = "";
            Address = "";
            Phone = "";
            Age = 0.ToString();
            Mail = "";
        }

        public void BtnCloseClick()
        {
        }

        public bool Register()
        {
            try
            {
                int age = Int32.Parse(Age);

                if (Regex.IsMatch(Login, RegexMask.LoginMask) && Regex.IsMatch(Password, RegexMask.PasswordMask) &&
                    Regex.IsMatch(Name, RegexMask.FioMask) && Regex.IsMatch(Surname, RegexMask.FioMask) &&
                    Regex.IsMatch(PatronymicName, RegexMask.FioMask) && (age > 1 || age < 100) &&
                    Regex.IsMatch(Address, RegexMask.AddressMask) && Regex.IsMatch(City, RegexMask.CityMask) &&
                    Regex.IsMatch(Phone, RegexMask.PhoneMask) && Regex.IsMatch(Mail, RegexMask.MailMask) 
                    && User.LoginIsFree(Login))
                {
                    if (UserType == UserType.Trainer)
                    {
                        Trainer trainer = new Trainer()
                        {
                            Name = Name,
                            Surname = Surname,
                            PatronymicName = PatronymicName,
                            Gender = Gender,
                            City = City,
                            Address = Address,
                            Age = age,
                            Phone = Phone,
                            Mail = Mail
                        };
                        trainer.Save();

                        User user = new User()
                        {
                            Login = Login,
                            Password = Password,
                            TrainerId = trainer.Id
                        };
                        user.Save();
                    }
                    else if (UserType == UserType.Client)
                    {
                        Client client = new Client()
                        {
                            Name = Name,
                            Surname = Surname,
                            PatronymicName = PatronymicName,
                            Gender = Gender,
                            City = City,
                            Address = Address,
                            Age = age,
                            Phone = Phone,
                            Mail = Mail
                        };
                        client.Save();

                        User user = new User()
                        {
                            Login = Login,
                            Password = Password,
                            ClientId = client.Id
                        };
                        user.Save();
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("RegisterTrainerVM", ex.Message);
                return false;
            }
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
                    case "Login":
                        if (!Regex.IsMatch(Login, RegexMask.LoginMask))
                        {
                            error = ErrorList.Login;
                        }
                        else if (!User.LoginIsFree(Login))
                        {
                            error = "User with this login already exist\n";
                        }
                        break;
                    case "Password":
                        if (!Regex.IsMatch(Password, RegexMask.PasswordMask))
                        {
                            error = ErrorList.Password;
                        }
                        break;
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
                            int age = Int32.Parse(Age);
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
