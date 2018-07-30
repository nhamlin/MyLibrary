using System;
using System.Web;

namespace MyLibrary.Core.Services
{
	/// <summary>
	/// Services to handle cookie manipulation
	/// </summary>
	public class CookieService
	{
		/// <summary>
		/// Get a specific cookie
		/// </summary>
		/// <param name="cookie"></param>
		/// <returns></returns>
		public virtual string Get(string cookie)
		{
			if (HttpContext.Current == null)
			{
				return null;
			}

			return HttpContext.Current.Request.Cookies[cookie] == null ? null : HttpContext.Current.Request.Cookies[cookie].Value;
		}

		/// <summary>
		/// Set a specific cookie
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="value"></param>
		public virtual void Set(string cookie, string value)
		{
			if (HttpContext.Current != null)
			{
				var httpCookie = new HttpCookie(cookie)
				{
					Value = value,
					Expires = DateTime.Now.AddYears(1)
				};

				Set(HttpContext.Current.Response.Cookies, httpCookie);
				HttpContext.Current.Request.Cookies.Set(httpCookie);
			}
		}

		/// <summary>
		/// Delete a specific cookie
		/// </summary>
		/// <param name="cookie"></param>
		public virtual void Remove(string cookie)
		{
			if (HttpContext.Current != null)
			{
				var httpCookie = new HttpCookie(cookie)
				{
					Expires = DateTime.Now.AddDays(-1)
				};

				Set(HttpContext.Current.Response.Cookies, httpCookie);
			}
		}

		private void Set(HttpCookieCollection cookieCollection, HttpCookie cookie)
		{
			cookieCollection.Add(cookie);
		}
	}
}
