using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class TrainingInWeekDay : Base<TrainingInWeekDay>
    {
        private Guid _weekDayId;
        public WeekDay WeekDay
        {
            get { return WeekDay.Items[_weekDayId]; }
            set { _weekDayId = value.Id; }
        }

        private Guid _trainingId;
        public Training Training
        {
            get { return Training.Items[_trainingId]; }
            set { _trainingId = value.Id; }
        }
    }
}
