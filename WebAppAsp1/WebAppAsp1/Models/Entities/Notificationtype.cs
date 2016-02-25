using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("Notificationtype")]
    public partial class Notificationtype
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int Value { get; set; }
    }
}