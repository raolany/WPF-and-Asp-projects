using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("User")]
    public  class User
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        public Guid? Client { get; set; }

        public Guid? Trainer { get; set; }

        //public virtual Client Client1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Notification> Notification { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Notification> Notification1 { get; set; }

        //public virtual Trainer Trainer1 { get; set; }

        public virtual ApplicationUser User1 { get; set; }
        public string ApplicationUserId { get; set; }
    }
}