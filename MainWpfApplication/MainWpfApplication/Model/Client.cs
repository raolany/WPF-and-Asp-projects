using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class Client : DBEntity<Client>
    {
        public Client() : base() { }
        public Client(DataRow dr) : base(dr) { }

        public string Name
        {
            get { return _row["NAME"].ToString(); }
            set { _row["NAME"] = value; }
        }
        public string Surname
        {
            get { return _row["SURNAME"].ToString(); }
            set { _row["SURNAME"] = value; }
        }
        public string PatronymicName
        {
            get { return _row["PATRONYMICNAME"].ToString(); }
            set { _row["PATRONYMICNAME"] = value; }
        }
        public GenderType Gender
        {
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
        public string Address
        {
            get { return _row["ADDRESS"].ToString(); }
            set { _row["ADDRESS"] = value; }
        }
        public string Phone
        {
            get { return _row["PHONE"].ToString(); }
            set { _row["PHONE"] = value; }
        }
        public int Age
        {
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

        //public List<Client> Trainers
        //{
        //    get
        //    {
        //        var res = new List<Client>();
        //        foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
        //            if (ttc.Client == this)
        //                res.Add(ttc.Client);
        //        return res;
        //    }
        //}

        //public List<TrainerToClient> TrainersToClient
        //{
        //    get
        //    {
        //        var res = new List<TrainerToClient>();
        //        foreach (TrainerToClient ttc in TrainerToClient.Items.Values)
        //            if (ttc.Client == this)
        //                res.Add(ttc);
        //        return res;
        //    }
        //}

        

        //public List<ClientInGroup> ClientInGroups
        //{
        //    get
        //    {
        //        var res = new List<ClientInGroup>();
        //        foreach (ClientInGroup cig in ClientInGroup.Items.Values)
        //            if (cig.Client == this)
        //                res.Add(cig);
        //        return res;
        //    }
        //}

        public override string ToString()
        {
            return Name + " " + Surname + " "+PatronymicName;
        }
    }
}

