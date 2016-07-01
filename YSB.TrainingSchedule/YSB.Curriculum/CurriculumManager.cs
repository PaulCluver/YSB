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
            ManageAnimalStrategies(animal);
            GeneratedCurriculum.Add(new CurriculumItem(animal, GetAnimalAttackMethods(animal), GetAnimalTurningMethods(animal), GetAnimalStandingMethods(animal), GetAnimalAttackMethodForms(new Random(), animal)));
        }

        private void ManageAnimalStrategies(Enums.Animals animal)
        {
            PopulateAnimalStrategies();
            RefreshAnimalStrategies(animal);
        }

        private List<Enums.AnimalAttackMethodForms> GetAnimalAttackMethodForms(Random rand, Enums.Animals animal)
        {
            List<Enums.AnimalAttackMethodForms> animalAttackMethodForms = new List<Enums.AnimalAttackMethodForms>();

            foreach (Enums.AnimalAttackMethods animalAttackMethod in Enum.GetValues(typeof(Enums.AnimalAttackMethods)).Cast<Enums.AnimalAttackMethods>().Where(x => x.ToString().Contains(animal.ToString())))
            {
                var items = Enum.GetValues(typeof(Enums.AnimalAttackMethodForms)).Cast<Enums.AnimalAttackMethodForms>().ToList().Where(x => x.ToString().Contains(animalAttackMethod.ToString()));

                if (items.Count() > 0)
                {
                    if (this.AnimalStrategies.Count == 0)
                    {
                        ManageAnimalStrategies(animal);

                    }
                    int randStrategy = rand.Next(0, this.AnimalStrategies.Count());
                    Enums.AnimalStrategies animalStrategy = this.AnimalStrategies.Cast<Enums.AnimalStrategies>().ElementAt(randStrategy);
                    int randIntAttackMethod = rand.Next(0, items.Where(x => x.ToString().Contains(animalStrategy.ToString())).Count());
                    RemoveItemFromAnimalStrategy(animalStrategy);
                    Enums.AnimalAttackMethodForms animalAttackMethodFormsItem = items.Where(x => x.ToString().Contains(animalStrategy.ToString())).Cast<Enums.AnimalAttackMethodForms>().ElementAt(randIntAttackMethod);
                    animalAttackMethodForms.Add(animalAttackMethodFormsItem);
                }
            }

            return animalAttackMethodForms;
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

        private void PopulateAnimalStrategies()
        {
            this.AnimalStrategies = Enum.GetValues(typeof(Enums.AnimalStrategies)).Cast<Enums.AnimalStrategies>().ToList();
        }

        private void RefreshAnimalStrategies(Enums.Animals animal)
        {
            switch (animal)
            {
                case Enums.Animals.Lion:
                    this.AnimalStrategies.Remove(Enums.AnimalStrategies.Interlocking);
                    break;
                case Enums.Animals.Bear:
                    this.AnimalStrategies.Remove(Enums.AnimalStrategies.Turning_The_Back);
                    break;
                case Enums.Animals.Dragon:
                    this.AnimalStrategies.Remove(Enums.AnimalStrategies.Holding_And_Lifting);
                    break;
                case Enums.Animals.Phoenix:
                    this.AnimalStrategies.Remove(Enums.AnimalStrategies.Windmill);
                    break;
                case Enums.Animals.Rooster:
                    this.AnimalStrategies.Remove(Enums.AnimalStrategies.Lying_Step);
                    break;
            }
        }

        private void RemoveItemFromAnimalStrategy(Enums.AnimalStrategies animalStrategy)
        {
            this.AnimalStrategies.Remove(animalStrategy);
        }
    }
}