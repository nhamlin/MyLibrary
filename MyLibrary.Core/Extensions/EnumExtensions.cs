using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection;
using log4net;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="Enum"/>
	/// </summary>
	public static class EnumExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(EnumExtensions));

		/// <summary>
		/// Returns the Enum's Display Name as found in the Display(Name=xxx) Attribute or the Enum's value name if no attribute is found
		/// </summary>
		/// <typeparam name="TEnum">Enum Type</typeparam>
		/// <param name="value">Enum Value</param>
		/// <returns></returns>
		public static string GetDisplayName<TEnum>(this TEnum value)
		{
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(Enum.GetName(typeof(TEnum), value) != null);

			var staticName = Enum.GetName(typeof(TEnum), value);

			FieldInfo fi = typeof(TEnum).GetField(staticName);
			if (fi.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] attributes && attributes.Length > 0)
			{
				return attributes[0].Name;
			}

			return staticName;
		}
	}
}