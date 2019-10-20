using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IEnumerable{T}" />
	/// </summary>
	public static class EnumerableExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(EnumerableExtensions));

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
		///     Returns whether the sequence has any elements that match the LINQ qualifier.
		/// </summary>
		/// <example>intList.Contains(i =&gt; i == 2); // false</example>
		/// <typeparam name="TSource">Object type</typeparam>
		/// <param name="source">Source Enumerable</param>
		/// <param name="predicate">LINQ statement to search for</param>
		/// <returns></returns>
		public static bool Contains<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
			return source.Any(predicate);
		}

		/// <summary>
		///     Returns whether the sequence has any elements that match the object.
		/// </summary>
		/// <example>intList.Contains("something"); // false</example>
		/// <typeparam name="TSource">Object type</typeparam>
		/// <param name="source">Source Enumerable</param>
		/// <param name="predicate">Object to search for</param>
		/// <returns></returns>
		public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource predicate)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
			var sourceHash = source.ToHashSet();
			return sourceHash.Contains(predicate);
		}

		/// <summary>
		///     Selects distinct items from a sequence by using a comparison delegate.
		/// </summary>
		/// <typeparam name="T">The type of elements in the sequence</typeparam>
		/// <typeparam name="TKey">The comparison expression.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="keySelector">The comparison key selector.</param>
		/// <param name="comparer">A optional comparer to compare the key items.</param>
		public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(keySelector != null);
			return source.GroupBy(keySelector, comparer).Select(g => g.First());
		}

		/// <summary>
		///     Pics a random element from <paramref name="source" />. If the enumerable is null or empty, default(T) is returned.
		/// </summary>
		/// <typeparam name="T">Type of elements in <paramref name="source" /></typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="seed">Optional random seed</param>
		/// <returns>A random <typeparamref name="T" /> from <paramref name="source" />, or default(T) if source is null or empty</returns>
		public static T GetRandomItem<T>(this IEnumerable<T> source, int? seed = null)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			IEnumerable<T> sourceList = source.ToList();
			if (sourceList.IsNullOrEmpty())
			{
				return default(T);
			}

			int num = sourceList.Count();
			int index = new Random((seed.HasValue ? seed.GetValueOrDefault() + num : new int?()) ?? Environment.TickCount).Next(sourceList.Count());
			return sourceList.ElementAt(index);
		}

		/// <summary>
		///     Returns an empty enumerable if null, otherwise returns the enumerable.
		///     <example>
		///         <code>var something = Model.SomeNullEnumerable;
		/// IEnumerable&lt;int&gt; source = something.GetSafeVersion();
		/// </code>
		///     </example>
		/// </summary>
		public static IEnumerable<T> GetSafeVersion<T>(this IEnumerable<T> source)
		{
			return source ?? Enumerable.Empty<T>();
		}

		/// <summary>
		///     [Obsolete] Returns whether the enumerable has any elements that match the object.
		/// </summary>
		/// <example>intList.Contains("something"); // false</example>
		/// <typeparam name="TSource">Object type</typeparam>
		/// <param name="source">Source Enumerable</param>
		/// <param name="predicate">Object to search for</param>
		/// <returns></returns>
		[Obsolete("Use .Contains<T> instead.")]
		public static bool Has<TSource>(this IEnumerable<TSource> source, TSource predicate)
		{
		    Contract.Requires<ArgumentNullException>(source != null);
		    Contract.Requires<ArgumentNullException>(predicate != null);
            return source.Contains(predicate);
		}

		/// <summary>
		///     Returns whether the enumerable has any elements that match the LINQ qualifier.
		/// </summary>
		/// <example>intList.Contains(i =&gt; i == 2); // false</example>
		/// <typeparam name="TSource">Object type</typeparam>
		/// <param name="source">Source Enumerable</param>
		/// <param name="predicate">LINQ statement to search for</param>
		/// <returns></returns>
		[Obsolete("Use .Contains<T> instead.")]
		public static bool Has<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
			return source.Contains(predicate);
		}

		/// <summary>
		///     <para>
		///         Returns whether the <see cref="IEnumerable{T}" /> is empty
		///     </para>
		///     <para>
		///         Will throw an error if {T} is null.
		///     </para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return !source.Any();
		}

		/// <summary>
		///     Returns whether the IEnumerable{TSource} is null or empty
		/// </summary>
		/// <typeparam name="T">Source Type</typeparam>
		/// <param name="source">IEnumerable to be compared against</param>
		/// <returns></returns>
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				return true;
			}

			using (IEnumerator<T> enumerator = source.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		///     Joins an <see cref="IEnumerable{String}" /> into a single string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static string Join(this IEnumerable<string> source, string delimiter)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return string.Join(delimiter, source);
		}

		/// <summary>
		///     Removes null values from the collection
		/// </summary>
		/// <typeparam name="T">Object type</typeparam>
		/// <param name="source">Source Enumerable</param>
		/// <returns></returns>
		public static IEnumerable<T> RemoveNulls<T>(this IEnumerable<T> source)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			// yield return is faster than LINQ's .Where()
			foreach (var item in source)
			{
				if (item == null)
				{
					continue;
				}

				yield return item;
			}
		}

		/// <summary>
		///     Takes any IEnumerable and returns a HashSet
		/// </summary>
		/// <param name="source">Source Enumerable</param>
		/// <typeparam name="T">Object type</typeparam>
		/// <returns></returns>
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return new HashSet<T>(source);
		}

		/// <summary>
		///     Returns a string that represents a concatenated list of enumerables
		/// </summary>
		/// <example>new[]{"a", "b", "d", "z"}.ToString(",") => "a,b,d,z"</example>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">Enumerable to concatenate</param>
		/// <param name="delimiter">Delimiter as a <see cref="string" /> between values</param>
		/// <returns></returns>
		public static string ToString<T>(this IEnumerable<T> source, string delimiter)
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return string.Join(delimiter, source);
		}

		/// <summary>
		///     Returns the same enumerable, with all its elements trimmed
		/// </summary>
		public static IEnumerable<string> TrimEachElement(this IEnumerable<string> source)
		{
			Contract.Requires<ArgumentNullException>(source != null);
			foreach (var item in source)
			{
				yield return item.Trim();
			}
		}

		/// <summary>
		///     Finds all items in <paramref name="values" /> that are found within the Enumerable <paramref name="source" />
		///     using a LINQ delegate
		/// </summary>
		/// <typeparam name="T">Type of item to search or search for</typeparam>
		/// <param name="source">Source Enumerable to search in</param>
		/// <param name="predicate">An delegate used to compare the items</param>
		/// <param name="values">Enumerable of values to check</param>
		/// <returns>The items of <paramref name="values" /> that exist in <paramref name="source" /></returns>
		public static IEnumerable<T> WhereIn<T>(this IEnumerable<T> source, Func<T, T> predicate, IEnumerable<T> values)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
            Contract.Requires<ArgumentNullException>(values != null);
			return values.Where(v => predicate(v).IsIn(source));
		}

		/// <summary>
		///     Finds all items in <paramref name="values" /> that are found within the Enumerable <paramref name="source" />
		/// </summary>
		/// <typeparam name="T">Type of item to search</typeparam>
		/// <param name="source">Source Enumerable to search in</param>
		/// <param name="values">Enumerable of values to check</param>
		/// <returns>The items of <paramref name="values" /> that exist in <paramref name="source" /></returns>
		public static IEnumerable<T> WhereIn<T>(this IEnumerable<T> source, IEnumerable<T> values)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(values != null);
			var valueHash = values.ToHashSet();

			foreach (var item in source)
			{
				if (valueHash.Contains(item))
				{
					yield return item;
				}
			}
		}

		/// <summary>
		///     Finds all items in <paramref name="values" /> that are not found within the Enumerable <paramref name="source" />
		///     using a LINQ delegate
		/// </summary>
		/// <typeparam name="T">Type of item to search or search for</typeparam>
		/// <param name="source">Source Enumerable to search in</param>
		/// <param name="predicate">An delegate used to compare the items</param>
		/// <param name="values">Enumerable of values to check</param>
		/// <returns>The items of <paramref name="values" /> that do not exist in <paramref name="source" /></returns>
		public static IEnumerable<T> WhereNotIn<T>(this IEnumerable<T> source, Func<T, T> predicate, IEnumerable<T> values)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(predicate != null);
            Contract.Requires<ArgumentNullException>(values != null);
			return values.Where(v => !predicate(v).IsIn(source));
		}

		/// <summary>
		///     Finds all items in <paramref name="values" /> that are not found within the Enumerable <paramref name="source" />
		/// </summary>
		/// <typeparam name="T">Type of item to search</typeparam>
		/// <param name="source">Source Enumerable to search in</param>
		/// <param name="values">Enumerable of values to check</param>
		/// <returns>The items of <paramref name="values" /> that do not exist in <paramref name="source" /></returns>
		public static IEnumerable<T> WhereNotIn<T>(this IEnumerable<T> source, IEnumerable<T> values)
		{
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(values != null);
			var valueHash = values.ToHashSet();

			foreach (var item in source)
			{
				if (!valueHash.Contains(item))
				{
					yield return item;
				}
			}
		}
        
    }
}