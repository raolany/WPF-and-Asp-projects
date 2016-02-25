namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Group")]
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            GroupClient = new HashSet<GroupClient>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public Guid trainer { get; set; }

        public Guid training { get; set; }

        public int clientmax { get; set; }

        public int clientsnow { get; set; }

        [Required]
        public string description { get; set; }

        public virtual Trainer Trainer1 { get; set; }

        public virtual Training Training1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupClient> GroupClient { get; set; }
    }
}
