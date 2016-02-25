using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models.EntetiesModel
{
    public class TrainerModel
    {
        public static TrainerModel Init(ApplicationDbContext db, Guid id)
        {
            var tr = db.Trainer.First(t => (t.Id == id));

            var trainings = db.Training.Where(t => (t.Trainer == id));
            List<TrainingModel> trainingsModel = new List<TrainingModel>();
            foreach (var training in trainings)
            {
                trainingsModel.Add(new TrainingModel()
                {
                    Id = training.Id,
                    Name = training.Name,
                    Trainer = training.Trainer,
                    TrainerName = tr.Surname + " " + tr.Name,
                    Description = training.Description,
                    Price = training.Price,
                    Minage = training.Minage,
                    Hours = training.Minage
                });
            }

            var groups = db.Group.Where(t => (t.Trainer == id));
            List<GroupModel> groupsModel = new List<GroupModel>();
            foreach (var group in groups)
            {
                groupsModel.Add(new GroupModel()
                {
                    Id = group.Id,
                    Name = group.Name,
                    Clientmax = group.Clientmax,
                    Description = group.Description,
                    Trainer = id,
                    TrainerName = tr.Surname + " " + tr.Name,
                    Training = group.Training,
                    TrainingName = db.Training.First(t => (t.Id == group.Training)).Name,
                    Clientsnow = group.Clientsnow
                });
            }

            TrainerModel model = new TrainerModel()
            {
                Trainer = tr,
                Trainings = trainingsModel,
                Groups = groupsModel
            };

            return model;
        }

        public Trainer Trainer { get; set; }

        public IEnumerable<TrainingModel> Trainings { get; set; }

        public IEnumerable<GroupModel> Groups { get; set; }
    }
}