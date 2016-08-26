using System;
using YSB.TrainingSchedule;

namespace YSB.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ScheduleManager sm = new ScheduleManager();
            string line = Console.ReadLine();
            if (line == "1")
            {
                sm.WriteGeneratedScheduleToXML();
            }
            else if (line == "2")
            {
                // Generate data from xml
            }
        }
    }
}