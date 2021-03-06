﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;

namespace MyLibrary.Core.Extensions
{
    /// <summary>
    ///     Extension methods for <see cref="DateTime" />
    /// </summary>
    public static class DateTimeExtensions
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DateTimeExtensions));

        #region Date Functions

        /// <summary>
        ///     Returns the last minute of the day (23:59:59)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime source)
        {
            Contract.Requires<ArgumentNullException>(source != DateTime.MaxValue);

            return source.AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        ///     Determines whether the date falls on Monday-Friday
        /// </summary>
        /// <param name="source"><see cref="DateTime" /> to check</param>
        /// <returns>true/false</returns>
        public static bool IsWeekday(this DateTime source)
        {
            return (source.DayOfWeek != DayOfWeek.Saturday && source.DayOfWeek != DayOfWeek.Sunday);
            // TODO: Add culture insensitivity (week starts on Monday)
        }

        /// <summary>
        ///     Determines whether the date falls on a weekend
        /// </summary>
        /// <param name="source"><see cref="DateTime" /> to check</param>
        /// <returns>true/false</returns>
        public static bool IsWeekend(this DateTime source)
        {
            return source.DayOfWeek == DayOfWeek.Saturday || source.DayOfWeek == DayOfWeek.Sunday;
            // TODO: Add culture insensitivity (week starts on Monday)
        }

        /// <summary>
        ///     Determines whether the date falls on a national holiday.
        /// </summary>
        /// <param name="source"><see cref="DateTime" /> to check</param>
        /// <returns>true/false</returns>
        public static bool IsHoliday(this DateTime source)
        {
            // TODO: Add culture insensitivity (different country's holidays)
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Provides a range of dates from the source date to a defined date.
        /// </summary>
        /// <param name="from"><see cref="DateTime" /> that begins the range</param>
        /// <param name="to"><see cref="DateTime" /> that ends the range</param>
        /// <returns>Enumerable list of <see cref="DateTime" /></returns>
        public static IEnumerable<DateTime> RangeUntil(this DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns whether the object represents a valid date
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="source">Object</param>
        /// <returns></returns>
        public static bool IsDate<T>(this T source)
        {
            Contract.Requires<ArgumentNullException>(source != null);

            return source is DateTime || DateTime.TryParse(source.ToString(), out _);
        }

        #endregion Date Functions

        #region Time Functions

        /// <summary>
        ///     Returns an average of a list of <see cref="TimeSpan" /> items.
        /// </summary>
        /// <example>TimeSpan average = timeSpans.Average();</example>
        /// <param name="sourceTimeSpans">Enumerable list of <see cref="TimeSpan" /></param>
        /// <returns>
        ///     <see cref="TimeSpan" />
        /// </returns>
        public static TimeSpan Average(this IEnumerable<TimeSpan> sourceTimeSpans)
        {
            Contract.Requires<ArgumentNullException>(sourceTimeSpans != null);

            IEnumerable<long> ticksPerTimeSpan = sourceTimeSpans.Select(t => t.Ticks);
            double averageTicks = ticksPerTimeSpan.Average();
            long averageTicksLong = Convert.ToInt64(averageTicks);

            TimeSpan averageTimeSpan = TimeSpan.FromTicks(averageTicksLong);

            return averageTimeSpan;
        }

        /// <summary>
        ///     Calculates the sum of the given timeSpans.
        /// </summary>
        /// <param name="sources">Enumerable list of <see cref="TimeSpan" /></param>
        /// <returns>
        ///     <see cref="TimeSpan" />
        /// </returns>
        public static TimeSpan Sum(this IEnumerable<TimeSpan> sources)
        {
            Contract.Requires<ArgumentNullException>(sources != null);

            TimeSpan sumTillNowTimeSpan = TimeSpan.Zero;

            foreach (TimeSpan timeSpan in sources)
            {
                sumTillNowTimeSpan += timeSpan;
            }

            return sumTillNowTimeSpan;
        }

        #endregion Time Functions
    }
}
