using System.Collections.Generic;
using System.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace MyLibrary.Extensions
{
	public static class NumberExtensions
	{
		// ReSharper disable once TooManyDeclarations
		public static IEnumerable<T> Mode<T>(this IEnumerable<T> sources)
		{
			if (sources.IsEmpty())
			{
				return null;
			}

			var groups = sources
						 .GroupBy(x => x)
						 .Select(g => new { Value = g.Key, Count = g.Count() })
						 .ToList();                  // materialize the query to avoid evaluating it twice below
			int maxCount = groups.Max(g => g.Count); // throws InvalidOperationException if myArray is empty
			return groups
				   .Where(g => g.Count == maxCount)
				   .Select(g => g.Value);
		}
	}
}