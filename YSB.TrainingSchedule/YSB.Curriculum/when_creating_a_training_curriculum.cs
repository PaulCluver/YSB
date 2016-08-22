using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using YSB.Common;

namespace YSB.TrainingSchedule
{
    internal class when_creating_a_training_curriculum
    {
        private static CurriculumManager manager;
        private static List<Curriculum> curriculum;
        private static Enums.Animals animal;

        private Establish context = () =>
        {
            animal = Enums.Animals.Lion;
            Random rand = new Random();
            manager = new CurriculumManager(animal);
        };

        private Because of = () =>
        {
            curriculum = manager.GeneratedCurriculum;
        };

        private It should_not_be_null = () =>
        {
            curriculum.ShouldNotBeNull();
        };

        private It should_have_an_animal = () => 
        {
            curriculum.FirstOrDefault().Animal.ShouldNotBeNull();
        };

        private It should_have_an_animal_of_the_expected_type = () =>
        {
            curriculum.FirstOrDefault().Animal.ShouldBeOfExactType(typeof(Common.Enums.Animals));
        };

        private It should_have_an_attack_method = () => 
        {
            curriculum.FirstOrDefault().AttackMethods.ShouldNotBeNull();
        };

        private It should_have_an_attack_method_of_the_expected_type = () =>
        {
            curriculum.FirstOrDefault().AttackMethods.ShouldBeOfExactType(typeof(List<Enums.AttackMethods>));
        };

        private It should_have_an_attack_method_that_relates_to_the_given_animal = () =>
        {
            curriculum.FirstOrDefault().AttackMethods.FirstOrDefault().ToString().ShouldContain(animal.ToString());
        };

        private It should_have_an_attack_method_form = () => 
        {
            curriculum.FirstOrDefault().AttackMethodForms.FirstOrDefault().ShouldNotBeNull();
        };

        private It should_have_an_attack_method_forms = () =>
        {
            curriculum.FirstOrDefault().AttackMethodForms.Count().ShouldEqual(8);
        };
    }
}