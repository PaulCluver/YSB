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
        private static List<Enums.AnimalAttackMethodForms> AnimalAttackMethodFormsExclusions { get; set; }

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
            List<Enums.AnimalAttackMethodForms> animalAttackMethodFormsExclusions = new List<Enums.AnimalAttackMethodForms>();

            foreach (ScheduleMonthItem sm in scheduleMonthContainers)
            {
                foreach (KeyValuePair<string, Dictionary<Enums.Animals, DateTime>> pair in sm.ScheduleMonthItems)
                {
                    //foreach (var item in this.GeneratedSchedule)
                    //{
                    //    foreach (var curriculumItem in item.Curriculum)
                    //    {
                    //        foreach (var attackMethodForms in curriculumItem.AttackMethodForms)
                    //        {
                    //            animalAttackMethodFormsExclusions.Add(attackMethodForms);
                    //        }
                    //    }
                    //}

                    foreach (KeyValuePair<Enums.Animals, DateTime> vals in pair.Value)
                    {
                        GeneratedSchedule.Add(new ScheduleItem(animalAttackMethodFormsExclusions, vals.Key, vals.Value));
                    }
                }
            }
        }
    }
}