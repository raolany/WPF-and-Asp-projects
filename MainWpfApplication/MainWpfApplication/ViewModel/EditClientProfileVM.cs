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
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel
{
    public class EditClientProfileVM : ViewModelBase
    {
        private ClientVM _client;
        private ClientVM _clVm;

        public EditClientProfileVM(ClientVM client)
        {
            _client = client;
            InitilizeData();
        }

        public ClientVM ClientVm
        {
            get { return _clVm; }
        }

        private void InitilizeData()
        {
            _clVm = new ClientVM(new Client())
            {
                Name = _client.Name,
                Surname = _client.Surname,
                PatronymicName = _client.PatronymicName,
                Gender = _client.Gender,
                City = _client.City,
                Address = _client.Address,
                Phone = _client.Phone,
                Mail = _client.Mail,
                Age = _client.Age
            };
        }

        private void CommitData()
        {
            _client.Name = _clVm.Name;
            _client.Surname = _clVm.Surname;
            _client.PatronymicName = _clVm.PatronymicName;
            _client.Gender = _clVm.Gender;
            _client.City = _clVm.City;
            _client.Address = _clVm.Address;
            _client.Phone = _clVm.Phone;
            _client.Age = _clVm.Age;
            _client.Mail = _clVm.Mail;
        }

        public bool BtnSaveOnClick()
        {
            try
            {
                if (Regex.IsMatch(_clVm.Name, RegexMask.FioMask) && Regex.IsMatch(_clVm.Surname, RegexMask.FioMask) &&
                    Regex.IsMatch(_clVm.PatronymicName, RegexMask.FioMask) && (_clVm.Age > 1 || _clVm.Age < 100) &&
                    Regex.IsMatch(_clVm.Address, RegexMask.AddressMask) && Regex.IsMatch(_clVm.City, RegexMask.CityMask) &&
                    Regex.IsMatch(_clVm.Phone, RegexMask.PhoneMask) && Regex.IsMatch(_clVm.Mail, RegexMask.MailMask))
                {
                    CommitData();
                    _client.Client.Save();

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
    }
}
