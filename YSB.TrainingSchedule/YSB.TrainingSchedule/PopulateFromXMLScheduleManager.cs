using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    internal class PopulateFromXMLScheduleManager
    {
        public List<ScheduleItem> GeneratedSchedule { get; internal set; }

        internal void PopulateScheduleFromXML()
        {
            this.GeneratedSchedule = new List<ScheduleItem>();

            var xml = XDocument.Load(@"E:\\Personal\\Programs\\YSB.TrainingSchedule\\YSB.TrainingSchedule\\YSB.Data\\curriculums.xml");
         
            foreach (XElement curriculum in xml.Descendants("Curriculum"))
            {
                int ID = Convert.ToInt32(curriculum.Element("ID").Value);
                Enums.Animals animal = Enum.GetValues(typeof(Enums.Animals)).Cast<Enums.Animals>().ToList().Where(x => x.ToString().Equals(curriculum.Element("Animal").Value)).FirstOrDefault();
                DateTime startDate = Convert.ToDateTime(curriculum.Element("StartDate").Value);
                DateTime endDate = Convert.ToDateTime(curriculum.Element("EndDate").Value);
                int totalDays = Convert.ToInt32(curriculum.Element("TotalDays").Value);
                int totalWeeks = Convert.ToInt32(curriculum.Element("TotalWeeks").Value);
                int doneDays = Convert.ToInt32(curriculum.Element("DoneDays").Value);
                int doneWeeks = Convert.ToInt32(curriculum.Element("DoneWeeks").Value);
                int remainingDays = Convert.ToInt32(curriculum.Element("RemainingDays").Value);
                int remainingWeeks = Convert.ToInt32(curriculum.Element("RemainingWeeks").Value);
                string percentageDone = curriculum.Element("PercentageDone").Value;
                int day = Convert.ToInt32(curriculum.Element("DailyProgram").Descendants("Day").ElementAt(0).Value);
                List<DailyProgram> dailyPrograms = new List<DailyProgram>();

                foreach (XElement dailyProgram in curriculum.Descendants("DailyProgram"))
                {
                    List<Enums.StandingMethods> standing = new List<Enums.StandingMethods>();
                    foreach (string val in dailyProgram.Element("Standing").Descendants("Method"))
                    {
                        standing.Add(Enum.GetValues(typeof(Enums.StandingMethods)).Cast<Enums.StandingMethods>().ToList().Where(x => x.ToString().Equals(val.ToString())).FirstOrDefault());
                    }

                    List<Enums.AttackMethods> striking = new List<Enums.AttackMethods>();
                    foreach (string val in dailyProgram.Element("Striking").Descendants("Method"))
                    {
                        striking.Add(Enum.GetValues(typeof(Enums.AttackMethods)).Cast<Enums.AttackMethods>().ToList().Where(x => x.ToString().Equals(val.ToString())).FirstOrDefault());
                    }

                    List<Enums.TurningMethods> turning = new List<Enums.TurningMethods>();
                    foreach (string val in dailyProgram.Element("Turning").Descendants("Method"))
                    {
                        turning.Add(Enum.GetValues(typeof(Enums.TurningMethods)).Cast<Enums.TurningMethods>().ToList().Where(x => x.ToString().Equals(val.ToString())).FirstOrDefault());
                    }

                    List<Enums.AnimalAttackMethodForms> changing = new List<Enums.AnimalAttackMethodForms>();
                    foreach (string val in dailyProgram.Element("Changing").Descendants("Method"))
                    {
                        changing.Add(Enum.GetValues(typeof(Enums.AnimalAttackMethodForms)).Cast<Enums.AnimalAttackMethodForms>().ToList().Where(x => x.ToString().Equals(val.ToString())).FirstOrDefault());
                    }

                    dailyPrograms.Add(new DailyProgram(day, standing, striking, turning, changing));
                }

                GeneratedSchedule.Add(new ScheduleItem(animal, startDate, endDate, totalDays, remainingDays, doneDays, totalWeeks, remainingWeeks, doneWeeks, percentageDone, dailyPrograms));
            }
        }
    }
}