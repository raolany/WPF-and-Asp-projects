using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("TrainingClient")]
    public class TrainingClient
    {
        public Guid Id { get; set; }

        public Guid Training { get; set; }

        public Guid Client { get; set; }
    }
}