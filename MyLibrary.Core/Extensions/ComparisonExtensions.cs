using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for comparisons
	/// </summary>
	public static class ComparisonExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(ComparisonExtensions));

		/// <summary>
		///     Determines if an object can be found inside a generic list
		///     Replaces: if (someString == "string1" || someString == "string2" || someString == "string3")
		/// </summary>
		/// <example>if(someString.IsIn("string1", "string2", "string3"))</example>
		/// <typeparam name="T">Generic</typeparam>
		/// <param name="source"></param>
		/// <param name="list"></param>
		/// <returns></returns>
		public static bool IsIn<T>(this T source, params T[] list)
		{
            Contract.Requires<ArgumentNullException>(source != null);

			return list.Contains(source);
		}

		/// <summary>
		///     Determines if an object can be found inside a generic list
		///     Replaces: if (someString == "string1" || someString == "string2" || someString == "string3")
		/// </summary>
		/// <example>
		///     var inclusionList = new List&lt;string&gt; { "inclusion1", "inclusion2" };
		///     var query = myEntities.MyEntity
		///     .Select(e => e.Name)
		///     .Where(e => e.IsIn(inclusionList));
		/// </example>
		/// <typeparam name="T">Generic</typeparam>
		/// <param name="source">Generic being </param>
		/// <param name="list"></param>
		/// <returns></returns>
		public static bool IsIn<T>(this T source, IEnumerable<T> list)
		{
            Contract.Requires<ArgumentNullException>(source != null);

			return list.Contains(source);
		}
	}
}
