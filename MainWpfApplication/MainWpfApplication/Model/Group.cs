using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class Group : DBEntity<Group>
    {
        public Group() : base() { }
        public Group(DataRow dr) : base(dr) { }

        public string Name
        {
            get { return _row["Name"].ToString(); }
            set { _row["Name"] = value; }
        }
        public int ClientMax
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_row["Clientmax"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Clientmax"] = value.ToString(); }
        }
        public int ClientsNow
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_row["Clientsnow"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Clientsnow"] = value.ToString(); }
        }
        public Guid Trainer
        {
            get
            {
                try
                {
                    return new Guid(_row["Trainer"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Trainer"] = value; }
        }
        public Guid Training
        {
            get
            {
                try
                {
                    return new Guid(_row["Training"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Training"] = value; }
        }
        public string Description
        {
            get { return _row["Description"].ToString(); }
            set { _row["Description"] = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
