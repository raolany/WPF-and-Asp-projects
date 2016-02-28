using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class Notification : DBEntity<Notification>
    {
        public Notification() : base() { }
        public Notification(DataRow dr) : base(dr) { }
        
        public string Msg
        {
            get { return _row["Msg"].ToString(); }
            set { _row["Msg"] = value; }
        }
        public string Time
        {
            get { return _row["Time"].ToString(); }
            set { _row["Time"] = value; }
        }
        public Guid TypeId
        {
            get
            {
                try
                {
                    return new Guid(_row["Type"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Type"] = value; }
        }
        public Guid SenderId
        {
            get
            {
                try
                {
                    return new Guid(_row["Sender"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Sender"] = value; }
        }
        public Guid ReceiverId
        {
            get
            {
                try
                {
                    return new Guid(_row["Receiver"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Receiver"] = value; }
        }
        public bool Status
        {
            get
            {
                if(Int32.Parse(_row["Status"].ToString()) == 0)
                    return false;
                return true;
            }
            set { _row["Status"] = value; }
        }
        public bool Sended
        {
            get
            {
                if (bool.Parse(_row["Sended"].ToString()) == true)
                    return false;
                return true;
            }
            set { _row["Sended"] = value; }
        }
        public Guid TrainingId
        {
            get
            {
                try
                {
                    return new Guid(_row["Trainingid"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Trainingid"] = value; }
        }
        public Guid GroupId
        {
            get
            {
                try
                {
                    return new Guid(_row["Groupid"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Groupid"] = value; }
        }
    }
}
