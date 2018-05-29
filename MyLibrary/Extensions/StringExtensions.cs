using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text.RegularExpressions;
using Humanizer;

namespace MyLibrary.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="string" />
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		///     Returns whether the string is completely empty, including white spaces.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string source)
		{
			return string.IsNullOrWhiteSpace(source);
		}

		/// <summary>
		///     Returns the string with the first letter in upper case.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string InitialLetterToUpper(this string source)
		{
			return char.ToUpperInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		///     Returns the string with the first letter in lower case.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string InitialLetterToLower(this string source)
		{
			return char.ToLowerInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		///     Returns the string with the first letter in either upper or lower case depending on the word before it.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ProperCapitalization(this string source)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Encrypts the string based on the provided <see cref="EncryptionPolicy" />
		/// </summary>
		/// <param name="source"></param>
		/// <param name="encryptionPolicy"></param>
		/// <returns></returns>
		public static string Encrypt(this string source, EncryptionPolicy encryptionPolicy)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Removes the last character from the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string TruncateLastChar(this string source)
		{
			return source.Substring(0, source.Length - 1);
		}

		/// <summary>
		///     Removes a number of characters from the end of the string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="numberOfChars"></param>
		/// <returns></returns>
		public static string TruncateFromRight(this string source, int numberOfChars)
		{
			return source.Truncate(numberOfChars, null, Truncator.FixedLength, TruncateFrom.Right);
		}

		/// <summary>
		///     Removes the last character from the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string TruncateFirstChar(this string source)
		{
			return source.Substring(1);
		}

		/// <summary>
		///     Removes a number of characters from the end of the string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="numberOfChars"></param>
		/// <returns></returns>
		public static string TruncateFromLeft(this string source, int numberOfChars)
		{
			return source.Truncate(numberOfChars, null, Truncator.FixedLength, TruncateFrom.Left);
		}

		/// <summary>
		///     Removes a substring from a string.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="substring"></param>
		/// <returns></returns>
		public static string RemoveSubstring(this string source, string substring)
		{
			return source.Replace(substring, string.Empty);
		}

		/// <summary>
		///     Reverses the string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string Reverse(this string source)
		{
			char[] chars = source.ToCharArray();
			Array.Reverse(chars);
			return chars.ToSafeString();
		}

		/// <summary>
		///     Converts an array of characters to a safe string.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string ToSafeString(this char[] source)
		{
			return source == null ? default(string) : new string(source);
		}

		/// <summary>
		///     Splits the string by pascal case.
		/// </summary>
		/// <example>
		///     The following returns "This Is A Pascal Case String"
		///     <code>
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
		///     Splits the string by underlines.
		/// </summary>
		/// <example>
		///     The following returns "This Is An Underlined String"
		///     <code>
		/// var str = "This_Is_An_Underlined_String";
		/// return str.SplitUnderlines();
		/// </code>
		/// </example>
		/// <param name="text">The text.</param>
		/// <returns></returns>
		public static string SplitUnderlines(this string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}

			return Regex.Replace(text, "(_)", " $1", RegexOptions.Compiled).Trim();
		}

		/// <summary>
		///     Returns only the digits inside of a string
		/// </summary>
		/// <param name="source">Source string</param>
		/// <returns>All digits in the string</returns>
		public static string OnlyDigits(this string source)
		{
			return new string(source?.Where(char.IsDigit).ToArray());
		}

		/// <summary>
		///     Returns whether the string is blank (white space characters ignored because then it wouldn't be 'blank')
		/// </summary>
		/// <example>
		///     " ".IsBlank() => false;
		///     "".IsBlank() => true;
		/// </example>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsBlank(this string source)
		{
			return string.IsNullOrEmpty(source);
		}

		/// <summary>
		///		Returns a collection of characters that do not appear in both strings
		/// </summary>
		/// <param name="source">Source string</param>
		/// <param name="other">Comparer string</param>
		/// <returns></returns>
		public static char[] StringDifference(this string source, string other)
		{
			string longest = source.Length >= other.Length ? source : other;
			string shortest = source.Length < other.Length ? source : other;

			return longest.Except(shortest).ToArray();
		}

		/// <summary>
		///		Returns a string, or a default value if the string is null
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="source">String to display</param>
		/// <param name="defaultValue">String to display if the source string is null</param>
		/// <returns></returns>
		public static string ToStringOrDefault<T>(this Nullable<T> source, string defaultValue) where T : struct
		{
			if (source != null && source.HasValue)
			{
				return source.Value.ToString();
			}
			return defaultValue;
		}

		/// <summary>
		/// Returns a formatted string, or a default value if the string is null
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="source">String to display</param>
		/// <param name="format">Format of the string</param>
		/// <param name="defaultValue">String to display if the source string is null</param>
		/// <returns></returns>
		public static string ToStringOrDefault<T>(this Nullable<T> source, string format, string defaultValue) where T : struct, IFormattable
		{
			if (source != null && source.HasValue)
			{
				return source.Value.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
			}
			return defaultValue;
		}
	}
}
