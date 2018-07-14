using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IEnumerable{TSource}" />
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		///     Appends multiple elements to the given sequence.
		/// </summary>
		/// <param name="source">An <see cref="IEnumerable{TSource}" /> to append additional elements to.</param>
		/// <param name="elements">The additional elements to append.</param>
		/// <returns>An <see cref="IEnumerable{TSource}" /> that contains the additional elements.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="elements" /> is <c>null</c>.</exception>
		public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, params TSource[] elements)
		{
			Contract.Requires<ArgumentNullException>(source != null);
			Contract.Requires<ArgumentNullException>(elements != null);
			Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

			return elements.Length > 0 ? source.Concat(elements) : source;
		}

		/// <summary>
		///     Concatenates multiple sequences.
		/// </summary>
		/// <param name="first">An <see cref="IEnumerable{TSource}" /> to concatenate additional sequences to.</param>
		/// <param name="subsequent">The additional <see cref="IEnumerable{TSource}" /> objects whose elements to append.</param>
		/// <returns>An <see cref="IEnumerable{TSource}" /> that contains the elements of all sequences.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="first" /> or <paramref name="subsequent" /> is <c>null</c>.</exception>
		public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, params IEnumerable<TSource>[] subsequent)
		{
			Contract.Requires<ArgumentNullException>(first != null);
			Contract.Requires<ArgumentNullException>(subsequent != null);
			Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

			return subsequent.Aggregate(first, Enumerable.Concat);
		}

		/// <summary>
		///     Returns whether the enumerable has any elements that match the LINQ qualifier.
		/// </summary>
		/// <example>intList.Contains(i =&gt; i == 2); // false</example>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static bool Contains<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return source.Any(predicate);
		}

		/// <summary>
		///     Returns whether the <see cref="IEnumerable{TSource}" /> is empty
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
		{
			return !source.Any();
		}

		/// <summary>
		/// Returns whether the IEnumerable{TSource} is null or empty
		/// </summary>
		/// <typeparam name="TSource">Source Type</typeparam>
		/// <param name="source">IEnumerable to be compared against</param>
		/// <returns></returns>
		public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
		{
			return source == null || !source.Any();
		}

		/// <summary>
		///     Joins an <see cref="IEnumerable{String}" /> into a single string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string Join(this IEnumerable<string> source, string separator)
		{
			return string.Join(separator, source);
		}

		/// <summary>
		///     Returns the maximum value in a sequence
		/// </summary>
		/// <typeparam name="TSource">Type of objects to compare</typeparam>
		/// <param name="values">Objects to compare</param>
		/// <returns>Object that is the maximum value in a sequence</returns>
		public static TSource Max<TSource>(params TSource[] values)
		{
			IEnumerable<TSource> vals = values.ToList();
			return vals.Max();
		}

		/// <summary>
		///     Returns the minimum value in a sequence
		/// </summary>
		/// <typeparam name="TSource">Type of objects to compare</typeparam>
		/// <param name="values">Objects to compare</param>
		/// <returns></returns>
		public static TSource Min<TSource>(params TSource[] values)
		{
			IEnumerable<TSource> vals = values.ToList();
			return vals.Min();
		}

		/// <summary>
		///     Removes null values from the collection
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> RemoveNull<TSource>(this IEnumerable<TSource> source)
		{
			foreach (var item in source)
			{
				if (item == null)
					continue;
				yield return item;
			}
		}

		/// <summary>
		///     Returns an empty enumerable if null, otherwise returns the enumerable.
		///     <example>
		///         <code>var something = Model.SomeNullEnumerable;
		/// IEnumerable&lt;int&gt; source = something.Safe();
		/// </code>
		///     </example>
		/// </summary>
		public static IEnumerable<TSource> Safe<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null)
			{
				return new TSource[0];
			}

			return source;
		}

		/// <summary>
		///     Takes any IEnumerable and returns a HashSet
		/// </summary>
		/// <param name="source">Ienumerable</param>
		/// <typeparam name="TSource">Generic Class</typeparam>
		/// <returns></returns>
		public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
		{
			return new HashSet<TSource>(source);
		}

		/// <summary>
		///     Returns a string that represents a concatenated list of enumerables
		/// </summary>
		/// <example>new[]{"a", "b", "d", "z"}.ToString(",") => "a,b,d,z"</example>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source">Enumerable to concatenate</param>
		/// <param name="delimiter">Delimiter as a <see cref="string" /> between values</param>
		/// <returns></returns>
		public static string ToString<TSource>(this IEnumerable<TSource> source, string delimiter)
		{
			return string.Join(delimiter, source);
		}

		/// <summary>
		///     Returns the same enumerable, with all its elements trimmed
		/// </summary>
		public static IEnumerable<string> TrimEachElement(this IEnumerable<string> enumerable)
		{
			return enumerable.Select(str => str.Trim());
		}
	}
}
