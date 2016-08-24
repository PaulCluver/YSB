using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class ScheduleMonthManager
    {
        public List<ScheduleMonthItem> ScheduleMonthContainers { get; internal set; }

        public ScheduleMonthManager()
        {
            this.ScheduleMonthContainers = new List<ScheduleMonthItem>();
            List<Animals> animals = GetAnimals();
            DateTime startDate = new DateTime(2016, 09, 01);

            for (int i = 0; i < ((Enum.GetNames(typeof(Enums.AnimalAttackMethodForms)).Length) / (Enum.GetNames(typeof(Enums.AnimalStrategies)).Length)); i++)
            {
                List<Animals> filteredAnimals = animals.Where(x => x.Animal.Equals(Enums.Animals.Lion).Equals(false)).Cast<Animals>().ToList();
                startDate = GetStartDate(i, startDate);
                this.ScheduleMonthContainers.Add(new ScheduleMonthItem(filteredAnimals.FirstOrDefault().Animal, animals.FirstOrDefault().Primary, startDate, 4));
                animals = PopTheAnimal(filteredAnimals);
            }
        }

        private static DateTime GetStartDate(int index, DateTime startDate)
        {
            if (index > 0)
            {
                startDate = startDate.AddMonths(4);
            }
            return startDate;
        }

        private static List<Animals> PopTheAnimal(List<Animals> animals)
        {
            animals.Remove(animals.FirstOrDefault());

            if (animals.Count() == 0)
            {
                animals = GetAnimals();
            }

            return animals;
        }

        private static List<Animals> GetAnimals()
        {
            List<Animals> animals = new List<Animals>();
            foreach (Enums.Animals animal in Enum.GetValues(typeof(Enums.Animals)))
            {
                if (animal == Enums.Animals.Lion)
                {
                    animals.Add(new Animals(animal, true));
                }
                else
                {
                    animals.Add(new Animals(animal, false));
                }
            }

            return animals;
        }
    }
}