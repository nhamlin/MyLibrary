#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:UrlExtensions.cs
// Usage:          
#endregion

using System;
using System.Text;
using System.Web;

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

		/// <summary>
		/// Returns a string decoded from a Url
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string UrlDecode(this string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return HttpUtility.UrlDecode(source);
		}

		/// <summary>
		/// Returns a string encoded as a Url
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string UrlEncode(this string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length <= 32766)
			{
				return Uri.EscapeDataString(source);
			}

			StringBuilder sb = new StringBuilder(source.Length * 2);
			int startIndex = 0;
			while (startIndex < source.Length)
			{
				int len = Math.Min(source.Length - startIndex, 32766);
				string stringToEscape = source.Substring(startIndex, len);
				sb.Append(Uri.EscapeDataString(stringToEscape));
				startIndex += len;
			}

			return sb.ToString();
		}
	}
}
