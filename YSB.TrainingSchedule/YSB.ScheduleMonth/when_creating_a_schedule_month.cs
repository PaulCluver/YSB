using Machine.Specifications;
using System;
using System.Linq;
using System.Collections.Generic;
using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class when_creating_a_schedule_month
    {
        private static ScheduleMonthManager manager;
        private static List<ScheduleMonthItem> result;

        Establish context = () =>
        {
            manager = new ScheduleMonthManager();
        };

        Because of = () =>
        {
            result = manager.ScheduleMonthContainers;
        };

        It should_not_be_ull = () =>
        {
            result.ShouldNotBeNull();
        };

        It should_return_the_expected_number_of_containers = () =>
        {
            int expectedAmountOfContainers = ( (Enum.GetNames(typeof(Enums.AnimalAttackMethodForms)).Length / (Enum.GetNames(typeof(Enums.AnimalStrategies)).Length)));
            expectedAmountOfContainers.ShouldEqual(result.Count);
        };

        It should_be_of_type_ScheduleMonthContainer = () =>
        {
            result.FirstOrDefault().ShouldBeOfExactType<ScheduleMonthItem>();
        };

        It should_have_a_ScheduleMonthItems = () =>
        {
            result.FirstOrDefault().ScheduleMonthItems.ShouldNotBeNull();
        };

        It should_be_of_the_expected_type = () =>
        {
            result.FirstOrDefault().ScheduleMonthItems.ShouldBeOfExactType<Dictionary<string, Dictionary<Enums.Animals, DateTime>>>();
        };
    }
}