using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Data
{
    public enum TrainingType { Fitness, Cardio, Strength, Dance }

    public class Training : Base<Training>
    {
        public TrainingType Type;
        public DateTime Time;

        private Guid _trainerId;
        public Trainer Trainer
        {
            get 
            {
                foreach (Trainer tr in Trainer.Items.Values)
                {
                    if (tr.Id == _trainerId)
                        return tr;
                }
                return null;
            }
            set { _trainerId = value.Id; }
        }

        public List<Group> Groups
        {
            get
            {
                var res = new List<Group>();
                foreach (Group group in Group.Items.Values)
                {
                    if (group.Training == this)
                        res.Add(group);
                }
                return res;
            }
        }

        public List<WeekDay> WeekDays
        {
            get
            {
                var res = new List<WeekDay>();
                foreach (TrainingInWeekDay tiwd in TrainingInWeekDay.Items.Values)
                {
                    if (tiwd.Training == this)
                        res.Add(tiwd.WeekDay);
                }
                return res;
            }
        }

        public List<TrainingInWeekDay> TrainingInWeekDays
        {
            get
            {
                var res = new List<TrainingInWeekDay>();
                foreach (TrainingInWeekDay tiwd in TrainingInWeekDay.Items.Values)
                {
                    if (tiwd.Training == this)
                        res.Add(tiwd);
                }
                return res;
            }
        }


    }
}
