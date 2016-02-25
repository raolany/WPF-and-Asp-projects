using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class WeekDay : Base<WeekDay>
    {
        public List<Training> Trainings
        {
            get
            {
                var res = new List<Training>();
                foreach (TrainingInWeekDay tiwd in TrainingInWeekDay.Items.Values)
                {
                    if (tiwd.WeekDay == this)
                        res.Add(tiwd.Training);
                }
                return res;
            }
        }

        public List<TrainingInWeekDay> TrainingsInWeekDay
        {
            get
            {
                var res = new List<TrainingInWeekDay>();
                foreach (TrainingInWeekDay tiwd in TrainingInWeekDay.Items.Values)
                {
                    if (tiwd.WeekDay == this)
                        res.Add(tiwd);
                }
                return res;
            }
        }


    }
}
