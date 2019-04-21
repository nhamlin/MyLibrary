    using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IDataReader"/>
	/// </summary>
	public static class DataReaderExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(DataReaderExtensions));

		/// <summary>
		/// Gets the value of a column from a <see cref="IDataReader"/>
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="rd"><see cref="IDataReader"/></param>
		/// <param name="column">Column Name</param>
		/// <returns></returns>
		public static T Get<T>(this IDataReader rd, string column)
		{
            Contract.Requires<ArgumentNullException>(rd != null);

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
            Contract.Requires<ArgumentNullException>(rd != null);

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

        /// <summary>
        /// This extends the DataReader.GetBoolean by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
	    public static bool GetBoolean(this IDataReader dr, string fieldName)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        var value = false;

	        if (!dr.IsDBNull(fieldOrdinal))
            {
                try
                {
                    value = dr.GetBoolean(fieldOrdinal);
                }
                catch (InvalidCastException)
                {
                    return dr.GetInt16(fieldOrdinal) == 1;
                }
	        }

	        return value;
	    }

        /// <summary>
        /// This extends the DataReader.GetDateTime by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static DateTime GetDateTime(this IDataReader dr, string fieldName, DateTime defaultValue = default(DateTime))
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetDateTime(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetDecimal by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static decimal GetDecimal(this IDataReader dr, string fieldName, decimal defaultValue = 0m)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetDecimal(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetDouble by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static double GetDouble(this IDataReader dr, string fieldName, double defaultValue = 0d)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetDouble(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetFloat by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static float GetFloat(this IDataReader dr, string fieldName, float defaultValue = 0f)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetFloat(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetGuid by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static Guid GetGuid(this IDataReader dr, string fieldName, Guid defaultValue = default(Guid))
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetGuid(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetInt16 by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static short GetInt16(this IDataReader dr, string fieldName, short defaultValue = 0)
        {
            var fieldOrdinal = dr.GetOrdinal(fieldName);
            return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetInt16(fieldOrdinal);
        }

        /// <summary>
        /// This extends the DataReader.GetInt32 by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static int GetInt32(this IDataReader dr, string fieldName, int defaultValue = 0)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetInt32(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetInt64 by allowing it to call by field name instead of position.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static long GetInt64(this IDataReader dr, string fieldName, long defaultValue = 0)
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetInt64(fieldOrdinal);
	    }

        /// <summary>
        /// This extends the DataReader.GetString by allowing it to call by field name instead of position. 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
	    public static string GetString(this IDataReader dr, string fieldName, string defaultValue = "")
	    {
	        var fieldOrdinal = dr.GetOrdinal(fieldName);
	        return dr.IsDBNull(fieldOrdinal) ? defaultValue : dr.GetString(fieldOrdinal);
	    }

        /// <summary>
        /// This allows LINQ operations on a DataReader
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
	    public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader dr)
	    {
	        while (dr.Read())
	        {
	            yield return dr;
	        }
	    }
	}
}
