using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data
{
    public class Client :  Base<Client>, IMan
    {
        public string Surname { get; set; }
        public string PatronymicName { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public string Insurance { get; set; }

        public Client() : this("", "", "", GenderType.Male, 0, "", "", "") { }

        public Client(string fname, string sname, string patronymicName, GenderType gender, int age, string adress, string phone, string insurance)
        {
            Name = fname;
            Surname = sname;
            PatronymicName = patronymicName;
            Gender = gender;
            Age = age;
            Address = adress;
            PhoneNumber = phone;
            Insurance = insurance;
        }

        public List<Trainer> Trainers
        {
            get
            {
                var res = new List<Trainer>();
                foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
                    if (ttc.Client == this)
                        res.Add(ttc.Trainer);
                return res;
            }
        }

        public List<TrainerToClient> TrainersToClient
        {
            get
            {
                var res = new List<TrainerToClient>();
                foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
                    if (ttc.Client == this)
                        res.Add(ttc);
                return res;
            }
        }

        public List<Group> Groups
        {
            get
            {
                var res = new List<Group>();
                foreach (ClientInGroup cig in ClientInGroup.Items.Values)
                    if (cig.Client == this)
                        res.Add(cig.Group);
                return res;
            }
        }

        public List<ClientInGroup> ClientInGroups
        {
            get
            {
                var res = new List<ClientInGroup>();
                foreach (ClientInGroup cig in ClientInGroup.Items.Values)
                    if (cig.Client == this)
                        res.Add(cig);
                return res;
            }
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
