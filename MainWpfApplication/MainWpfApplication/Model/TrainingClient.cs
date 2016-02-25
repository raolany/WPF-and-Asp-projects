using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class TrainingClient : DBEntity<TrainingClient>
    {
        public TrainingClient() : base() { }
        public TrainingClient(DataRow dr) : base(dr) { }

        public Guid ClientId
        {
            get
            {
                try
                {
                    return new Guid(_row["Client"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["Client"] = value; }
        }
        public Guid TrainingId
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
    }
}
