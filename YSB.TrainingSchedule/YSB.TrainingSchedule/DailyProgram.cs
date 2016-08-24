using System.Collections.Generic;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    public class DailyProgram
    {
        public int Day;
        public List<Enums.StandingMethods> StandingMethods;
        public List<Enums.AnimalAttackMethodForms> ChangingMethods { get; private set; }
        public List<Enums.AttackMethods> StrikingMethods { get; private set; }
        public List<Enums.TurningMethods> TurningMethods { get; private set; }

        public DailyProgram(int day, List<Enums.StandingMethods> standingMethods, List<Enums.AttackMethods> strikingMethods, List<Enums.TurningMethods> turningMethods, List<Enums.AnimalAttackMethodForms> changingMethods) 
        {
            this.Day = day;
            this.StandingMethods = standingMethods;
            this.StrikingMethods = strikingMethods;
            this.TurningMethods = turningMethods;
            this.ChangingMethods = changingMethods;
        }
        
    }
}