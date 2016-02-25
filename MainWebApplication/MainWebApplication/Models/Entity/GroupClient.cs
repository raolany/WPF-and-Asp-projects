namespace MainWebApplication.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupClient")]
    public partial class GroupClient
    {
        public Guid id { get; set; }

        public Guid groupid { get; set; }

        public Guid clientid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Group Group { get; set; }
    }
}
