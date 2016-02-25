using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("Group")]
    public  class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Trainer { get; set; }

        public Guid Training { get; set; }

        public int Clientmax { get; set; }

        public int Clientsnow { get; set; }
        
        public string Description { get; set; }
        
    }
}