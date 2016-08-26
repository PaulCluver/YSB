using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    internal class DailyProgramManager
    {
        private Enums.Animals Animal;
        private List<Enums.StandingMethods> standing;
        private List<Enums.AttackMethods> striking;
        private List<Enums.TurningMethods> turning;
        private List<Enums.AnimalAttackMethodForms> changing;

        public List<DailyProgram> GeneratedDailyProgram { get; internal set; }

        public DailyProgramManager(Enums.Animals animal, List<Enums.StandingMethods> standing, List<Enums.AttackMethods> striking, List<Enums.TurningMethods> turning, List<Enums.AnimalAttackMethodForms> changing)
        {
            this.GeneratedDailyProgram = new List<DailyProgram>();
            this.Animal = animal;

            for (int day = 1; day <= 8; day++)
            {
                GeneratedDailyProgram.Add(new DailyProgram(day, GetStandingMethods(animal, standing), GetStrikingMethods(animal, striking), GetTurningMethods(animal, turning), GetChangingMethods(animal, changing)));
            }
        }

        private List<Enums.StandingMethods> GetStandingMethods(Enums.Animals animal, List<Enums.StandingMethods> standing)
        {
            Enums.StandingMethods dynamicRepresentativePosture = standing.Where(x => x.ToString().Contains(animal.ToString()) && x.ToString().Contains("Representative")).FirstOrDefault();
            Enums.StandingMethods lionRepresentativePosture = standing.Where(x => x.ToString().Contains(Enums.Animals.Lion.ToString()) && x.ToString().Contains("Representative")).FirstOrDefault();
            Enums.StandingMethods firstDynamicPosture = standing.Where(x => x.ToString().Contains(animal.ToString()) && x.ToString().Contains("Representative").Equals(false)).FirstOrDefault();
            Enums.StandingMethods firstLionPosture = standing.Where(x => x.ToString().Contains(Enums.Animals.Lion.ToString()) && x.ToString().Contains("Representative").Equals(false)).FirstOrDefault();
            standing.Remove(firstDynamicPosture);
            standing.Remove(firstLionPosture);

            return new List<Enums.StandingMethods>() { lionRepresentativePosture, firstLionPosture, dynamicRepresentativePosture, firstDynamicPosture };
        }

        private List<Enums.AttackMethods> GetStrikingMethods(Enums.Animals animal, List<Enums.AttackMethods> striking)
        {
            List<Enums.AttackMethods> result = new List<Enums.AttackMethods>();

            for (int i = 0; i < 3; i++)
            {
                Enums.AttackMethods firstDynamicStrike = striking.Where(x => x.ToString().Contains(animal.ToString())).FirstOrDefault();
                Enums.AttackMethods firstLionStrike = striking.Where(x => x.ToString().Contains(Enums.Animals.Lion.ToString())).FirstOrDefault();
                striking.Remove(firstDynamicStrike);
                striking.Remove(firstLionStrike);

                result.Add(firstLionStrike);
                result.Add(firstDynamicStrike);
            }
            return result.OrderByDescending(x => x.ToString()).ToList();
        }

        private List<Enums.TurningMethods> GetTurningMethods(Enums.Animals animal, List<Enums.TurningMethods> turning)
        {
            List<Enums.TurningMethods> result = new List<Enums.TurningMethods>();
            
            Enums.TurningMethods firstDynamicTurning = turning.Where(x => x.ToString().Contains(animal.ToString())).FirstOrDefault();
            Enums.TurningMethods firstLionTurning = turning.Where(x => x.ToString().Contains(Enums.Animals.Lion.ToString())).FirstOrDefault();
            turning.Remove(firstDynamicTurning);
            turning.Remove(firstLionTurning);

            result.Add(firstLionTurning);
            result.Add(firstDynamicTurning);
            
            return result;
        }

        private List<Enums.AnimalAttackMethodForms> GetChangingMethods(Enums.Animals animal, List<Enums.AnimalAttackMethodForms> changing)
        {
            List<Enums.AnimalAttackMethodForms> result = new List<Enums.AnimalAttackMethodForms>();

            Enums.AnimalAttackMethodForms firstDynamicChanging = changing.Where(x => x.ToString().Contains(animal.ToString())).FirstOrDefault();
            Enums.AnimalAttackMethodForms firstLionChanging = changing.Where(x => x.ToString().Contains(Enums.Animals.Lion.ToString())).FirstOrDefault();
            changing.Remove(firstDynamicChanging);
            changing.Remove(firstLionChanging);

            result.Add(firstLionChanging);
            result.Add(firstDynamicChanging);

            return result;
        }        

    }
}