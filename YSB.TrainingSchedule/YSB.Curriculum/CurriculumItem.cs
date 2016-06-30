using System.Collections.Generic;
using YSB.Common;

namespace YSB.Curriculum
{
    public class CurriculumItem
    {
        public Enums.Animals Animal { get; internal set; }
        public List<Enums.AttackMethods> AttackMethods { get; internal set; }
        public List<Enums.TurningMethods> TurningMethods { get; set; }
        public List<Enums.StandingMethods> StandingMethods { get; set; }
        public List<Enums.AnimalAttackMethodForms> AttackMethodForms { get; set; }

        public CurriculumItem(Enums.Animals animal, List<Enums.AttackMethods> attackMethods, List<Enums.TurningMethods> turningMethods, List<Enums.StandingMethods> standingMethods, List<Enums.AnimalAttackMethodForms> attackMethodForms)
        {
            this.Animal = animal;
            this.AttackMethods = attackMethods;
            this.TurningMethods = turningMethods;
            this.StandingMethods = standingMethods;
            this.AttackMethodForms = attackMethodForms;
        }
    }
}