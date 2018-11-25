#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/10/2018
// Filename: MyLibrary:MyLibrary:ConfigurationUtility.cs
// Usage:

#endregion header

using System;
using System.Configuration;
using log4net;

namespace MyLibrary.Core.Utilities
{
	/// <summary>
	///     Utilities for System Configuration
	/// </summary>
	public class ConfigurationUtility
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(ConfigurationUtility));

		/// <summary>
		///     Tries to read an appsetting strongly typed by using
		///     <see cref="M:System.Convert.ChangeType(System.Object,System.TypeCode)" /> to convert the string value.
		/// </summary>
		/// <typeparam name="T">Target type</typeparam>
		/// <param name="key">The appSetting key</param>
		/// <param name="fallback">
		///     Fallback value to return if the value is not found, or can not be converted to the target type
		///     if <paramref name="throwIfInvalid" /> is false.
		/// </param>
		/// <param name="throwIfInvalid">
		///     If set true, the function will throw if conversion fails. It will *not* throw if the
		///     config value is null (not found).
		/// </param>
		// ReSharper disable once FlagArgument - DRY principle
		public static T GetAppSetting<T>(string key, T fallback, bool throwIfInvalid = false)
		{
			try
			{
				_logger.Info($"GetAppSetting: reading appsetting '{key}'");
				string appSetting = ConfigurationManager.AppSettings[key];
				if (appSetting == null)
				{
					return fallback;
				}

				return (T)Convert.ChangeType(appSetting, typeof(T));
			}
			catch (Exception ex)
			{
				switch (ex)
				{
					case NullReferenceException _:
					case ArgumentNullException _:
						_logger.Error($"GetAppSetting: failed reading appsetting '{key}'", ex);
						break;
					case InvalidCastException _:
						_logger.Error($"GetAppSetting: failed casting appsetting '{key}'", ex);
						break;
					case FormatException _:
						_logger.Warn($"GetAppSetting: failed formatting appsetting '{key}'", ex);
						break;
				}

				if (throwIfInvalid)
				{
					throw;
				}
			}

			return fallback;
		}
	}
}
