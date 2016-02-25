using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Notification = new HashSet<Notification>();
            Notification1 = new HashSet<Notification>();
        }

        public Guid Id { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Login is required")]
        [StringLength(25, ErrorMessage = "Login length must be between 3 and 25", MinimumLength = 3)]
        [RegularExpression(@"[a-z0-9]", ErrorMessage = "Enter valid login with latin letters and digits")]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid? Client { get; set; }

        public Guid? Trainer { get; set; }

        public virtual Client Client1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notification1 { get; set; }

        public virtual Trainer Trainer1 { get; set; }
    }
}
