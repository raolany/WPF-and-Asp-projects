using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class NotificationType : DBEntity<NotificationType>
    {
        public NotificationType() : base() { }
        public NotificationType(DataRow dr) : base(dr) { }

        public string Name
        {
            get { return _row["Name"].ToString(); }
            set { _row["Name"] = value; }
        }
        public int Value
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_row["Value"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set { _row["Value"] = value.ToString(); }
        }
    }
}
