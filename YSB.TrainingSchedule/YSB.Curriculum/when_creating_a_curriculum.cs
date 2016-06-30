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
            manager = new CurriculumManager(Enums.Animals.Lion, new List<Enums.AnimalAttackMethodForms>() { Enums.AnimalAttackMethodForms.Lion_Blocking_Enfolding });
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
            List<Enums.AnimalAttackMethodForms> attackMethodsAndForms = new List<Enums.AnimalAttackMethodForms>();
            foreach (var item in result)
            {
                foreach (var attackMethodForms in item.AttackMethodForms)
                {
                    attackMethodsAndForms.Add(attackMethodForms);
                }
            }

            var query = attackMethodsAndForms.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            query.Count.ShouldEqual(0);
        };
    }
}