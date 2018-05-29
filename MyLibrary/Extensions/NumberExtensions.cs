using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable PossibleMultipleEnumeration

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for numbers
	/// </summary>
	public static class NumberExtensions
	{
		// ReSharper disable once TooManyDeclarations
		/// <summary>
		///     Returns the object(s) that appear the most number of times in the <see cref="IEnumerable{T}" />
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sources"></param>
		/// <returns></returns>
		public static IEnumerable<T> Mode<T>(this IEnumerable<T> sources)
		{
			if (sources.IsEmpty())
			{
				return null;
			}

			var groups = sources
			             .GroupBy(x => x)
			             .Select(g => new { Value = g.Key, Count = g.Count() })
			             .ToList();
			int maxCount = groups.Max(g => g.Count);
			return groups
			       .Where(g => g.Count == maxCount)
			       .Select(g => g.Value);
		}

		/// <summary>
		/// Returns whether the integer is a prime number.
		/// </summary>
		/// <param name="input">Integer to check against</param>
		/// <returns>True/False</returns>
		public static bool IsPrime(this int input)
		{
			if (input < 3)
				return (input == 2);
			return Enumerable.Range(2, (int)Math.Sqrt(input)).All(m => input % m != 0);
		}

		/// <summary>
		///     Checks if the value is in given range
		/// </summary>
		public static bool IsInRange(this int value, int min, int max)
		{
			return value >= min && value <= max;
		}

		/// <summary>
		///     Checks if the value is in given range
		/// </summary>
		public static bool IsInRange(this double value, double min, double max)
		{
			return value >= min && value <= max;
		}

		/// <summary>
		///     Checks if the value is in given range
		/// </summary>
		public static bool IsInRange(this float value, float min, float max)
		{
			return value >= min && value <= max;
		}

		/// <summary>
		///     Checks if the value is in given range
		/// </summary>
		public static bool IsInRange(this decimal value, decimal min, decimal max)
		{
			return value >= min && value <= max;
		}
	}
}
