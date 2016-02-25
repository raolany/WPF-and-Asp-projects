using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public enum GenderType { Male, Female }

    public class Trainer : DBEntity<Trainer>
    {
        public Trainer() : base() { }
        public Trainer(DataRow dr) : base(dr) { }

        public string Name {
            get { return _row["NAME"].ToString(); }
            set { _row["NAME"] = value; }
        }
        public string Surname {
            get { return _row["SURNAME"].ToString(); }
            set { _row["SURNAME"] = value; }
        }
        public string PatronymicName {
            get { return _row["PATRONYMICNAME"].ToString(); }
            set { _row["PATRONYMICNAME"] = value; }
        }
        public GenderType Gender {
            get
            {
                try
                {
                    return (_row["GENDER"].Equals("Male")) ? GenderType.Male : GenderType.Female;
                }
                catch
                {
                    return GenderType.Male;
                }
            }
            set { _row["GENDER"] = (value == 0) ? GenderType.Male : GenderType.Female; }
        }
        public string City
        {
            get { return _row["CITY"].ToString(); }
            set { _row["CITY"] = value; }
        }
        public string Address {
            get { return _row["ADDRESS"].ToString(); }
            set { _row["ADDRESS"] = value; }
        }
        public string Phone {
            get { return _row["PHONE"].ToString(); }
            set { _row["PHONE"] = value; }
        }
        public int Age {
            get
            {
                try
                {
                    return Convert.ToInt32(_row["AGE"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["AGE"] = value.ToString(); }
        }
        public string Mail
        {
            get { return _row["MAIL"].ToString(); }
            set { _row["MAIL"] = value; }
        }



        //public Trainer() : this("", "", "", GenderType.Male, 0, "", "", 0) { }

        //public Trainer(string fname, string sname, string patronymicName, GenderType gender, int age, string adress, string phone, int exp)
        //{
        //    Name = fname;
        //    Surname = sname;
        //    PatronymicName = patronymicName;
        //    Gender = gender;
        //    Age = age;
        //    Address = adress;
        //    PhoneNumber = phone;
        //    Expirience = exp;
        //}

        /*public List<Client> Clients
        {
            get
            {
                var res = new List<Client>();
                foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
                    if (ttc.Client == this)
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
                foreach (Group gr in Group.Items.Values)
                    if (gr.Client == this)
                        res.Add(gr);
                return res;
            }
        }

        public List<@group> Trainings
        {
            get
            {
                var res = new List<@group>();
                foreach (@group tr in @group.Items.Values)
                    if (tr.Client == this)
                        res.Add(tr);
                return res;
            }
        }*/

        public override string ToString()
        {
            return Name + " " + Surname + " " + PatronymicName;
        }

    }
}
