using System;
using System.Collections.Generic;
using System.Globalization;
using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class ScheduleMonthItem
    {
        private DateTime StartDate;
        public int Duration { get; set; }
        private Enums.Animals Animal;
        public Dictionary<string, Dictionary<Enums.Animals, DateTime>> ScheduleMonthItems;
        public bool Primary { get; internal set; }

        public ScheduleMonthItem(Enums.Animals animal, bool primary, DateTime startDate, int duration)
        {
            this.Animal = animal;
            this.Primary = primary;
            this.StartDate = startDate;
            this.Duration = duration;
            this.ScheduleMonthItems = new Dictionary<string, Dictionary<Enums.Animals, DateTime>>();
            this.ScheduleMonthItems.Add(string.Format("{0} {1} {2}", animal.ToString(), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month), startDate.Year), new Dictionary<Enums.Animals, DateTime>() { { animal, startDate } });
        }
    }
}