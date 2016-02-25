using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClientInGroup : Base<ClientInGroup>
    {
        private Guid _clientId;
        public Client Client
        {
            get { return Client.Items[_clientId]; }
            set { _clientId = value.Id; }
        }

        private Guid _groupId;
        public Group Group
        {
            get { return Group.Items[_groupId]; }
            set { _groupId = value.Id; }
        }
    }
}
