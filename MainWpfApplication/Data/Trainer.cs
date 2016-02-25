using System;
using System.Collections.Generic;

namespace Data
{
    public enum GenderType { Male, Female }

    public class Trainer : Base<Trainer>, IMan
    {
        public string Surname { get; set; }
        public string PatronymicName { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public int Expirience { get; set; }

        public Trainer() : this("", "", "", GenderType.Male, 0, "", "", 0) { }

        public Trainer(string fname, string sname, string patronymicName, GenderType gender, int age, string adress, string phone, int exp)
        {
            Name = fname;
            Surname = sname;
            PatronymicName = patronymicName;
            Gender = gender;
            Age = age;
            Address = adress;
            PhoneNumber = phone;
            Expirience = exp;
        }

        public List<Client> Clients
        {
            get
            {
                var res = new List<Client>();
                foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
                    if (ttc.Trainer == this)
                        res.Add(ttc.Client);
                return res;
            }
        }

        public List<TrainerToClient> TrainerToClients
        {
            get
            {
                var res = new List<TrainerToClient>();
                foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
                    if (ttc.Trainer == this)
                        res.Add(ttc);
                return res;
            }
        }

        public List<Group> Groups
        {
            get
            {
                var res = new List<Group>();
                foreach (Group gr in Group.Items.Values)
                    if (gr.Trainer == this)
                        res.Add(gr);
                return res;
            }
        }

        public List<Training> Trainings
        {
            get
            {
                var res = new List<Training>();
                foreach (Training tr in Training.Items.Values)
                    if (tr.Trainer == this)
                        res.Add(tr);
                return res;
            }
        }

        public override string ToString()
        {
            return Name + " "+Surname;
        }

    }
}
