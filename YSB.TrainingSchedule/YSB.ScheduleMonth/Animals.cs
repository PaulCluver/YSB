using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class Animals
    {
        public bool Primary { get; set; }
        public Enums.Animals Animal { get; set; }

        public Animals(Enums.Animals animal, bool primary)
        {
            this.Animal = animal;
            this.Primary = primary;
        }
    }
}