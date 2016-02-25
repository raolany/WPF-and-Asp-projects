using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class User : DBEntity<User>
    {
        static public bool LoginIsFree(string login)
        {
            if(GetByQuery("login = '" + login + "'").Any())
                return false;
            return true;
        }

        public User() : base() { }
        public User(DataRow dr) : base(dr) { }
        
        public string Login {
            get { return _row["LOGIN"].ToString(); }
            set { _row["LOGIN"] = value; }
        }
        public string Password {
            get { return _row["PASSWORD"].ToString(); }
            set { _row["PASSWORD"] = value; }
        }
        public Guid ClientId {
            get
            {
                try
                {
                    return new Guid(_row["CLIENT"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["CLIENT"] = value; }
        }
        public Guid TrainerId {
            get {
                try
                {
                    return new Guid(_row["Trainer"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["TRAINER"] = value; }
        }

        public override string ToString()
        {
            return base.ToString()+" "+Login +" "+Password;
        }
    }
}
