﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
	/// <summary>
	/// Extensions of the DateTime type.
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Determines whether the date falls on Monday-Friday
		/// </summary>
		/// <param name="source"><see cref="DateTime"/> to check</param>
		/// <returns>true/false</returns>
		public static bool IsWeekday(this DateTime source)
		{
			// TODO: Add culture insensitivity (week starts on Monday)
			throw new NotImplementedException();
		}

		/// <summary>
		/// Determines whether the date falls on a weekend
		/// </summary>
		/// <param name="source"><see cref="DateTime"/> to check</param>
		/// <returns>true/false</returns>
		public static bool IsWeekend(this DateTime source)
		{
			// TODO: Add culture insensitivity (week starts on Monday)
			throw new NotImplementedException();
		}

		/// <summary>
		/// Determines whether the date falls on a national holiday.
		/// </summary>
		/// <param name="source"><see cref="DateTime"/> to check</param>
		/// <returns>true/false</returns>
		public static bool IsHoliday(this DateTime source)
		{
			// TODO: Add culture insensitivity (different country's holidays)
			throw new NotImplementedException();
		}

		/// <summary>
		/// Provides a range of dates from the source date to a defined date.
		/// </summary>
		/// <param name="from"><see cref="DateTime"/> that begins the range</param>
		/// <param name="to"><see cref="DateTime"/> that ends the range</param>
		/// <returns>Enumerable list of <see cref="DateTime"/></returns>
		public static IEnumerable<DateTime> RangeUntil(this DateTime from, DateTime to)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an average of a list of <see cref="TimeSpan"/> items.
		/// </summary>
		/// <example>TimeSpan average = timeSpans.Average();</example>
		/// <param name="sourceTimeSpans">Enumerable list of <see cref="TimeSpan"/></param>
		/// <returns><see cref="TimeSpan"/></returns>
		public static TimeSpan Average(this IEnumerable<TimeSpan> sourceTimeSpans)
		{
			IEnumerable<long> ticksPerTimeSpan = sourceTimeSpans.Select(t => t.Ticks);
			double averageTicks = ticksPerTimeSpan.Average();
			long averageTicksLong = Convert.ToInt64(averageTicks);

			TimeSpan averageTimeSpan = TimeSpan.FromTicks(averageTicksLong);

			return averageTimeSpan;
		}

		/// <summary>
		/// Calculates the sum of the given timeSpans.
		/// </summary>
		/// <param name="sources">Enumerable list of <see cref="TimeSpan"/></param>
		/// <returns><see cref="TimeSpan"/></returns>
		public static TimeSpan Sum(this IEnumerable<TimeSpan> sources)
		{
			TimeSpan sumTillNowTimeSpan = TimeSpan.Zero;

			foreach (TimeSpan timeSpan in sources)
			{
				sumTillNowTimeSpan += timeSpan;
			}

			return sumTillNowTimeSpan;
		}

		public static bool IsDate<T>(this T source)
		{
			return source is DateTime || DateTime.TryParse(source.ToString(), out _);
		}
	}
}
