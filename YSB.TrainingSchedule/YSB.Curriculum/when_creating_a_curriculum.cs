using Machine.Specifications;
using System;
using System.Linq;
using System.Collections.Generic;
using YSB.Common;

namespace YSB.Curriculum
{
    public class when_creating_a_curriculum
    {
        private static CurriculumManager manager;
        private static List<CurriculumItem> result;

        Establish context = () =>
        {
            manager = new CurriculumManager(Enums.Animals.Lion);
        };

        Because of = () =>
        {
            result = manager.GeneratedCurriculum;
        };

        It should_not_be_null = () =>
        {
            result.ShouldNotBeNull();
        };

        It should_be_of_type_CurriculumItem = () =>
        {
            result.FirstOrDefault().ShouldBeOfExactType<CurriculumItem>();
        };

        private It should_have_a_curriculum_that_has_24_attack_methods = () =>
        {
            result.FirstOrDefault().AttackMethods.Count().ShouldEqual(24);
        };

        private It should_have_a_curriculum_that_has_9_standing_methods = () =>
        {
            result.FirstOrDefault().StandingMethods.Count().ShouldEqual(9);
        };

        private It should_have_a_curriculum_that_has_8_circle_turning_methods = () =>
        {
            result.FirstOrDefault().TurningMethods.Count().ShouldEqual(8);
        };

        private It should_have_a_curriculum_that_has_8_attack_method_forms = () =>
        {
            result.FirstOrDefault().AttackMethodForms.Count().ShouldEqual(8);
        };

        private It should_have_no_duplicated_attack_method_forms = () =>
        {
            List<Enums.AnimalAttackMethodForms> attackMethodsAndForms = result.FirstOrDefault().AttackMethodForms.GetRange(0, 8);
            var query = attackMethodsAndForms.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            query.Count.ShouldEqual(0);
        };

        private It should_have_one_of_each_strategy_in_the_attack_method_forms = () =>
        {
            List<Enums.AnimalAttackMethodForms> attackMethodsAndForms = result.FirstOrDefault().AttackMethodForms.GetRange(0, 8);

            foreach (Enums.AnimalStrategies strategy in Enum.GetValues(typeof(Enums.AnimalStrategies)))
            {
                if (!strategy.ToString().Equals(Enums.AnimalStrategies.Lion_Interlocking.ToString()))
                {
                    string[] name = strategy.ToString().Split('_');        

                    attackMethodsAndForms.FindIndex(x => x.ToString().Contains(name[1])).ShouldNotEqual(-1);
                }
            }
        };

        private It should_get_the_expected_strategies_for_the_given_animal = () =>
        {
            List<Enums.AnimalStrategies> animalStrategies = result.FirstOrDefault().Strategies;
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Snake_Moving_With_The_Force);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Bear_Turning_The_Back);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Dragon_Holding_And_Lifting);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Phoenix_Windmill);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Rooster_Lying_Step);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Unicorn_Reversing_The_Body);
            animalStrategies.ShouldContain(Enums.AnimalStrategies.Monkey_Enfolding);
        };
    }
}