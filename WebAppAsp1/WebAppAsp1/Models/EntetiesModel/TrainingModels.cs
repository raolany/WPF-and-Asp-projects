using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models.EntetiesModel
{
    public class ShortTrainingModel
    {
        public static List<ShortTrainingModel> Init(IEnumerable<Training> trainings)
        {
            List<ShortTrainingModel> list = new List<ShortTrainingModel>();
            foreach (var training in trainings)
            {
                list.Add(new ShortTrainingModel()
                {
                    Id = training.Id,
                    Name = training.Name
                });
            }
            return list;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class TrainingModel
    {
        public static List<TrainingModel> InitTrainings(ApplicationDbContext db, IEnumerable<Training> trainings)
        {
            var model = new List<TrainingModel>();
            foreach (var training in trainings)
            {
                var trainer = db.Trainer.First(t => (t.Id == training.Trainer));
                model.Add(new TrainingModel()
                {
                    Id = training.Id,
                    Name = training.Name,
                    Trainer = training.Trainer,
                    TrainerName = trainer.Surname + " " + trainer.Name,
                    Description = training.Description,
                    Price = training.Price,
                    Minage = training.Minage,
                    Hours = training.Hours
                });
            }
            return model;
        }

        public static TrainingModel InitTraining(ApplicationDbContext db, Guid id)
        {
            var training = db.Training.First(t => (t.Id == id));
            var trainer = db.Trainer.First(t => (t.Id == training.Trainer));

            var model = new TrainingModel()
            {
                Id = training.Id,
                Trainer = trainer.Id,
                TrainerName = trainer.Surname + " " + trainer.Name,
                Name = training.Name,
                Hours = training.Hours,
                Price = training.Price,
                Minage = training.Minage,
                Description = training.Description
            };
            return model;
        }

        public Guid Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Training name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name length must be between 5 and 50")]
        public string Name { get; set; }

        public Guid Trainer { get; set; }

        [DisplayName("Trainer Name")]
        public string TrainerName { get; set; }

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
        [Required(ErrorMessage = "Minimum age is required")]
        [Range(0, 100, ErrorMessage = "Minimum training age must be between 0 and 100")]
        public int Minage { get; set; }
    }
}