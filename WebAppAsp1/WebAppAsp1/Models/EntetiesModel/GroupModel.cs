using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("Name")]
        [Required(ErrorMessage = "Group name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name length must be between 5 and 50")]
        public string Name { get; set; }

        public Guid Trainer { get; set; }

        [DisplayName("Trainer name")]
        public string TrainerName { get; set; }

        public Guid Training { get; set; }

        [DisplayName("Training name")]
        public string TrainingName { get; set; }

        [DisplayName("Max number of clients")]
        [Required(ErrorMessage = "Max number of clients is required")]
        [Range(0, 100, ErrorMessage = "Max number of clients must be beetwen 0 and 100 minuts")]
        public int Clientmax { get; set; }

        public int Clientsnow { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 300")]
        public string Description { get; set; }

        public ICollection<ShortTrainingModel> AllTrainings { get; set; }

        [Required(ErrorMessage = "Training is required")]
        public Guid SelectedTraining { get; set; }
    }


}