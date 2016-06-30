using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.Curriculum
{
    public class CurriculumManager : List<CurriculumItem>
    {
        private Enums.Animals Animal;
        private List<Enums.AnimalAttackMethodForms> AnimalAttackMethodFormsExclusions;
        public List<CurriculumItem> GeneratedCurriculum { get; internal set; }

        public CurriculumManager(Enums.Animals animal, List<Enums.AnimalAttackMethodForms> animalAttackMethodFormsExclusions)
        {
            this.Animal = animal;
            this.AnimalAttackMethodFormsExclusions = animalAttackMethodFormsExclusions;
            this.GeneratedCurriculum = new List<CurriculumItem>();

            GeneratedCurriculum.Add(new CurriculumItem(animal, GetAnimalAttackMethods(animal), GetAnimalTurningMethods(animal), GetAnimalStandingMethods(animal), GetAnimalAttackMethodForms(new Random(), animal)));
        }

        private List<Enums.AnimalAttackMethodForms> GetAnimalAttackMethodForms(Random rand, Enums.Animals animal)
        {
            List<Enums.AnimalAttackMethodForms> animalAttackMethodForms = new List<Enums.AnimalAttackMethodForms>();

            foreach (Enums.AnimalAttackMethods animalAttackMethod in Enum.GetValues(typeof(Enums.AnimalAttackMethods)).Cast<Enums.AnimalAttackMethods>().Where(x => x.ToString().Contains(animal.ToString())))
            {
                var items = Enum.GetValues(typeof(Enums.AnimalAttackMethodForms)).Cast<Enums.AnimalAttackMethodForms>().ToList().Except(this.AnimalAttackMethodFormsExclusions).Where(x => x.ToString().Contains(animalAttackMethod.ToString()));
                if (items.Count() > 0)
                {
                    int randInt = rand.Next(0, items.Count());
                    Enums.AnimalAttackMethodForms item = items.Cast<Enums.AnimalAttackMethodForms>().ElementAt(randInt);
                    animalAttackMethodForms.Add(item);
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
    }
}