using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace MyLibrary.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="String"/>
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Returns whether the string is completely empty, including white spaces.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string source)
		{
			return string.IsNullOrWhiteSpace(source);
		}

		/// <summary>
		/// Returns the string with the first letter in upper case.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string InitialLetterToUpper(this string source)
		{
			return char.ToUpperInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		/// Returns the string with the first letter in lower case.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string InitialLetterToLower(this string source)
		{
			return char.ToLowerInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		/// Returns the string with the first letter in either upper or lower case depending on the word before it.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ProperCapitalization(this string source)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Encrypts the string based on the provided <see cref="EncryptionPolicy"/>
		/// </summary>
		/// <param name="source"></param>
		/// <param name="encryptionPolicy"></param>
		/// <returns></returns>
		public static string Encrypt(this string source, EncryptionPolicy encryptionPolicy)
		{
            throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the last character from the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string RemoveLastCharacter(this string source)
		{
			return source.Substring(0, source.Length - 1);
		}

		/// <summary>
		/// Removes a number of characters from the end of the string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="numberOfChars"></param>
		/// <returns></returns>
		public static string RemoveLastCharacters(this string source, int numberOfChars)
		{
			return source.Substring(0, source.Length - numberOfChars);
		}

		/// <summary>
		/// Removes the last character from the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string RemoveFirstCharacter(this string source)
		{
			return source.Substring(1);
		}

		/// <summary>
		/// Removes a number of characters from the end of the string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="numberOfChars"></param>
		/// <returns></returns>
		public static string RemoveFirstCharacters(this string source, int numberOfChars)
		{
			return source.Substring(numberOfChars);
		}

		/// <summary>
		/// Removes a substring from a string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="substring"></param>
		/// <returns></returns>
		public static string RemoveSubstring(this string source, string substring)
		{
			return source.Replace(substring, string.Empty);
		}

		/// <summary>
		/// Reverses the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
        public static string Reverse(this string source) {
            char[] chars = source.ToCharArray();
            Array.Reverse(chars);
            return chars.ToSafeString();
        }

		/// <summary>
		///  Converts an array of characters to a safe string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
        public static string ToSafeString(this char[] source) {
			return source == null ? null : new string(source);
		}

		/// <summary>
		/// Splits the string by pascal case.		
		/// </summary>
		/// <example>
		/// The following returns "This Is A Pascal Case String"
		/// <code>
		/// var str = "ThisIsAPascalCaseString";
		/// return str.SplitPascalCase();
		/// </code>
		/// </example>
		/// <param name="text">The text.</param>
		/// <returns></returns>
		public static string SplitPascalCase(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			return Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
		}

		/// <summary>
		/// Joins an <see cref="IEnumerable{String}"/> into a single string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string Join(this IEnumerable<string> source, string separator) => string.Join(separator, source);

		/// <summary>
		/// Returns only the digits inside of a string
		/// </summary>
		/// <param name="source">Source string</param>
		/// <returns>All digits in the string</returns>
		public static string OnlyDigits(this string source)
		{
			return new string(source?.Where(char.IsDigit).ToArray());
		}

		/// <summary>
		/// Returns whether the string is blank (white space characters ignored because then it wouldn't be 'blank')
		/// </summary>
		/// <example>" ".IsBlank() => false;
		/// "".IsBlank() => true;</example>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsBlank(this string source)
		{
			return string.IsNullOrEmpty(source);
		}
	}
}