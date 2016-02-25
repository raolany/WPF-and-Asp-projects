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

namespace MainWpfApplication.ViewModel
{
    public class RegisterClientVM : IDataErrorInfo
    {
        private Client _client;
        private User _user;
        private string error = "";

        public RegisterClientVM()
        {
            _client = new Client();
            InitilizeData();
        }

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
            Name = _client.Name;
            Surname = _client.Surname;
            PatronymicName = _client.PatronymicName;
            Gender = _client.Gender;
            City = _client.City;
            Address = _client.Address;
            Phone = _client.Phone;
            Age = _client.Age.ToString();
            Mail = _client.Mail;
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
                    _client.Name = Name;
                    _client.Surname = Surname;
                    _client.PatronymicName = PatronymicName;
                    _client.Gender = Gender;
                    _client.City = City;
                    _client.Address = Address;
                    _client.Age = age;
                    _client.Phone = Phone;
                    _client.Mail = Mail;
                    _client.Save();
                    _user = new User()
                    {
                        Login = Login,
                        Password = Password,
                        ClientId = _client.Id,
                        TrainerId = Guid.Empty
                    };
                    _user.Save();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("RegisterClientVM", ex.Message);
                return false;
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
                    case "Login":
                        if (!Regex.IsMatch(Login, RegexMask.LoginMask))
                        {
                            error = "Login has only small english letters and digits, min length - 3, max - 20\n" +
                                    "Example : andre, jhon123, alexsandra666";
                        }
                        else if (!User.LoginIsFree(Login))
                        {
                            error = "User with this login already exist\n";
                        }
                        break;
                    case "Password":
                        if (!Regex.IsMatch(Password, RegexMask.PasswordMask))
                        {
                            error = "Login has only small english letters and digits, min length - 3, max - 20\n" +
                                    "Example : 45785qwe, 451we45";
                        }
                        break;
                    case "Name":
                        if (!Regex.IsMatch(Name, RegexMask.FioMask))
                        {
                            error = "Name has only english letters and begins with an uppercase letter\n" +
                                    "Example : Andre, Jhon, Alexsandra";
                        }
                        break;
                    case "Surname":
                        if (!Regex.IsMatch(Surname, RegexMask.FioMask))
                        {
                            error = "Surname has only english letters and begins with an uppercase letter\n" +
                                    "Example : Fury, Anderson, Petrov";
                        }
                        break;
                    case "PatronymicName":
                        if (!Regex.IsMatch(PatronymicName, RegexMask.FioMask))
                        {
                            error = "Name has only english letters and begins with an uppercase letter\n" +
                                    "Example : Viktorovich, Petrovich";
                        }
                        break;
                    case "Age":
                        try
                        {
                            int age = Int32.Parse(Age);
                            if (age < 1 || age > 100)
                            {
                                error = "Age can not be less than 1 and more than 100";
                            }
                        }
                        catch
                        {
                            error = "Age must be a number";
                        }
                        break;
                    case "Address":
                        if (!Regex.IsMatch(Address, RegexMask.AddressMask))
                        {
                            error = "Addres";
                        }
                        break;
                    case "Phone":
                        if (!Regex.IsMatch(Phone, RegexMask.PhoneMask))
                        {
                            error = "Phone number has 7 numbers\n" +
                                    "Example : 1234567";
                        }
                        break;
                    case "City":
                        if (!Regex.IsMatch(City, RegexMask.CityMask))
                        {
                            error = "City has only english letters\n" +
                                    "Example : Kyiv, London, New York";
                        }
                        break;
                    case "Mail":
                        if (!Regex.IsMatch(Mail, RegexMask.MailMask))
                        {
                            error = "It`s not a mail address\n" +
                                    "Example : example@example.com";
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
