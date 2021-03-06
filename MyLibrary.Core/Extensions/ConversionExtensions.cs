﻿using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Security.Cryptography;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for conversions
	/// </summary>
	public static class ConversionExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(ConversionExtensions));

		/// <summary>
		///     Converts one type to another
		/// </summary>
		/// <example>
		///     var age = "28";
		///     var intAge = age.ConvertTo&lt;int&gt;(); => 28
		///     var doubleAge = intAge.ConvertTo&lt;double&gt;(); => 28.0
		///     var dateTimeAge = doubleAge.ConvertTo&lt;DateTime&gt;(); => 1/1/0001 12:00:00AM
		/// </example>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">Item to convert</param>
		/// <returns></returns>
		public static T ConvertTo<T>(this IConvertible value)
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
		///     var intAge = age.ConvertTo&lt;int&gt;(-1); => 28
		///     var doubleAge = intAge.ConvertTo&lt;double&gt;(-1); => 28.0
		///     var dateTimeAge = doubleAge.ConvertTo&lt;DateTime&gt;(DateTime.Today); => {Today's Date}
		/// </example>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="value">Item to convert</param>
		/// <param name="ifError">Value to return if there is an error</param>
		/// <returns></returns>
		public static T ConvertTo<T>(this IConvertible value, T ifError)
		{
            Contract.Requires<ArgumentNullException>(ifError != null);

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

		/// <summary>
		///     Another way to call ConvertTo{T}
		/// </summary>
		/// <typeparam name="T">Type to convert to</typeparam>
		/// <param name="source">Source to convert</param>
		/// <returns></returns>
		public static T GetSafe<T>(this IConvertible source)
		{
			return source.ConvertTo<T>();
		}

		/// <summary>
		///     Implicit hashing
		/// </summary>
		/// <typeparam name="T">
		///     <see cref="HashAlgorithm" />
		/// </typeparam>
		/// <param name="x">Byte array</param>
		/// <returns>Encrypted byte array</returns>
		public static byte[] HashBy<T>(this byte[] x) where T : HashAlgorithm
		{
			HashAlgorithm algorithm;
			try
			{
				algorithm = typeof(T)
				            .GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, new Type[] { }, null)?
				            .Invoke(null, null) as HashAlgorithm;
			}
			catch
			{
				algorithm = Activator.CreateInstance<T>();
			}

			return algorithm?.ComputeHash(x);
		}
	}
}
