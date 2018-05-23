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
	}
}
