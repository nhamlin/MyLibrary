#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Core:MathUtilities.cs
// Usage:          
#endregion

using System.Collections.Generic;
using System.Linq;
using log4net;

namespace MyLibrary.Core.Utilities
{
	/// <summary>
	/// Utilities for handling mathematical operations
	/// </summary>
	public static class MathUtilities
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(MathUtilities));

		/// <summary>
		///     Returns the maximum value in a sequence
		/// </summary>
		/// <typeparam name="T">Type of objects to compare</typeparam>
		/// <param name="values">Objects to compare</param>
		/// <returns>Object that is the maximum value in a sequence</returns>
		public static T Max<T>(params T[] values)
		{
			IEnumerable<T> vals = values.ToList();
			return vals.Max();
		}

		/// <summary>
		///     Returns the minimum value in a sequence
		/// </summary>
		/// <typeparam name="T">Type of objects to compare</typeparam>
		/// <param name="values">Objects to compare</param>
		/// <returns></returns>
		public static T Min<T>(params T[] values)
		{
			IEnumerable<T> vals = values.ToList();
			return vals.Min();
		}
	}
}
