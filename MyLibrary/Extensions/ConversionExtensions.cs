using System;

namespace MyLibrary.Extensions
{
	public static class ConversionExtensions
	{
		/// <summary>
		///     Converts one type to another
		/// </summary>
		/// <example>
		///     var age = "28";
		///     var intAge = age.To&lt;int&gt;();
		///     var doubleAge = intAge.To&lt;double&gt;();
		///     var decimalAge = doubleAge.To&lt;decimal&gt;();
		/// </example>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">Item to convert</param>
		/// <returns></returns>
		public static T To<T>(this IConvertible value)
		{
			try
			{
				if (value == null || value.Equals(""))
				{
					return default(T);
				}

				Type t = typeof(T);
				Type u = Nullable.GetUnderlyingType(t);

				return u != null
					? (T)Convert.ChangeType(value, u)
					: (T)Convert.ChangeType(value, t);
			}

			catch
			{
				return default(T);
			}
		}

		/// <summary>
		///     Converts one type to another
		/// </summary>
		/// <example>
		///     var age = "28";
		///     var intAge = age.To&lt;int&gt;(-1);
		///     var doubleAge = intAge.To&lt;double&gt;(-1);
		///     var decimalAge = doubleAge.To&lt;decimal&gt;(-1);
		/// </example>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">Item to convert</param>
		/// <param name="ifError">Value to return if there is an error</param>
		/// <returns></returns>
		public static T To<T>(this IConvertible value, T ifError)
		{
			try
			{
				if (value == null || value.Equals(""))
				{
					return ifError;
				}

				Type t = typeof(T);
				Type u = Nullable.GetUnderlyingType(t);

				return u != null
					? (T)Convert.ChangeType(value, u)
					: (T)Convert.ChangeType(value, t);
			}
			catch
			{
				return ifError;
			}
		}
	}
}
