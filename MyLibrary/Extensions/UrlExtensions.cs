#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:UrlExtensions.cs
// Usage:          
#endregion

using System;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	/// Extension Methods for URLs
	/// </summary>
	public static class UrlExtensions
	{
		/// <summary>
		/// Returns whether the url is null or empty
		/// </summary>
		/// <param name="url">Uri to check</param>
		/// <returns>True/False</returns>
		public static bool IsNullOrEmpty(this Uri url)
		{
			return string.IsNullOrEmpty(url.AbsoluteUri);
		}
	}
}
