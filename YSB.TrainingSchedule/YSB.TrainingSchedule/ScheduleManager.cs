using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            int index = 0;

            foreach (ScheduleMonthItem sm in scheduleMonthContainers)
            {
                index++;
                foreach (KeyValuePair<string, Dictionary<Enums.Animals, DateTime>> pair in sm.ScheduleMonthItems)
                {
                    foreach (KeyValuePair<Enums.Animals, DateTime> vals in pair.Value)
                    {
                        GeneratedSchedule.Add(new ScheduleItem(index, vals.Key, vals.Value, sm.Duration));
                    }
                }
            }
        }

        internal void SaveGeneratedScheduleToFile(Enums.FileTypes csv)
        {
            var csvFile = new StringBuilder();
            foreach (var item in GeneratedSchedule)
            {
                string id = item.ID.ToString();
                string animal = item.Animal.ToString();
                string startDate = item.StartDate.ToShortDateString();
                string endDate = item.EndDate.ToShortDateString();
                string totalDays = item.TotalDays.ToString();
                string doneDays = item.DoneDays.ToString();
                string remainingDays = item.RemainingDays.ToString();
                string totalWeeks = item.TotalWeeks.ToString();
                string doneWeeks = item.DoneWeeks.ToString();
                string remainingWeeks = item.RemainingWeeks.ToString();
                string percentageDone = item.PercentageDone.ToString();
                string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", id, animal, startDate, endDate, totalDays, doneDays, remainingDays, totalWeeks, doneWeeks, remainingWeeks, percentageDone);
                csvFile.AppendLine(newLine);
            }
            File.WriteAllText(@"E:\\Personal\\Programs\\YSB.TrainingSchedule\\YSB.TrainingSchedule\\YSB.GeneratedSchedule\\schedule.csv", csvFile.ToString());
        }
    }
}