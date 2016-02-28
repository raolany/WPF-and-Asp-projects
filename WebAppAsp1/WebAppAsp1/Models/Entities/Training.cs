using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Name")]
        [Required(ErrorMessage = "Training name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name length must be between 5 and 50")]
        public string Name { get; set; }
        
        public Guid Trainer { get; set; }

        [DisplayName("Training time")]
        [Required(ErrorMessage = "Training time is required")]
        [Range(10, 600, ErrorMessage = "Training time must be beetwen 10 and 600 minuts")]
        public int Hours { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 300")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Training Price is required")]
        [Range(0, 100000, ErrorMessage = "Price must be between 0 and 100000")]
        public double Price { get; set; }

        [DisplayName("Minimum age")]
        [Required(ErrorMessage = "Minimum training age is required")]
        [Range(0, 100, ErrorMessage = "Minimum training age must be between 0 and 100")]
        public int Minage { get; set; }

    }
}