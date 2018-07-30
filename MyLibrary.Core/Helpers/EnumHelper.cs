using System;
using System.ComponentModel;
using System.Linq;

namespace MyLibrary.Core.Helpers
{
	/// <summary>
	/// Helper methods for <see cref="Enum"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class EnumHelper<T>
	{
		/// <summary>
		/// Retrieves the description listed in an enum's attribute
		/// </summary>
		/// <example>EnumHelper&lt;SomeEnumName&gt;.GetDescription("</example>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string SearchDescriptions(string value)
		{
			Type type = typeof(T);
			var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

			if (name == null)
			{
				return string.Empty;
			}
			var field = type.GetField(name);
			var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
		}
	}
}
