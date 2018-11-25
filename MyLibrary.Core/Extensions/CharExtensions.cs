using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using log4net;
using MyLibrary.Core.Helpers;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="char" />
	/// </summary>
	public static class CharExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(CharExtensions));

		/// <summary>
		///     Converts the Unicode value of this character to its equivalent 4-character hexadecimal string representation
		/// </summary>
		/// <param name="ch">A character to convert to a hexadecimal string</param>
		/// <returns>The equivalent 4-character hexadecimal string representation</returns>
		[Pure]
		public static string ToHex(this char ch)
		{
			Contract.Ensures(Contract.Result<string>() != null);
			Contract.Ensures(Contract.Result<string>().Length == 4);

			return string.Join(string.Empty, BitConverter.GetBytes(ch).Reverse().Select(_ => $"{_,2:X}"))
			             .Replace(' ', '0');
		}

		/// <summary>
		///     Converts a character to uppercase
		/// </summary>
		/// <param name="c">Character to convert</param>
		/// <returns>Character in uppercase</returns>
		public static char ToUpper(this char c)
		{
			return char.ToUpper(c);
		}

		/// <summary>
		///     Converts a character to lowercase
		/// </summary>
		/// <param name="c">Character to convert</param>
		/// <returns>Character in lowercase</returns>
		public static char ToLower(this char c)
		{
			return char.ToLower(c);
		}

		/// <summary>
		///     Converts a character to uppercase, without a specific culture
		/// </summary>
		/// <param name="c">Character to convert</param>
		/// <returns>Character in uppercase</returns>
		public static char ToUpperInvariant(this char c)
		{
			return char.ToUpperInvariant(c);
		}

		/// <summary>
		///     Converts a character to lowercase, without a specific culture
		/// </summary>
		/// <param name="c">Character to convert</param>
		/// <returns>Character in lowercase</returns>
		public static char ToLowerInvariant(this char c)
		{
			return char.ToLowerInvariant(c);
		}

		/// <summary>
		///     Converts a char to a string with an invariant culture format
		/// </summary>
		/// <param name="c">Character to convert</param>
		/// <returns>Character as a string with an invariant culture</returns>
		public static string ToStringInvariant(this char c)
		{
			return c.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Replaces the character diacritic with its romanized counterpart string
		/// </summary>
		/// <param name="source">Source character</param>
		/// <returns>Character represented in its romanized form</returns>
		public static string ReplaceUnicode(this char source) 
		{
			return Constants.Diacritics[source.ToString()];
		}
	}
}
