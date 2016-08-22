using System;
using System.Collections.Generic;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    public class Schedule
    {
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public Enums.Animals Animal { get; internal set; }
        public int TotalWeeks { get; internal set; }
        public int RemainingDays { get; internal set; }
        public string PercentageDone { get; internal set; }
        public int DoneDays { get; internal set; }
        public int TotalDays { get; internal set; }
        public List<Curriculum> Curriculum { get; internal set; }
        private static CurriculumManager manager;

        public Schedule(Enums.Animals animal, DateTime startDate)
        {
            this.Animal = animal;
            this.StartDate = startDate;
            this.EndDate = startDate.AddMonths(4);
            this.TotalWeeks = (Convert.ToInt32((EndDate - StartDate).TotalDays / 7)) - 1;
            this.RemainingDays = GetRemainingDays();
            this.TotalDays = Convert.ToInt32((EndDate - StartDate).TotalDays);
            this.DoneDays = TotalDays - RemainingDays;
            this.PercentageDone = GetPercentageDone(TotalDays, DoneDays);
            manager = new CurriculumManager(this.Animal);
            this.Curriculum = manager.GeneratedCurriculum;
        }

        private string GetPercentageDone(int totalDays, int doneDays)
        {
            double ratio = ((double)doneDays / totalDays);
            return string.Format("{0:0.0%}", ratio);
        }

        private int GetRemainingDays()
        {
            int remainingDays = 0;
            if (this.EndDate > DateTime.Now && this.StartDate < DateTime.Now) 
            {
                TimeSpan t = EndDate - DateTime.Now;
                remainingDays = Math.Abs(t.Days);
            }
            else if (this.EndDate > DateTime.Now)
            {
                TimeSpan t = StartDate - EndDate;
                remainingDays = Math.Abs(t.Days);
            }
            return remainingDays;
        }
    }
}