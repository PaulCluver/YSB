using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.Curriculum
{
    public class CurriculumManager : List<CurriculumItem>
    {
        private Enums.Animals Animal;
        public List<CurriculumItem> GeneratedCurriculum { get; internal set; }
        public List<Enums.AnimalStrategies> AnimalStrategies { get; internal set; }

        public CurriculumManager(Enums.Animals animal)
        {
            this.Animal = animal;
            this.GeneratedCurriculum = new List<CurriculumItem>();

            GeneratedCurriculum.Add(new CurriculumItem(this.Animal, GetAnimalAttackMethods(this.Animal), GetAnimalTurningMethods(this.Animal), GetAnimalStandingMethods(this.Animal), GetAnimalAttackMethodForms(new Random(), this.Animal), GetAnimalStrategies(this.Animal)));
        }

        private List<Enums.AnimalStrategies> GetAnimalStrategies(Enums.Animals animal)
        {
            this.AnimalStrategies = Enum.GetValues(typeof(Enums.AnimalStrategies)).Cast<Enums.AnimalStrategies>().ToList();
            int indexOfAnimal = this.AnimalStrategies.FindIndex(x => x.ToString().Contains(animal.ToString()));
            this.AnimalStrategies.RemoveAt(indexOfAnimal);

            return this.AnimalStrategies;
        }

        private List<Enums.AnimalAttackMethodForms> GetAnimalAttackMethodForms(Random rand, Enums.Animals animal)
        {
            List<Enums.AnimalAttackMethodForms> animalAttackMethodForms = new List<Enums.AnimalAttackMethodForms>();
            this.AnimalStrategies = new List<Enums.AnimalStrategies>();

            if (animal == Enums.Animals.Lion)
            {
                GetAttackMethodForms(rand, animal, animalAttackMethodForms);
            }
            else
            {
                GetAttackMethodForms(rand, animal, animalAttackMethodForms);
            }

            return animalAttackMethodForms;
        }

        private void GetAttackMethodForms(Random rand, Enums.Animals animal, List<Enums.AnimalAttackMethodForms> animalAttackMethodForms)
        {
            foreach (Enums.AttackMethodCategories animalAttackMethod in Enum.GetValues(typeof(Enums.AttackMethodCategories)).Cast<Enums.AttackMethodCategories>().Where(x => x.ToString().Contains(animal.ToString())))
            {
                var items = Enum.GetValues(typeof(Enums.AnimalAttackMethodForms)).Cast<Enums.AnimalAttackMethodForms>().ToList().Where(x => x.ToString().Contains(animalAttackMethod.ToString()));

                if (items.Count() > 0)
                {
                    if (this.AnimalStrategies.Count == 0)
                    {
                        GetAnimalStrategies(animal);
                    }
                    int randStrategy = rand.Next(0, this.AnimalStrategies.Count());
                    Enums.AnimalStrategies animalStrategy = this.AnimalStrategies.Cast<Enums.AnimalStrategies>().ElementAt(randStrategy);
                    int randIntAttackMethod = rand.Next(0, items.Where(x => x.ToString().Contains(animalStrategy.ToString())).Count());
                    string strategyName = GetStrategyName(animalStrategy);
                    Enums.AnimalAttackMethodForms animalAttackMethodFormsItem = items.Where(x => x.ToString().Contains(strategyName)).Cast<Enums.AnimalAttackMethodForms>().ElementAt(randIntAttackMethod);
                    RemoveItemFromAnimalStrategy(animalStrategy);
                    animalAttackMethodForms.Add(animalAttackMethodFormsItem);
                }
            }
        }

        private string GetStrategyName(Enums.AnimalStrategies animalStrategy)
        {
            string[] name = animalStrategy.ToString().Split('_');
            return name[1];
        }

        private List<Enums.StandingMethods> GetAnimalStandingMethods(Enums.Animals animal)
        {
            List<Enums.StandingMethods> animalStandingMethods = new List<Enums.StandingMethods>();
            foreach (Enums.StandingMethods attackMethod in Enum.GetValues(typeof(Enums.StandingMethods)))
            {
                if (attackMethod.ToString().Contains(animal.ToString()))
                {
                    animalStandingMethods.Add(attackMethod);
                }
            }

            return animalStandingMethods;
        }

        private List<Enums.TurningMethods> GetAnimalTurningMethods(Enums.Animals animal)
        {
            List<Enums.TurningMethods> animalTurningMethods = new List<Enums.TurningMethods>();
            foreach (Enums.TurningMethods attackMethod in Enum.GetValues(typeof(Enums.TurningMethods)))
            {
                if (attackMethod.ToString().Contains(animal.ToString()))
                {
                    animalTurningMethods.Add(attackMethod);
                }
            }

            return animalTurningMethods;
        }

        private List<Enums.AttackMethods> GetAnimalAttackMethods(Enums.Animals animal)
        {
            List<Enums.AttackMethods> animalAttackMethods = new List<Enums.AttackMethods>();
            foreach (Enums.AttackMethods attackMethod in Enum.GetValues(typeof(Enums.AttackMethods)))
            {
                if (attackMethod.ToString().Contains(animal.ToString()))
                {
                    animalAttackMethods.Add(attackMethod);
                }
            }

            return animalAttackMethods;
        }

        private void RemoveItemFromAnimalStrategy(Enums.AnimalStrategies animalStrategy)
        {
            this.AnimalStrategies.Remove(animalStrategy);
        }
    }
}