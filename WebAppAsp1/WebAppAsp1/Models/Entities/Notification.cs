using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("Notification")]
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid Type { get; set; }
        
        public string Msg { get; set; }

        public bool Status { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }
        
        public string Time { get; set; }

        public Guid? Trainingid { get; set; }

        public Guid? Groupid { get; set; }
    }
}