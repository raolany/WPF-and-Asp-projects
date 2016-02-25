using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.Model;
using MainWpfApplication.ViewModel.Data;

namespace MainWpfApplication.ViewModel
{
    //delete
    public class TrainersListVM : ViewModelBase
    {
        private ObservableCollection<TrainerVM> _trainersMainCollection = new ObservableCollection<TrainerVM>();
        private TrainerVM _selectedTrainerMain;

        public TrainersListVM()
        {
            LoadData();
        }

        public ObservableCollection<TrainerVM> TrainersMainCollection
        {
            get { return _trainersMainCollection; }
        }

        public TrainerVM SelectedTrainerMain
        {
            get { return _selectedTrainerMain; }
            set
            {
                _selectedTrainerMain = value;
                //_trainerInfoControlVm.SetTrainer(_selectedTrainerMain);

                //OnPropertyChanged("SelectedMainMan");
                //OnPropertyChanged("Name");
                //OnPropertyChanged("PatronymicName");
                //OnPropertyChanged("Surname");
            }
        }

        //public string Name
        //{
        //    get { return _selectedTrainerMain == null ? string.Empty : _selectedTrainerMain.Name; }
        //    set
        //    {
        //        if (_selectedTrainerMain == null)
        //            return;
        //        _selectedTrainerMain.Name = value;
        //    }
        //}

        //public string PatronymicName
        //{
        //    get { return _selectedTrainerMain == null ? string.Empty : _selectedTrainerMain.PatronymicName; }
        //    set
        //    {
        //        if (_selectedTrainerMain == null)
        //            return;
        //        _selectedTrainerMain.PatronymicName = value;
        //    }
        //}

        //public string Surname
        //{
        //    get { return _selectedTrainerMain == null ? string.Empty : _selectedTrainerMain.Surname; }
        //    set
        //    {
        //        if (_selectedTrainerMain == null)
        //            return;
        //        _selectedTrainerMain.Surname = value;
        //    }
        //}

        private void LoadData()
        {
            _trainersMainCollection.Clear();
            foreach (var tr in Trainer.AllItems)
                _trainersMainCollection.Add(new TrainerVM(tr));
        }
    }
}
