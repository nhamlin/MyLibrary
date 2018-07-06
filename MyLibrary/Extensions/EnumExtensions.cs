using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="Enum"/>
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Returns the Enum's Display Name as found in the Display(Name=xxx) Attribute or the Enum's value name if no attribute is found
		/// </summary>
		/// <typeparam name="TEnum">Enum Type</typeparam>
		/// <param name="value">Enum Value</param>
		/// <returns></returns>
		public static string GetDisplayName<TEnum>(this TEnum value)
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}

			var staticName = Enum.GetName(typeof(TEnum), value) ?? throw new NullReferenceException();

			FieldInfo fi = typeof(TEnum).GetField(staticName);
			if (fi.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] attributes && attributes.Length > 0)
			{
				return attributes[0].Name;
			}

			return staticName;
		}
	}
}