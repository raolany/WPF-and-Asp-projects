using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("GroupClient")]
    public class GroupClient
    {
        public Guid Id { get; set; }

        public Guid Groupid { get; set; }

        public Guid Clientid { get; set; }
    }
}