using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebAppAsp1.Models.Entities
{
    [Table("Training")]
    public class Training
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public Guid Trainer { get; set; }

        public int Hours { get; set; }
        
        public string Description { get; set; }

        public double Price { get; set; }

        public int Minage { get; set; }

    }
}