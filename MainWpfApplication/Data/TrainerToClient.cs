using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data
{
    public class TrainerToClient : Base<TrainerToClient>
    {
        private Guid _clientId;
        public Client Client
        {
            get { return Client.Items[_clientId]; }
            set { _clientId = value.Id; }
        }

        private Guid _trainerId;
        public Trainer Trainer
        {
            get { return Trainer.Items[_trainerId]; }
            set { _trainerId = value.Id; }
        }

        public void Add(Trainer tr, Client cl)
        {
            _trainerId = tr.Id;
            _clientId = cl.Id;
        }
    }
}
