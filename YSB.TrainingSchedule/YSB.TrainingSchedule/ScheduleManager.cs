using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;
using YSB.ScheduleMonth;

namespace YSB.TrainingSchedule
{
    public class ScheduleManager
    {
        public List<ScheduleItem> GeneratedSchedule;

        public ScheduleManager()
        {
            List<ScheduleMonthItem> scheduleMonthContainers = GenerateScheduleMonthContainers();
            GenerateSchedule(scheduleMonthContainers);
        }

        private List<ScheduleMonthItem> GenerateScheduleMonthContainers()
        {
            ScheduleMonthManager smc = new ScheduleMonthManager();
            return smc.ScheduleMonthContainers;
        }

        private void GenerateSchedule(List<ScheduleMonthItem> scheduleMonthContainers)
        {
            GeneratedSchedule = new List<ScheduleItem>();

            foreach (ScheduleMonthItem sm in scheduleMonthContainers)
            {
                foreach (KeyValuePair<string, Dictionary<Enums.Animals, DateTime>> pair in sm.ScheduleMonthItems)
                {
                    foreach (KeyValuePair<Enums.Animals, DateTime> vals in pair.Value)
                    {
                        GeneratedSchedule.Add(new ScheduleItem(vals.Key, vals.Value));
                    }
                }
            }
        }
    }
}