using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class Training : DBEntity<Training>
    {
        public Training() : base() { }
        public Training(DataRow dr) : base(dr) { }

        public string Name
        {
            get { return _row["Name"].ToString(); }
            set { _row["Name"] = value; }
        }
        public int Hours
        {
            get
            {
                try
                {
                    return Int32.Parse(_row["Hours"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Hours"] = value; }
        }
        public string Description
        {
            get { return _row["Description"].ToString(); }
            set { _row["Description"] = value; }
        }
        public Guid TrainerId
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
        public double Price
        {
            get {
                try
                {
                    return Double.Parse(_row["Price"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Price"] = value; }
        }
        public int MinAge
        {
            get {
                try
                {
                    return Int32.Parse(_row["Minage"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Minage"] = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
