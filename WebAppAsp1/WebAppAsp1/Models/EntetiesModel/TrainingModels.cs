using System;
using System.Collections.Generic;
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
                    Hours = training.Minage
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

        public string Name { get; set; }

        public Guid Trainer { get; set; }

        public string TrainerName { get; set; }

        public int Hours { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Minage { get; set; }
    }
}