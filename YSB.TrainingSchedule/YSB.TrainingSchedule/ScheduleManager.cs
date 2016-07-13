using System;
using System.Collections.Generic;
using YSB.Common;
using YSB.ScheduleMonth;
using YSB.DB;
using System.Linq;

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
                        GeneratedSchedule.Add(new ScheduleItem(vals.Key, vals.Value, sm.Duration));
                    }
                }
            }
        }

        public void SaveGeneratedScheduleToDB()
        {
            Database db = new Database();

            foreach (var item in GeneratedSchedule)
            {
                int animalID = Convert.ToInt32(Enum.GetValues(typeof(Enums.Animals)).Cast<Enums.Animals>().ToList().Where(x => x.ToString().Equals(item.Animal.ToString())).Cast<Int32>().FirstOrDefault());
                DateTime startDate = item.StartDate;
                DateTime endDate = item.EndDate;
                int totalDays = item.TotalDays;
                int doneDays = item.DoneDays;
                int remainingDays = item.RemainingDays;
                double totalWeeks = item.TotalWeeks;
                double doneWeeks = item.DoneWeeks;
                double remainingWeeks = item.RemainingWeeks;
                string percentageDone = item.PercentageDone;
                db.InsertCurriculum(animalID, startDate, endDate, totalDays, doneDays, remainingDays, totalWeeks, doneWeeks, remainingWeeks, percentageDone);

                foreach (var curriculumItem in item.Curriculum)
                {
                    int attackMethodFormID = Convert.ToInt32(Enum.GetValues(typeof(Enums.AnimalAttackMethodForms)).Cast<Enums.AnimalAttackMethodForms>().ToList().Where(x => x.ToString().Equals(curriculumItem.AttackMethodForms.ToString())).Cast<Int32>().FirstOrDefault());
                    int attackMethodsID = Convert.ToInt32(Enum.GetValues(typeof(Enums.AttackMethods)).Cast<Enums.AttackMethods>().ToList().Where(x => x.ToString().Equals(curriculumItem.AttackMethods.ToString())).Cast<Int32>().FirstOrDefault());
                    int standingMethodsID = Convert.ToInt32(Enum.GetValues(typeof(Enums.StandingMethods)).Cast<Enums.StandingMethods>().ToList().Where(x => x.ToString().Equals(curriculumItem.StandingMethods.ToString())).Cast<Int32>().FirstOrDefault());
                    int strategiesID = Convert.ToInt32(Enum.GetValues(typeof(Enums.AnimalStrategies)).Cast<Enums.AnimalStrategies>().ToList().Where(x => x.ToString().Equals(curriculumItem.Strategies.ToString())).Cast<Int32>().FirstOrDefault());
                    int turningMethodsID = Convert.ToInt32(Enum.GetValues(typeof(Enums.TurningMethods)).Cast<Enums.TurningMethods>().ToList().Where(x => x.ToString().Equals(curriculumItem.TurningMethods.ToString())).Cast<Int32>().FirstOrDefault());
                    db.InsertCurriculumItem(attackMethodFormID, attackMethodsID, standingMethodsID, strategiesID, turningMethodsID);
                }
            }
        }
    }
}