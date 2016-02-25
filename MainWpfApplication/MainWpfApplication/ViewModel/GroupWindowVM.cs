using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using MainWpfApplication.Core;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;
using Group = MainWpfApplication.Model.Group;

namespace MainWpfApplication.ViewModel
{
    public class GroupWindowVM : ViewModelBase
    {
        private GroupVM _tempGroupVm;
        private GroupVM _groupVm;

        private List<TrainingVM> TrainingList { get; set; }
        private CollectionView _trainings;
        private TrainingVM _selectedTraining;

        public GroupWindowVM(List<TrainingVM> trainings, Guid trId)
        {
            TrainingList = trainings;
            _trainings = new CollectionView(trainings);
            _groupVm = new GroupVM(new Group())
            {
                TrainerId = trId
            };
            InitilizeData();
        }

        public GroupWindowVM(List<TrainingVM> trainings, GroupVM group)
        {
            TrainingList = trainings;
            _trainings = new CollectionView(trainings);
            _groupVm = group;
            InitilizeData();
        }

        public GroupVM GroupVm => _tempGroupVm;

        public CollectionView Trainings
        {
            get { return _trainings; }
        }

        public TrainingVM Training
        {
            get { return _selectedTraining; }
            set
            {
                _selectedTraining = value;
                OnPropertyChanged("Training");
            }
        }

        private void InitilizeData()
        {
            _tempGroupVm = new GroupVM(new Group())
            {
                Name = _groupVm.Name,
                ClientMax = _groupVm.ClientMax,
                ClientsNow = _groupVm.ClientsNow,
                Description = _groupVm.Description,
                TrainingId = _groupVm.TrainingId
            };
        }

        private void CommitData()
        {
            _groupVm.Name = _tempGroupVm.Name;
            _groupVm.ClientMax = _tempGroupVm.ClientMax;
            _groupVm.Description = _tempGroupVm.Description;
            _groupVm.TrainingId = Training.Training.Id;
            _groupVm.ClientsNow = _tempGroupVm.ClientsNow;
        }

        public void BtnCloseClick()
        {
        }

        public bool BtnSaveOnClick()
        {
            try
            {
                if (Regex.IsMatch(_tempGroupVm.Description, RegexMask.Text) && (_tempGroupVm.ClientMax >= 2 || _tempGroupVm.ClientMax < 30) &&
                    Training != null && Regex.IsMatch(_tempGroupVm.Name, RegexMask.Name))
                {
                    CommitData();
                    _groupVm.Group.Save();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("GroupWindowVM", ex.Message);
                return false;
            }
        }
    }
}
