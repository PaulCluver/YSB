using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using YSB.Common;
using YSB.ScheduleMonth;

namespace YSB.TrainingSchedule
{
    public class ScheduleManager
    {
        public List<ScheduleItem> GeneratedSchedule;
        public XmlDocument GeneratedXMLDocument;

        public ScheduleManager()
        {
            List<ScheduleMonthItem> scheduleMonthContainers = GenerateScheduleMonthContainers();
            GenerateSchedule(scheduleMonthContainers);
        }

        internal void PopulateScheduleFromXML()
        {
            
        }

        private List<ScheduleMonthItem> GenerateScheduleMonthContainers()
        {
            ScheduleMonthManager smc = new ScheduleMonthManager();
            return smc.ScheduleMonthContainers;
        }

        private void GenerateSchedule(List<ScheduleMonthItem> scheduleMonthContainers)
        {
            GeneratedSchedule = new List<ScheduleItem>();
            int index = 0;

            foreach (ScheduleMonthItem sm in scheduleMonthContainers)
            {
                index++;
                foreach (KeyValuePair<string, Dictionary<Enums.Animals, DateTime>> pair in sm.ScheduleMonthItems)
                {
                    foreach (KeyValuePair<Enums.Animals, DateTime> vals in pair.Value)
                    {
                        GeneratedSchedule.Add(new ScheduleItem(vals.Key, vals.Value, sm.Duration));
                    }
                }
            }
        }

        public void WriteGeneratedScheduleToXML()
        {
            XmlTextWriter writer = new XmlTextWriter("E:\\Personal\\Programs\\YSB.TrainingSchedule\\YSB.TrainingSchedule\\YSB.Data\\curriculums.xml", null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Curriculums");

            int i = 0;
            foreach (ScheduleItem item in this.GeneratedSchedule)
            {
                i++;
                writer.WriteStartElement("Curriculum");
                writer.WriteElementString("ID", i.ToString());
                writer.WriteElementString("StartDate", item.StartDate.ToShortDateString());
                writer.WriteElementString("EndDate", item.EndDate.ToShortDateString());
                writer.WriteElementString("TotalDays", item.TotalDays.ToString());
                writer.WriteElementString("TotalWeeks", item.TotalWeeks.ToString());
                writer.WriteElementString("DoneDays", item.DoneDays.ToString());
                writer.WriteElementString("DoneWeeks", item.DoneWeeks.ToString());
                writer.WriteElementString("RemainingDays", item.RemainingDays.ToString());
                writer.WriteElementString("RemainingWeeks", item.RemainingWeeks.ToString());
                writer.WriteElementString("PercentageDone", item.PercentageDone.ToString());

                foreach (DailyProgram program in item.DailyProgram)
                {
                    writer.WriteStartElement("DailyProgram");
                    writer.WriteElementString("Day", program.Day.ToString());

                    writer.WriteStartElement("Standing");
                    foreach (Enums.StandingMethods standing in program.StandingMethods)
                    {
                        writer.WriteElementString("Method", standing.ToString());
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Striking");
                    foreach (Enums.AttackMethods striking in program.StrikingMethods)
                    {
                        writer.WriteElementString("Method", striking.ToString());
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Turning");
                    foreach (Enums.TurningMethods turning in program.TurningMethods)
                    {
                        writer.WriteElementString("Method", turning.ToString());
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Changing");
                    foreach (Enums.AnimalAttackMethodForms changing in program.ChangingMethods)
                    {
                        writer.WriteElementString("Method", changing.ToString());
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                
                writer.WriteEndElement();
                
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}