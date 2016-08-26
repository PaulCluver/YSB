using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YSB.TrainingSchedule
{
    internal class when_populating_a_schedule_from_xml
    {
        private static PopulateFromXMLScheduleManager pxsm;
        private static List<ScheduleItem> schedule;

        private Establish context = () => 
        {
            pxsm = new PopulateFromXMLScheduleManager();
        };

        private Because of = () => 
        {
            pxsm.PopulateScheduleFromXML();
            schedule = pxsm.GeneratedSchedule;
        };

        private It should_populate_a_list_of_schedule_items = () => 
        {
            schedule.ShouldBeOfExactType(typeof(List<ScheduleItem>));
        };

        private It should_have_a_start_date_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().StartDate.ShouldNotBeNull();
            schedule.FirstOrDefault().StartDate.ShouldBeOfExactType(typeof(DateTime));
        };

        private It should_have_an_end_date_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().EndDate.ShouldNotBeNull();
            schedule.FirstOrDefault().EndDate.ShouldBeOfExactType(typeof(DateTime));
        };

        private It should_have_a_total_days_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().TotalDays.ShouldNotBeNull();
            schedule.FirstOrDefault().TotalDays.ShouldBeOfExactType(typeof(Int32));
        };

        private It should_have_a_total_weeks_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().TotalWeeks.ShouldNotBeNull();
            schedule.FirstOrDefault().TotalWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_a_done_days_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().DoneDays.ShouldNotBeNull();
            schedule.FirstOrDefault().DoneDays.ShouldBeOfExactType(typeof(Int32));
        };

        private It should_have_a_done_weeks_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().DoneWeeks.ShouldNotBeNull();
            schedule.FirstOrDefault().DoneWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_a_remaining_days_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().RemainingDays.ShouldNotBeNull();
            schedule.FirstOrDefault().RemainingDays.ShouldBeOfExactType(typeof(Int32));
        };

        private It should_have_a_remaining_weeks_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().RemainingWeeks.ShouldNotBeNull();
            schedule.FirstOrDefault().RemainingWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_a_percentage_done_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().PercentageDone.ShouldNotBeNull();
            schedule.FirstOrDefault().PercentageDone.ShouldBeOfExactType(typeof(string));
        };

        private It should_have_a_daily_program_value_of_the_expected_type = () =>
        {
            schedule.FirstOrDefault().DailyProgram.ShouldNotBeNull();
            schedule.FirstOrDefault().DailyProgram.ShouldBeOfExactType(typeof(List<DailyProgram>));
        };
    }
}