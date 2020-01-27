#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:UrlExtensions.cs
// Usage:

#endregion header

using log4net;
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
        private static readonly ILog _logger = LogManager.GetLogger(typeof(UrlExtensions));

        /// <summary>
        /// Returns whether the url is null or empty
        /// </summary>
        /// <param name="url">Uri to check</param>
        /// <returns>True/False</returns>
        public static bool IsNullOrEmpty(this Uri url)
        {
            return string.IsNullOrEmpty(url?.AbsoluteUri);
        }

        /// <summary>
        /// Returns a string decoded from a Url
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string UrlDecode(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
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
            if (string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
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

        /// <summary>
        /// Converts a relative Url to an absolute one
        /// </summary>
        /// <param name="source">Must be a relative url</param>
        /// <returns></returns>
        public static string GetAbsoluteUrlFromRelative(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            if (HttpContext.Current == null)
                return source;

            if (source.StartsWith("/"))
                source = source.Insert(0, "~");
            if (!source.StartsWith("~/"))
                source = source.Insert(0, "~/");

            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return String.Format("{0}://{1}{2}{3}",
                url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(source));
        }
    }
}