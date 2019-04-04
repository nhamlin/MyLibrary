using System;
using MyLibrary.Core.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Core.Helpers;

namespace MyLibrary.Core.MSTests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void IsWeekdayTest()
        {
            var sourceDate = new DateTime(2019, 1, 1);
            Assert.IsTrue(sourceDate.IsWeekday());
        }

        [TestMethod()]
        public void IsWeekendTest()
        {
            var sourceDate = new DateTime(2019, 1, 6);
            Assert.IsTrue(sourceDate.IsWeekend());
        }

        [TestMethod()]
        public void IsHolidayTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void FirstMondayOfYearTest()
        {
            var sourceDate = DateHelper.FirstMondayOfYear(2019);
            Assert.IsInstanceOfType(sourceDate, typeof(DateTime));
            Assert.IsTrue(sourceDate.DayOfWeek == DayOfWeek.Monday);
        }

        [TestMethod()]
        public void RangeUntilTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void IsDateTest()
        {
            var sourceDate = DateTime.Now;
            Assert.IsTrue(sourceDate.IsDate());
        }

        [TestMethod()]
        public void AverageTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void SumTest()
        {
            Assert.IsTrue(false);
        }
    }
}