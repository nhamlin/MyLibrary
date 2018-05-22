using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
	public static class EnumerableExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

		/// <summary>
		/// Returns whether the enumerable does not have any elements. Accepts LINQ for comparison.
		/// </summary>
		/// <example>intList.None(i =&gt; i == 2); // false</example>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static bool IsEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) => !source.Any(predicate);

		public static void CopyTo<T>(this T[] source, T[] target)
		{
			source.CopyTo(target, 0);
		}
	}
}
