using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data
{
    public class Group : Base<Group>
    {
        private Guid _trainerId;
        public Trainer Trainer
        {
            get { return Trainer.Items[_trainerId]; }
            set { _trainerId = value.Id; }
        }

        private Guid _trainingId;
        public Training Training
        {
            get { return Training.Items[_trainingId]; }
            set { _trainingId = value.Id; }
        }

        public List<Client> Clients
        {
            get
            {
                var res = new List<Client>();
                foreach (ClientInGroup cig in ClientInGroup.Items.Values)
                    if (cig.Group == this)
                        res.Add(cig.Client);
                return res;
            }
        }

        public List<ClientInGroup> ClientsInGroup
        {
            get
            {
                var res = new List<ClientInGroup>();
                foreach (ClientInGroup cig in ClientInGroup.Items.Values)
                    if (cig.Group == this)
                        res.Add(cig);
                return res;
            }
        }
    }
}
