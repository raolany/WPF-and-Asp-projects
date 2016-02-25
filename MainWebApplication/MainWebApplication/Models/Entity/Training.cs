namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Training")]
    public partial class Training
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Training()
        {
            Group = new HashSet<Group>();
            TrainingClient = new HashSet<TrainingClient>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public Guid trainer { get; set; }

        public int hours { get; set; }

        [Required]
        public string description { get; set; }

        public double price { get; set; }

        public int minage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Group { get; set; }

        public virtual Trainer Trainer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingClient> TrainingClient { get; set; }
    }
}
