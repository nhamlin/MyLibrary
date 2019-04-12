using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;

// ReSharper disable PossibleMultipleEnumeration

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for numbers
	/// </summary>
	public static class NumberExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(NumberExtensions));

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

		/// <summary>
		///     Returns whether the integer is a prime number.
		/// </summary>
		/// <param name="input">Integer to check against</param>
		/// <returns>True/False</returns>
		public static bool IsPrime(this uint input)
		{
			if (input < 3)
			{
				return input == 2;
			}

			return Enumerable.Range(2, (int)Math.Sqrt(input)).All(m => input % m != 0);
		}

		// ReSharper disable once TooManyDeclarations
		/// <summary>
		///     Returns the object(s) that appear the most number of times in the <see cref="IEnumerable{T}" />
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sources"></param>
		/// <returns></returns>
		public static IEnumerable<T> Mode<T>(this IEnumerable<T> sources)
		{
            Contract.Requires<ArgumentNullException>(sources != null);

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
		///     Converts a string to a double
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>String as a double or an double type's default value</returns>
		public static double ParseDoubleOrDefault(this string source)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return source.ParseDoubleOrDefault(default(double));
		}

		/// <summary>
		///     Converts a string to a double
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">Default value to return if the string fails to convert</param>
		/// <returns>String as a double or the default value</returns>
		public static double ParseDoubleOrDefault(this string source, double defaultValue)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return !double.TryParse(source, out double output) ? defaultValue : output;
		}

		/// <summary>
		///     Converts a string to a float
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>String as a float or an float type's default value</returns>
		public static float ParseFloatOrDefault(this string source)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return source.ParseFloatOrDefault(default(float));
		}

		/// <summary>
		///     Converts a string to a float
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">Default value to return if the string fails to convert</param>
		/// <returns>String as a float or the default value</returns>
		public static float ParseFloatOrDefault(this string source, float defaultValue)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return !float.TryParse(source, out float output) ? defaultValue : output;
		}

		/// <summary>
		///     Converts a string to an integer
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>String as an integer or an integer type's default value</returns>
		public static int ParseIntOrDefault(this string source)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return source.ParseIntOrDefault(default(int));
		}

		/// <summary>
		///     Converts a string to an integer
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">Default value to return if the string fails to convert</param>
		/// <returns>String as an integer or the default value</returns>
		public static int ParseIntOrDefault(this string source, int defaultValue)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return !int.TryParse(source, out int output) ? defaultValue : output;
		}

		/// <summary>
		///     Converts a string to a long
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>String as a long or an long type's default value</returns>
		public static long ParseLongOrDefault(this string source)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return source.ParseLongOrDefault(default(long));
		}

		/// <summary>
		///     Converts a string to a long
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">Default value to return if the string fails to convert</param>
		/// <returns>String as a long or the default value</returns>
		public static long ParseLongOrDefault(this string source, long defaultValue)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return !long.TryParse(source, out long output) ? defaultValue : output;
		}

		/// <summary>
		///     Converts a string to a decimal
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>String as a decimal or an decimal type's default value</returns>
		public static decimal ParseDecimalOrDefault(this string source)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return source.ParseDecimalOrDefault(default(decimal));
		}

		/// <summary>
		///     Converts a string to a decimal
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">Default value to return if the string fails to convert</param>
		/// <returns>String as a decimal or the default value</returns>
		public static decimal ParseDecimalOrDefault(this string source, decimal defaultValue)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
            return !decimal.TryParse(source, out decimal output) ? defaultValue : output;
		}
	}
}
