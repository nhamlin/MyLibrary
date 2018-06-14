using System;
using System.Globalization;
using System.Reflection;

namespace MyLibrary.Extensions
{
	/// <summary>Reflection extensions</summary>
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Changes the type of an object to another type ignoring culture
		/// </summary>
		/// <param name="source">Object to convert</param>
		/// <param name="newType">New type to convert to</param>
		/// <returns></returns>
		public static object ChangeType(this object source, Type newType)
		{
			return Convert.ChangeType(source, newType);
		}

		/// <summary>
		/// Changes the type of an object to another type, with culture specificity
		/// </summary>
		/// <param name="source">Object to convert</param>
		/// <param name="newType">New type to convert to</param>
		/// <param name="culture">Culture</param>
		/// <returns></returns>
		public static object ChangeType(this object source, Type newType, CultureInfo culture)
		{
			return Convert.ChangeType(source, newType, culture);
		}

		/// <summary>Get an attribute from a member</summary>
		/// <typeparam name="T">Attribute Type</typeparam>
		/// <param name="source">Member to retrieve attribute from</param>
		/// <returns></returns>
		public static T GetAttribute<T>(this MemberInfo source)
			where T : Attribute
		{
			return Attribute.GetCustomAttribute(source, typeof(T)) as T;
		}

		/// <summary>Get an attribute from a type</summary>
		/// <typeparam name="T">Attribute Type</typeparam>
		/// <param name="source">Type to retrieve attribute from</param>
		/// <returns></returns>
		public static T GetAttribute<T>(this Type source)
			where T : Attribute
		{
			return Attribute.GetCustomAttribute(source, typeof(T)) as T;
		}
	}
}
