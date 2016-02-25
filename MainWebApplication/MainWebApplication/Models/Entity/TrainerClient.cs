namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainerClient")]
    public partial class TrainerClient
    {
        public Guid id { get; set; }

        public Guid trainer { get; set; }

        public Guid client { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Trainer Trainer1 { get; set; }
    }
}
