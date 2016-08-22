using System;
using System.Diagnostics;
using YSB.Common;
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
                foreach (var curriculumItem in item.Curriculum)
                {
                    foreach (var attackMethodForm in curriculumItem.AttackMethodForms)
                    {
                        
                    }
                }                
            }
            sm.SaveGeneratedScheduleToDB();
        }

        
    }
}