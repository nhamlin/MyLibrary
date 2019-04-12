using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>Reflection extensions</summary>
	/// Use Module to get all global and non-global methods defined in the module.
	/// Use MethodInfo to look at information such as parameters, name, return type, access modifiers and implementation details.
	/// Use EventInfo to find out the event-handler data type, the name, declaring type and custom attributes.
	/// Use ConstructorInfo to get data on the parameters, access modifiers, and implementation details of a constructor.
	/// Use Assembly to load modules listed in the assembly manifest.
	/// Use PropertyInfo to get the declaring type, reflected type, data type, name and writable status of a property or to get and set property values.
	/// Use CustomAttributeData to find out information on custom attributes or to review attributes without having to create more instances.
public static class ReflectionExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(ReflectionExtensions));

		/// <summary>
		/// Changes the type of an object to another type ignoring culture
		/// </summary>
		/// <param name="source">Object to convert</param>
		/// <param name="newType">New type to convert to</param>
		/// <returns></returns>
		public static object ChangeType(this object source, Type newType)
		{
            Contract.Requires<ArgumentNullException>(newType != null);
            Contract.Requires<InvalidCastException>(source != null && !newType.IsValueType);
            Contract.Requires<InvalidCastException>(!(source is IConvertible));

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
		    Contract.Requires<ArgumentNullException>(newType != null);
		    Contract.Requires<InvalidCastException>(source != null && !newType.IsValueType);
		    Contract.Requires<InvalidCastException>(!(source is IConvertible));

            return Convert.ChangeType(source, newType, culture);
		}

		/// <summary>Get an attribute from a member</summary>
		/// <typeparam name="T">Attribute Type</typeparam>
		/// <param name="source">Member to retrieve attribute from</param>
		/// <returns></returns>
		public static T GetAttribute<T>(this MemberInfo source)
			where T : Attribute
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return Attribute.GetCustomAttribute(source, typeof(T)) as T;
		}

		/// <summary>Get an attribute from a type</summary>
		/// <typeparam name="T">Attribute Type</typeparam>
		/// <param name="source">Type to retrieve attribute from</param>
		/// <returns></returns>
		public static T GetAttribute<T>(this Type source)
			where T : Attribute
		{
            Contract.Requires<ArgumentNullException>(source != null);
			return Attribute.GetCustomAttribute(source, typeof(T)) as T;
		}
	}
}
