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
    public class ClientsListVM : ViewModelBase
    {
        private ObservableCollection<ClientVM> _clientsMainCollection = new ObservableCollection<ClientVM>();
        private ClientVM _selectedClientMain;

        public ClientsListVM()
        {
            LoadData();
        }

        public ObservableCollection<ClientVM> ClientsMainCollection
        {
            get { return _clientsMainCollection; }
        }

        public ClientVM SelectedClientMain
        {
            get { return _selectedClientMain; }
            set
            {
                _selectedClientMain = value;

                OnPropertyChanged("SelectedMainMan");
                /*OnPropertyChanged("FirstName");
                OnPropertyChanged("PatronymicName");
                OnPropertyChanged("SecondName");*/
            }
        }

        private void LoadData()
        {
            _clientsMainCollection.Clear();

            foreach (var cl in Client.AllItems)
                _clientsMainCollection.Add(new ClientVM(cl));
        }
    }
}
