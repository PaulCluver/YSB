using System;
using System.Diagnostics;
using YSB.TrainingSchedule;

namespace YSB.Runner
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            ScheduleManager sm = new ScheduleManager();
            foreach (var item in sm.GeneratedSchedule)
            {
                string message = string.Format("Animal: {0}\nStart Date: {1}\nEnd Date: {2}\nDone Days: {3}\nRemaining Days: {4}\nTotal Days: {5}\nTotal Weeks: {6}\nPercentage Done:{7}\n", item.Animal, item.StartDate, item.EndDate, item.DoneDays, item.RemainingDays, item.TotalDays, item.TotalWeeks, item.PercentageDone);
                foreach (var curriculumItem in item.Curriculum)
                {
                    int i = 0;
                    message += "Curriculum Items: \n";
                    foreach (var attackMethod in curriculumItem.AttackMethodForms)
                    {
                        i++;
                        message += string.Format("{0} {1}\n", i, attackMethod);
                    }

                    message += string.Format("\n\n");
                }
                Debug.WriteLine(message);
            }
        }
    }
}