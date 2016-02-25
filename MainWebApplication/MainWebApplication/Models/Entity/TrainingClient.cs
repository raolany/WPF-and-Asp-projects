namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingClient")]
    public partial class TrainingClient
    {
        public Guid id { get; set; }

        public Guid training { get; set; }

        public Guid client { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Training Training1 { get; set; }
    }
}
