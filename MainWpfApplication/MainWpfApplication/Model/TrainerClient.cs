using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class TrainerClient : DBEntity<TrainerClient>
    {
        public TrainerClient() : base() { }
        public TrainerClient(DataRow dr) : base(dr) { }

        public Guid ClientId
        {
            get
            {
                return new Guid(_row["CLIENT"].ToString());
            }
            set { _row["CLIENT"] = value; }
        }
        public Guid TrainerId
        {
            get
            {
                return new Guid(_row["TRAINER"].ToString());
            }
            set { _row["TRAINER"] = value; }
        }
    }
}
