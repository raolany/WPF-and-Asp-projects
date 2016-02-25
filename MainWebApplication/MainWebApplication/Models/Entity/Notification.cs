namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public Guid id { get; set; }

        public Guid type { get; set; }

        [Required]
        public string msg { get; set; }

        public bool status { get; set; }

        public Guid sender { get; set; }

        public Guid receiver { get; set; }

        [Required]
        [StringLength(50)]
        public string time { get; set; }

        public Guid? trainingid { get; set; }

        public Guid? groupid { get; set; }

        public virtual Notificationtype Notificationtype { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
