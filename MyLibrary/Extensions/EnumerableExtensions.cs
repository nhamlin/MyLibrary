using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IEnumerable{T}" />
	/// </summary>
	public static class EnumerableExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();
		/// <summary>
		///     Returns whether the <see cref="IEnumerable{T}" /> is empty.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>

		/// <summary>
		///     Returns whether the enumerable has any elements that match the LINQ qualifier.
		/// </summary>
		/// <example>intList.Contains(i =&gt; i == 2); // false</example>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static bool IsEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) => !source.Any(predicate);


		/// <summary>
		/// Same as the <see cref="CopyTo{T}"/> method but defaults to start at index 0.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static void CopyTo<T>(this T[] source, T[] target)
		{
			source.CopyTo(target, 0);
		}

		/// <summary>
		/// Returns a string that represents a concatenated list of enumerables.
		/// </summary>
		/// <example>new[]{"a", "b", "d", "z"}.ToString(",") => "a,b,d,z"</example>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="source">Enumerable to concatenate</param>
		/// <param name="delimiter">Delimiter as a <see cref="string"/> between values</param>
		/// <returns></returns>
		public static string ToString<T>(this IEnumerable<T> source, string delimiter)
		{
			return string.Join(delimiter, source);
		}
		/// <summary>
		///     Appends multiple elements to the given sequence.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{T}" /> to append additional elements to.</param>
		/// <param name="elements">The additional elements to append.</param>
		/// <returns>An <see cref="IEnumerable{T}" /> that contains the additional elements.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="elements" /> is <c>null</c>.</exception>
		/// <summary>
		///     Concatenates multiple sequences.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{T}" /> to concatenate additional sequences to.</param>
		/// <param name="subsequent">The additional <see cref="IEnumerable{T}" /> objects whose elements to append.</param>
		/// <returns>An <see cref="IEnumerable{T}" /> that contains the elements of all sequences.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="first" /> or <paramref name="subsequent" /> is <c>null</c>.</exception>
	}
}
