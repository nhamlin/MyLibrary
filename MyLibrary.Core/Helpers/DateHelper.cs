using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core.Helpers
{
    /// <summary>
    /// Helper methods for DateTime objects
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        ///     Returns a <see cref="DateTime" /> object for the first Monday of the year
        /// </summary>
        /// <example>DateTime mnd = DateExtensions.FirstMondayOfYear(2017);</example>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime FirstMondayOfYear(int year)
        {
            DateTime firstDay = new DateTime(year, 1, 1);
            return new DateTime(year, 1, (8 - (int)firstDay.DayOfWeek) % 7 + 1);
        }
    }
}
