using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWpfApplication.DL;

namespace MainWpfApplication.Model
{
    public class GroupClient : DBEntity<GroupClient>
    {
        public GroupClient() : base() { }
        public GroupClient(DataRow dr) : base(dr) { }

        public Guid ClientId
        {
            get
            {
                try
                {
                    return new Guid(_row["ClientId"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["ClientId"] = value; }
        }
        public Guid GroupId
        {
            get
            {
                try
                {
                    return new Guid(_row["GroupId"].ToString());
                }
                catch
                {
                    return Guid.Empty;
                }
            }
            set { _row["GroupId"] = value; }
        }
    }
}
