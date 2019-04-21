using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	/// Extension methods for Dictionaries and Arrays.
	/// </summary>
	public static class DictionaryExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(DictionaryExtensions));

		/// <summary>
		///     Returns the key of the highest value in a dictionary.
		/// </summary>
		/// <typeparam name="TKey">The key type</typeparam>
		/// <typeparam name="TValue">Value type, must implement IComparable&lt;Value&gt;</typeparam>
		/// <param name="dictionary">The dictionary</param>
		/// <returns>The key of the highest value in the dictionary.</returns>
		public static TKey MaxKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
			where TValue : IComparable<TValue>
		{
			if (dictionary == null || dictionary.Count == 0)
			{
				return default(TKey);
			}

			var dictList = dictionary.ToList();
			var maxKvp = dictList.First();
			foreach (var kvp in dictList.Skip(1))
			{
				if (kvp.Value.CompareTo(maxKvp.Value) > 0)
				{
					maxKvp = kvp;
				}
			}

			return maxKvp.Key;
		}

		/// <summary>
		///     Returns the maximum value in the dictionary.
		/// </summary>
		/// <param name="dictionary">The dictionary</param>
		/// <typeparam name="TKey">The key type</typeparam>
		/// <typeparam name="TValue">The value type</typeparam>
		/// <returns></returns>
		public static TValue MaxValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
		{
            Contract.Requires<ArgumentNullException>(dictionary != null);

			return dictionary.Values.Max();
		}

		/// <summary>
		/// Same as the <see cref="CopyTo{T}"/> method but defaults to start at index 0.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static void CopyTo<T>(this T[] source, T[] target)
		{
            Contract.Requires<ArgumentNullException>(source != null);

			source.CopyTo(target, 0);
		}
	}
}
