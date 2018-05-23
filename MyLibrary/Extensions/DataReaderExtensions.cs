using System;
using System.Data;

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IDataReader"/>
	/// </summary>
	public static class DataReaderExtensions
	{
		/// <summary>
		/// Gets the value of a column from a <see cref="IDataReader"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="rd"><see cref="IDataReader"/></param>
		/// <param name="column">Column Name</param>
		/// <returns></returns>
		public static T Get<T>(this IDataReader rd, string column)
		{
			return rd.Get(column, default(T));
		}

		/// <summary>
		///     Gets the value of a column in a DataReader, returning a default value if null, then converts it to T.
		/// </summary>
		/// <typeparam name="T">Type</typeparam>
		/// <param name="rd">IDataReader</param>
		/// <param name="column">Column Name</param>
		/// <param name="defaultValue">Value to return if NULL</param>
		/// <returns></returns>
		private static T Get<T>(this IDataReader rd, string column, T defaultValue)
		{
			try
			{
				int ordinal = rd.GetOrdinal(column);

				object value = rd[ordinal];

				if (rd.IsDBNull(ordinal))
				{
					value = defaultValue;
				}

				return (T)Convert.ChangeType(value, typeof(T));
			}
			catch (Exception e)
			{
				throw new FormatException($"Column doesn't exist: [{column}] for the type [{typeof(T)}]", e);
			}
		}
	}
}
