



namespace Tests
{

    using System;
    using NUnit.Framework;
    using DateExtensionMethods;

    [TestFixture]
    public class StringDateExtensionTests
    {
        [Test()]
        public void If_given_a_valid_date_should_resolve_to_a_date()
        {
            var shouldBe = DateTime.Parse("10/3/2011");
            var actual = "10/3/2011".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void If_given_a_invalid_date_should_throw_exception()
        {
            var actual = "10/32/2011".ToDate();
        }

    }

    [TestFixture]
    public class DateExtensions
    {
        [Test]
        public void If_given_a_date_should_return_as_an_int_the_last_day_of_that_month()
        {
            var shouldBe = 31;
            var actual = "1/1/2011".ToDate().LastDayInMonth();

            Assert.AreEqual(shouldBe, actual);
        }

        [Test]
        public void If_given_a_date_that_is_valid_should_be_able_to_determine_if_its_the_last_day_of_month()
        {
            var actual = "1/31/2011".ToDate().IsLastDayInMonth();

            Assert.IsTrue(actual);
        }

        [Test]
        public void If_given_a_date_that_is_valid_should_be_able_to_determine_its_next_aniversary_within_a_month()
        {
            var actual = "1/31/2011".ToDate().NextMonth();
            var shouldBe = "2/28/2011".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }
        
        [Test]
        public void If_given_a_date_that_is_valid_next_month_should_return_the_next_months_date()
        {
            var actual = "1/1/2011".ToDate().NextMonth();
            var shouldBe = "2/1/2011".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }

        [Test]
        public void If_given_a_date_that_is_valid_last_month_should_return_the_last_month_date()
        {
            var actual = "1/1/2011".ToDate().LastMonth();
            var shouldBe = "12/1/2010".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }

        [Test]
        public void If_given_a_date_that_is_in_the_present_or_past_determine_the_aniversary_date_for_now()
        {
            var actual = "1/31/2011".ToDate().GetAniversaryDate();
            var shouldBe = "5/31/2011".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }

        [Test]
        public void If_given_a_date_that_is_in_present_or_past_determine_the_aniversary_when_given_date_of_target_month()
        {
            var actual = "1/31/2011".ToDate().GetAniversaryDate("2/1/2011".ToDate());
            var shouldBe = "2/28/2011".ToDate();

            Assert.AreEqual(shouldBe, actual);
        }
    }

}
