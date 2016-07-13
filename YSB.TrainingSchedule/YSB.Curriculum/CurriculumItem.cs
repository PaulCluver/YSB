using System.Collections.Generic;
using YSB.Common;

namespace YSB.Curriculum
{
    public class CurriculumItem
    {
        public List<Enums.AttackMethods> AttackMethods { get; internal set; }
        public List<Enums.TurningMethods> TurningMethods { get; set; }
        public List<Enums.StandingMethods> StandingMethods { get; set; }
        public List<Enums.AnimalAttackMethodForms> AttackMethodForms { get; set; }
        public List<Enums.AnimalStrategies> Strategies { get; set; }

        public CurriculumItem(Enums.Animals animal, List<Enums.AttackMethods> attackMethods, List<Enums.TurningMethods> turningMethods, List<Enums.StandingMethods> standingMethods, List<Enums.AnimalAttackMethodForms> attackMethodForms, List<Enums.AnimalStrategies> animalStrategies)
        {
            this.AttackMethods = attackMethods;
            this.TurningMethods = turningMethods;
            this.StandingMethods = standingMethods;
            this.AttackMethodForms = attackMethodForms;
            this.Strategies = animalStrategies;
        }
    }
}