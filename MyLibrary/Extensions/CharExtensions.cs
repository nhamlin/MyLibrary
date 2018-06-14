using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using MyLibrary.Helpers;

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="char" />
	/// </summary>
	public static class CharExtensions
	{
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
		///		Returns a string without any of the given substring inside
		/// </summary>
		/// <param name="source">Source string to extract</param>
		/// <param name="paramStrings">Array of strings to remove from the source string</param>
		/// <returns></returns>
		public static string AllExcept(this string source, params string[] paramStrings)
		{
			foreach (string subString in paramStrings)
			{
				source = source.Replace(subString, string.Empty);
			}

			return source;
		}

		/// <summary>
		///		Returns a string ending with the provided suffix, if it doesn't already end with it
		/// </summary>
		/// <param name="source">Source string</param>
		/// <param name="suffix">Expected suffix</param>
		/// <returns></returns>
		public static string EndWith(this string source, string suffix)
		{
			return source.EndsWith(suffix) ? source : source + suffix;
		}

		/// <summary>
		///		Returns a string beginning with the provided prefix, if it doesn't already begin with it
		/// </summary>
		/// <param name="source">Source string</param>
		/// <param name="prefix">Expected prefix</param>
		/// <returns></returns>
		public static string BeginWith(this string source, string prefix)
		{
			return source.StartsWith(prefix) ? source : source + prefix;
		}

		/// <summary>
		/// Replaces all diacritics in the source string with their romanized counterpart
		/// </summary>
		/// <param name="source">Source string</param>
		/// <returns>Completely Romanized string</returns>
		public static string ReplaceUnicode(this string source) 
		{
			return Constants.Diacritics[source];
		}
	}
}
