using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppAsp1.Models.Entities;

namespace WebAppAsp1.Models.EntetiesModel
{
    public class GroupModel
    {
        public static List<GroupModel> InitGroups(ApplicationDbContext db, IEnumerable<Group> groups)
        {
            List<GroupModel> list = new List<GroupModel>();
            foreach (var gr in groups)
            {
                var trainer = db.Trainer.First(t => (t.Id == gr.Trainer));
                list.Add(new GroupModel()
                {
                    Id = gr.Id,
                    Name = gr.Name,
                    Trainer = gr.Trainer,
                    TrainerName = trainer.Surname + " " + trainer.Name,
                    Training = gr.Training,
                    TrainingName = ((Training)db.Training.First(t => (t.Id == gr.Training))).Name,
                    Clientmax = gr.Clientmax,
                    Clientsnow = gr.Clientsnow,
                    Description = gr.Description
                });
            }

            return list;
        }

        public static GroupModel InitGroup(ApplicationDbContext db, Group gr)
        {
            var trainer = db.Trainer.First(t => (t.Id == gr.Trainer));
            var group = new GroupModel()
            {
                Id = gr.Id,
                Name = gr.Name,
                Trainer = gr.Trainer,
                TrainerName = trainer.Surname + " " + trainer.Name,
                Training = gr.Training,
                TrainingName = ((Training)db.Training.First(t => (t.Id == gr.Training))).Name,
                Clientmax = gr.Clientmax,
                Clientsnow = gr.Clientsnow,
                Description = gr.Description
            };

            return group;
        }

        public static GroupModel InitEditGroupModel(Group group, List<ShortTrainingModel> list)
        {
            var gr = new GroupModel()
            {
                Id = group.Id,
                Name = group.Name,
                Clientmax = group.Clientmax,
                Description = group.Description,
                AllTrainings = list,
                SelectedTraining = group.Training
            };

            return gr;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Trainer { get; set; }

        public String TrainerName { get; set; }

        public Guid Training { get; set; }

        public String TrainingName { get; set; }

        public int Clientmax { get; set; }

        public int Clientsnow { get; set; }

        public string Description { get; set; }

        public ICollection<ShortTrainingModel> AllTrainings { get; set; }

        public Guid SelectedTraining { get; set; }
    }


}