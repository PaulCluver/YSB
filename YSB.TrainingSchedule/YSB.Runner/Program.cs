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
            sm.WriteGeneratedScheduleToXML();
        }
    }
}