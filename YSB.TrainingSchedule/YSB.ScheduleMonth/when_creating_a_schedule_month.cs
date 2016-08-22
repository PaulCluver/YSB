using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.ScheduleMonth
{
    public class when_creating_a_schedule_month
    {
        private static ScheduleMonthManager manager;
        private static List<ScheduleMonthItem> result;

        private Establish context = () =>
         {
             manager = new ScheduleMonthManager();
         };

        private Because of = () =>
         {
             result = manager.ScheduleMonthContainers;
         };

        private It should_not_be_ull = () =>
         {
             result.ShouldNotBeNull();
         };

        private It should_return_the_expected_number_of_containers = () =>
         {
             int expectedAmountOfContainers = ((Enum.GetNames(typeof(Enums.AnimalAttackMethodForms)).Length / (Enum.GetNames(typeof(Enums.AnimalStrategies)).Length)));
             expectedAmountOfContainers.ShouldEqual(result.Count);
         };

        private It should_be_of_type_ScheduleMonthContainer = () =>
         {
             result.FirstOrDefault().ShouldBeOfExactType<ScheduleMonthItem>();
         };

        private It should_have_a_ScheduleMonthItems = () =>
         {
             result.FirstOrDefault().ScheduleMonthItems.ShouldNotBeNull();
         };

        private It should_be_of_the_expected_type = () =>
         {
             result.FirstOrDefault().ScheduleMonthItems.ShouldBeOfExactType<Dictionary<string, Dictionary<Enums.Animals, DateTime>>>();
         };
    }
}