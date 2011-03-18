using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime dateToLeave = new DateTime(2011, 6, 20);
        private readonly DateTime dateToReturn = new DateTime(2011, 10, 15);
        private readonly int miles = 500;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateToLeave, dateToReturn, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceOneWeek()
        {
            var target = new Flight(new DateTime(2011, 1, 1), new DateTime(2011, 1, 8), 500);
            Assert.AreEqual(340, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceOneMonth()
        {
            var target = new Flight(new DateTime(2011, 1, 1), new DateTime(2011, 2, 1), 500);
            Assert.AreEqual(820, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceOneYear()
        {
            var target = new Flight(new DateTime(2011, 1, 1), new DateTime(2012, 1, 1), 500);
            Assert.AreEqual(7500, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectMiles()
        {
            var target = new Flight(new DateTime(2012, 12, 21), new DateTime(2012, 12, 21), 1000);
            Assert.AreEqual(1000, target.Miles);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDate()
        {
            new Flight(new DateTime(2010, 12, 30), new DateTime(2009, 12, 30), 500);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(new DateTime(2011, 12, 30), new DateTime(2012, 12, 30), -500);
        }
	}
}
