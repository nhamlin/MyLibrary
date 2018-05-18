using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Extensions
{
	public static class EnumerablesExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
			return source == null || !source.Any();
		}

		public static void CopyTo<T>(this T[] source, T[] target)
		{
			source.CopyTo(target, 0);
		}
	}
}
