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
    public class EditTrainerProfileVM : ViewModelBase
    { 
        private TrainerVM _trainer;
        private TrainerVM _trVm;

        public EditTrainerProfileVM(TrainerVM trainer)
        {
            _trainer = trainer;
            InitilizeData();
        }

        public TrainerVM TrainerVm
        {
            get { return _trVm; }
        }

        private void InitilizeData()
        {
            _trVm = new TrainerVM(new Trainer())
            {
                Name = _trainer.Name,
                Surname = _trainer.Surname,
                PatronymicName = _trainer.PatronymicName,
                Gender = _trainer.Gender,
                City = _trainer.City,
                Address = _trainer.Address,
                Phone = _trainer.Phone,
                Mail = _trainer.Mail,
                Age = _trainer.Age
            };
        }

        private void CommitData()
        {
            _trainer.Name = _trVm.Name;
            _trainer.Surname = _trVm.Surname;
            _trainer.PatronymicName = _trVm.PatronymicName;
            _trainer.Gender = _trVm.Gender;
            _trainer.City = _trVm.City;
            _trainer.Address = _trVm.Address;
            _trainer.Phone = _trVm.Phone;
            _trainer.Age = _trVm.Age;
            _trainer.Mail = _trVm.Mail;
        }

        public bool BtnSaveOnClick()
        {
            try
            {
                if (Regex.IsMatch(_trVm.Name, RegexMask.FioMask) && Regex.IsMatch(_trVm.Surname, RegexMask.FioMask) &&
                    Regex.IsMatch(_trVm.PatronymicName, RegexMask.FioMask) && (_trVm.Age > 1 || _trVm.Age < 100) &&
                    Regex.IsMatch(_trVm.Address, RegexMask.AddressMask) && Regex.IsMatch(_trVm.City, RegexMask.CityMask) &&
                    Regex.IsMatch(_trVm.Phone, RegexMask.PhoneMask) && Regex.IsMatch(_trVm.Mail, RegexMask.MailMask))
                {
                    CommitData();
                    _trainer.Trainer.Save();
                      
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
