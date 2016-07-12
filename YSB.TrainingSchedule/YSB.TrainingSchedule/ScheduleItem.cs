using System;
using System.Collections.Generic;
using YSB.Common;
using YSB.Curriculum;

namespace YSB.TrainingSchedule
{
    public class ScheduleItem
    {
        public int ID { get; internal set; }
        public Enums.Animals Animal { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public List<CurriculumItem> Curriculum { get; internal set; }
        public int TotalDays { get; internal set; }
        public int RemainingDays { get; internal set; }
        public int DoneDays { get; internal set; }
        public string PercentageDone { get; internal set; }
        public double TotalWeeks { get; internal set; }
        public double DoneWeeks { get; internal set; }
        public double RemainingWeeks { get; internal set; }
        private static CurriculumManager cm;

        public ScheduleItem(int id, Enums.Animals animal, DateTime startDate, int duration)
        {
            this.ID = id;
            this.Animal = animal;
            this.StartDate = startDate;
            this.EndDate = startDate.AddMonths(duration);
            this.TotalDays = Convert.ToInt32((EndDate - StartDate).TotalDays);
            this.RemainingDays = GetRemainingDays();
            this.DoneDays = TotalDays - RemainingDays;
            this.TotalWeeks = Math.Round((Convert.ToDouble((EndDate - StartDate).TotalDays / 7)) - 1, 0);
            this.RemainingWeeks = GetRemainingWeeks();
            this.DoneWeeks = TotalWeeks - RemainingWeeks;
            this.PercentageDone = GetPercentageDone(TotalDays, DoneDays);
            cm = new CurriculumManager(this.ID, this.Animal);
            this.Curriculum = cm.GeneratedCurriculum;
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