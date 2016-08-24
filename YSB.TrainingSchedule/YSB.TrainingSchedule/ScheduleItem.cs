using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;
using YSB.Curriculum;

namespace YSB.TrainingSchedule
{
    public class ScheduleItem
    {
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public int TotalDays { get; internal set; }
        public int RemainingDays { get; internal set; }
        public int DoneDays { get; internal set; }
        public string PercentageDone { get; internal set; }
        public double TotalWeeks { get; internal set; }
        public double DoneWeeks { get; internal set; }
        public double RemainingWeeks { get; internal set; }
        public List<DailyProgram> DailyProgram { get; internal set; }

        private static CurriculumManager primaryCurriculumManager;
        private static CurriculumManager secondaryCurriculumManager;
        private static DailyProgramManager dailyProgramManager;

        public ScheduleItem(Enums.Animals animal, DateTime startDate, int duration)
        {
            this.StartDate = startDate;
            this.EndDate = startDate.AddMonths(duration);
            this.TotalDays = Convert.ToInt32((EndDate - StartDate).TotalDays);
            this.RemainingDays = GetRemainingDays();
            this.DoneDays = TotalDays - RemainingDays;
            this.TotalWeeks = Math.Round((Convert.ToDouble((EndDate - StartDate).TotalDays / 7)) - 1, 0);
            this.RemainingWeeks = GetRemainingWeeks();
            this.DoneWeeks = TotalWeeks - RemainingWeeks;
            this.PercentageDone = GetPercentageDone(TotalDays, DoneDays);

            primaryCurriculumManager = new CurriculumManager(animal);
            secondaryCurriculumManager = new CurriculumManager(Enums.Animals.Lion);

            List<CurriculumItem> combinedCurriculum = new List<CurriculumItem>() { primaryCurriculumManager.GeneratedCurriculum.FirstOrDefault(), secondaryCurriculumManager.GeneratedCurriculum.FirstOrDefault() };

            List<Enums.StandingMethods> standing = new List<Enums.StandingMethods>();
            List<Enums.AttackMethods> striking = new List<Enums.AttackMethods>();
            List<Enums.TurningMethods> turning = new List<Enums.TurningMethods>();
            List<Enums.AnimalAttackMethodForms> changing = new List<Enums.AnimalAttackMethodForms>();

            foreach (var curriculum in combinedCurriculum)
            {

                foreach (var standingMethods in curriculum.StandingMethods)
                {
                    standing.Add(standingMethods);
                }

                foreach (var attackMethods in curriculum.AttackMethods)
                {
                    striking.Add(attackMethods);
                }

                foreach (var turningMethods in curriculum.TurningMethods)
                {
                    turning.Add(turningMethods);
                }

                foreach (var attackMethodForm in curriculum.AttackMethodForms)
                {
                    changing.Add(attackMethodForm);
                }

            }

            dailyProgramManager = new DailyProgramManager(animal, standing, striking, turning, changing);
            this.DailyProgram = dailyProgramManager.GeneratedDailyProgram;
        }

        private string GetPercentageDone(int totalDays, int doneDays)
        {
            double ratio = ((double)doneDays / totalDays);
            return string.Format("{0:0.0%}", ratio);
        }

        private double GetRemainingWeeks()
        {
            double remainingWeeks = 0.0D;
            if (this.EndDate > DateTime.Now)
            {
                remainingWeeks = this.TotalWeeks;
            }

            return remainingWeeks;
        }

        private int GetRemainingDays()
        {
            int remainingDays = 0;
            if (this.EndDate > DateTime.Now && this.StartDate < DateTime.Now)
            {
                TimeSpan t = this.EndDate - DateTime.Now;
                remainingDays = Math.Abs(t.Days);
            }
            else if (this.EndDate > DateTime.Now)
            {
                TimeSpan t = this.StartDate - this.EndDate;
                remainingDays = Math.Abs(t.Days);
            }
            return remainingDays;
        }
    }
}