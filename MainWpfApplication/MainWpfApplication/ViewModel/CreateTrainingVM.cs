using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel
{
    public class CreateTrainingVM
    {
        private TrainingVM _training;
        private TrainingVM _tempTrainingVm;

        public CreateTrainingVM(Guid trId)
        {
            _training = new TrainingVM(new Training())
            {
                TrainerId = trId
            };
            InitilizeData();
        }

        public CreateTrainingVM(TrainingVM training)
        {
            _training = training;
            InitilizeData();
        }

        public TrainingVM TrainingVm => _tempTrainingVm;

        private void InitilizeData()
        {
            _tempTrainingVm = new TrainingVM(new Training())
            {
                Name = _training.Name,
                Description = _training.Description,
                Hours = _training.Hours,
                MinAge = _training.MinAge,
                TrainerId = _training.TrainerId,
                Price = _training.Price
            };
        }

        private void CommitData()
        {
            _training.Name = _tempTrainingVm.Name;
            _training.Description = _tempTrainingVm.Description;
            _training.Hours = _tempTrainingVm.Hours;
            _training.MinAge = _tempTrainingVm.MinAge;
            _training.TrainerId = _tempTrainingVm.TrainerId;
            _training.Price = _tempTrainingVm.Price;
        }

        public void BtnCloseClick()
        {
        }

        public bool BtnSaveOnClick()
        {
            try
            {
                if (Regex.IsMatch(_tempTrainingVm.Name, RegexMask.Name) && Regex.IsMatch(_tempTrainingVm.Description, RegexMask.Text) &&
                    (_tempTrainingVm.Hours >= 1 || _tempTrainingVm.Hours < 1000) && (_tempTrainingVm.MinAge >= 1 || _tempTrainingVm.MinAge < 100) &&
                    (_tempTrainingVm.Price >= 0 || _tempTrainingVm.Price < 10000))
                {
                    CommitData();
                    _training.Training.Save();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("CreateTrainingVM", ex.Message);
                return false;
            }
        }
    }
}
