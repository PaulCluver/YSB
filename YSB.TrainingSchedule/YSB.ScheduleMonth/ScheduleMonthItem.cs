using System;
using System.Collections.Generic;
using System.Globalization;
using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class ScheduleMonthItem
    {
        private DateTime StartDate;
        private Enums.Animals Animal;
        public Dictionary<string, Dictionary<Enums.Animals, DateTime>> ScheduleMonthItems;
        public bool Primary { get; internal set; }

        public ScheduleMonthItem(Enums.Animals animal, bool primary, DateTime startDate)
        {
            this.Animal = animal;
            this.Primary = primary;
            this.StartDate = startDate;
            this.ScheduleMonthItems = new Dictionary<string, Dictionary<Enums.Animals, DateTime>>();
            this.ScheduleMonthItems.Add(string.Format("{0} {1} {2}", this.Animal.ToString(), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month), startDate.Year), new Dictionary<Enums.Animals, DateTime>() { { this.Animal, startDate } });
        }
    }
}