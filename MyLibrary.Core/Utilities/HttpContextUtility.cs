#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/16/2018
// Filename: MyLibrary:MyLibrary.Core:HttpContextUtility.cs
// Usage:

#endregion header

using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyLibrary.Core.Utilities
{
	/// <summary>
	///     Utilities for handling Http Context operations
	/// </summary>
	public static class HttpContextUtility
	{
		/// <summary>
		///     Removes the specified action url from the output cache.
		/// </summary>
		/// <param name="actionName">Action</param>
		/// <param name="controllerName">Controller</param>
		/// <param name="context">HttpContext</param>
		public static void ClearRouteOutputCache(string actionName, string controllerName, HttpContextBase context = null)
		{
			if (context == null)
			{
				if (HttpContext.Current == null)
				{
					return;
				}

				context = new HttpContextWrapper(HttpContext.Current);
			}

			string path = new UrlHelper(new RequestContext(context, new RouteData())).Action(actionName, controllerName);
			if (string.IsNullOrEmpty(path))
			{
				return;
			}

			HttpResponse.RemoveOutputCacheItem(path);
		}

		/// <summary>Tries to find the client's real IP address</summary>
		/// <remarks>
		///     Checks HTTP_TRUE_CLIENT_IP (CDNs), HTTP_X_FORWARDED_FOR (behind proxies) and REMOTE_ADDR
		/// </remarks>
		/// <returns>A <see cref="T:System.Net.IPAddress" />, or null if no IP could be determined</returns>
		public static IPAddress GetClientIPAddress(this HttpContextBase context)
		{
			HttpRequestBase request = context?.Request;
			if (request == null)
			{
				return null;
			}

			if (request.QueryString["ip"] != null)
			{
				return IPAddress.Parse(request.QueryString["ip"]);
			}

			IPAddress address;
			string ipString = CheckHeaders(request);

			if (!string.IsNullOrEmpty(ipString))
			{
				if (ipString.ToLower() != "unknown")
				{
					if (ipString.Contains(","))
					{
						ipString = ipString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
						                   .FirstOrDefault();
					}

					if (ipString != null && IPAddress.TryParse(ipString, out address))
					{
						return address;
					}
				}
			}

			if (request.UserHostAddress != null && IPAddress.TryParse(request.UserHostAddress, out address))
			{
				return address;
			}

			return null;
		}

		private static string CheckHeaders(HttpRequestBase request)
		{
			string ipString = request.ServerVariables["HTTP_TRUE_CLIENT_IP"];
			if (!string.IsNullOrEmpty(ipString) && ipString.ToLower() != "unknown")
			{
				return ipString;
			}

			ipString = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (string.IsNullOrEmpty(ipString) || ipString.ToLower() == "unknown")
			{
				ipString = request.ServerVariables["REMOTE_ADDR"];
			}

			return ipString;
		}
	}
}
