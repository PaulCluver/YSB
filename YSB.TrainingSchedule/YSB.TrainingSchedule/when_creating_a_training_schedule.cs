﻿using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    internal class when_creating_a_training_schedule
    {
        private static ScheduleManager sm;
        private static List<ScheduleItem> schedule;

        private Establish context = () =>
        {
            sm = new ScheduleManager();
        };

        private Because of = () =>
        {
            schedule = sm.GeneratedSchedule;
        };

        private It should_have_a_start_date = () =>
        {
            schedule.FirstOrDefault().StartDate.ShouldBeOfExactType(typeof(DateTime));
        };

        private It should_have_an_end_date = () =>
        {
            schedule.FirstOrDefault().EndDate.ShouldBeOfExactType(typeof(DateTime));
        };

        private It should_have_a_start_date_that_is_before_the_end_date = () =>
        {
            DateTime startDate = schedule.FirstOrDefault().StartDate;
            DateTime endDate = schedule.FirstOrDefault().EndDate;

            startDate.ShouldBeLessThan(endDate);
        };

        private It should_have_a_count_of_total_weeks = () =>
        {
            schedule.FirstOrDefault().TotalWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_the_expected_count_of_total_weeks = () =>
        {
            DateTime startDate = schedule.FirstOrDefault().StartDate;
            DateTime endDate = schedule.FirstOrDefault().EndDate;
            double totalWeeks = Math.Round(Convert.ToDouble((endDate - startDate).TotalDays / 7) - 1, 0);

            schedule.FirstOrDefault().TotalWeeks.ShouldEqual(totalWeeks);
        };

        private It should_have_a_count_of_remaining_weeks = () =>
        {
            schedule.FirstOrDefault().RemainingWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_a_count_of_done_weeks = () =>
        {
            schedule.FirstOrDefault().DoneWeeks.ShouldBeOfExactType(typeof(Double));
        };

        private It should_have_a_training_schedule = () =>
        {
            schedule.ShouldNotBeNull();
        };

        private It should_have_a_remaining_days_of_0_if_a_schedule_is_in_the_past = () =>
        {
            var results = schedule.Where(x => x.EndDate < DateTime.Now);
            if (results.Count() > 0)
            {
                results.FirstOrDefault().RemainingDays.ShouldEqual(0);
            }
        };

        private It should_have_the_expected_remaining_days_if_a_schedule_is_current = () =>
        {
            var results = schedule.Where(x => x.EndDate > DateTime.Today && x.StartDate < DateTime.Now);
            if (results.Count() > 0)
            {
                TimeSpan t = results.FirstOrDefault().EndDate - DateTime.Now;
                int remainingDays = Math.Abs(t.Days);
                results.FirstOrDefault().RemainingDays.ShouldEqual(remainingDays);
            }
        };

        private It should_have_a_percentage_done_value = () =>
        {
            schedule.FirstOrDefault().PercentageDone.ShouldNotBeNull();
        };

        private It should_have_TotalDays_value = () =>
        {
            schedule.FirstOrDefault().TotalDays.ShouldNotBeNull();
        };

        private It should_have_DoneDays_value = () =>
        {
            schedule.FirstOrDefault().DoneDays.ShouldNotBeNull();
        };

        private It should_have_a_count_of_remaining_days = () =>
        {
            var results = schedule.Where(x => x.StartDate > DateTime.Now);
            DateTime startDate = results.FirstOrDefault().StartDate;
            DateTime endDate = results.FirstOrDefault().EndDate;
            TimeSpan t = startDate - endDate;
            int remainingDays = Math.Abs(t.Days);
            results.FirstOrDefault().RemainingDays.ShouldEqual(remainingDays);
        };

        private It should_have_a_daily_program = () =>
        {
            schedule.FirstOrDefault().DailyProgram.ShouldNotBeNull();
        };        
    }
}