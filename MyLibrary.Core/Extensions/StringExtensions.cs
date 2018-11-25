using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using Humanizer;
using log4net;
using MyLibrary.Core.Helpers;

namespace MyLibrary.Core.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="string" />
	/// </summary>
	public static class StringExtensions
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(StringExtensions));

		/// <summary>
		///     Appends a string to the beginning of another string
		/// </summary>
		/// <param name="source">Original string</param>
		/// <param name="prefix">String to append at the beginning</param>
		/// <returns>String</returns>
		public static string AddPrefix<T>(this string source, IEnumerable<T> prefix)
		{
			return $"{prefix.ToString("")}{source}";
		}

		/// <summary>
		///     Appends a string to the beginning of another string
		/// </summary>
		/// <param name="source">Original string</param>
		/// <param name="prefix">String to append at the beginning</param>
		/// <returns>String</returns>
		public static string AddPrefix(this string source, string prefix)
		{
			return $"{prefix}{source}";
		}

		/// <summary>
		///     Appends a string to the end of another string
		/// </summary>
		/// <param name="source">Original string</param>
		/// <param name="suffix">String to append at the end</param>
		/// <returns>String</returns>
		public static string AddSuffix(this string source, string suffix)
		{
			return $"{source}{suffix}";
		}

		/// <summary>
		///     Appends a string to the end of another string
		/// </summary>
		/// <param name="source">Original string</param>
		/// <param name="suffix">String to append at the end</param>
		/// <returns>String</returns>
		public static string AddSuffix<T>(this string source, IEnumerable<T> suffix)
		{
			return $"{source}{suffix.ToString("")}";
		}

		/// <summary>
		///     Encrypts the string based on the provided <see cref="EncryptionPolicy" />
		/// </summary>
		/// <param name="source">String to encrypt</param>
		/// <param name="encryptionPolicy">
		///     <see cref="EncryptionPolicy"> to use to encrypt the string</see>
		/// </param>
		/// <returns></returns>
		public static string Encrypt(this string source, EncryptionPolicy encryptionPolicy)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Returns whether the string is not empty
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool HasValue(this string source)
		{
			return !source.IsNullOrWhiteSpace();
		}

		/// <summary>
		///     Converts the first letter in a string to lower case
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string InitialLetterToLower(this string source)
		{
			return char.ToLowerInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		///     Returns the string with the first letter in lower case
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="cultureInfo">Culture of the string</param>
		/// <returns></returns>
		public static string InitialLetterToLower(this string source, CultureInfo cultureInfo)
		{
			return char.ToLower(source[0], cultureInfo) + source.Substring(1);
		}

		/// <summary>
		///     Converts the first letter in a string to upper case using an invariant culture
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string InitialLetterToUpper(this string source)
		{
			return char.ToUpperInvariant(source[0]) + source.Substring(1);
		}

		/// <summary>
		///     Converts the first letter in a string to upper case
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="cultureInfo">Culture of the string</param>
		/// <returns></returns>
		public static string InitialLetterToUpper(this string source, CultureInfo cultureInfo)
		{
			return char.ToUpper(source[0], cultureInfo) + source.Substring(1);
		}

		/// <summary>
		///     Returns whether the string is blank (white space characters ignored because then it wouldn't be 'blank')
		/// </summary>
		/// <example>
		///     " ".IsBlank() => false;
		///     "".IsBlank() => true;
		/// </example>
		/// <param name="source">String to check</param>
		/// <returns></returns>
		public static bool IsBlank(this string source)
		{
			return string.IsNullOrEmpty(source);
		}

		/// <summary>
		///     Returns whether a string is completely in lowercase
		/// </summary>
		/// <param name="source">String to check</param>
		/// <returns>True/False</returns>
		public static bool IsLowercase(this string source)
		{
			return Regex.IsMatch(source, "^[a-z]+$");
		}

		/// <summary>
		///     Returns whether the string is completely empty, including white spaces
		/// </summary>
		/// <param name="source">String to check</param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string source)
		{
			return string.IsNullOrWhiteSpace(source);
		}

		/// <summary>
		///     Returns whether a string is completely in uppercase
		/// </summary>
		/// <param name="source">String to check</param>
		/// <returns>True/False</returns>
		public static bool IsUppercase(this string source)
		{
			return Regex.IsMatch(source, "^[A-Z]+$");
		}

		/// <summary>
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static bool Matches(this string source, string pattern)
		{
			return Regex.IsMatch(source, pattern);
		}

		/// <summary>
		///     Converts an empty string to null instead of string.Empty
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>A valid string or null</returns>
		public static string NullIfEmpty(this string source)
		{
			return string.IsNullOrWhiteSpace(source) ? null : source;
		}

		/// <summary>
		///     Returns only the digits inside of a string
		/// </summary>
		/// <param name="source">String to compare against</param>
		/// <returns>All digits in the string</returns>
		public static string OnlyDigits(this string source)
		{
			return new string(source?.Where(char.IsDigit).ToArray());
		}

		/// <summary>
		///     Converts the first letter of the string into either upper or lower case depending on the word before it
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string ProperCapitalization(this string source)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Removes a substring from a string
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="substring">Substring to remove</param>
		/// <returns></returns>
		public static string RemoveSubstring(this string source, string substring)
		{
			return source.RemoveSubstring(false, substring);
		}

		/// <summary>
		///     Returns a string minus any of the given substrings inside.
		/// </summary>
		/// <param name="source">Source string to extract</param>
		/// <param name="excludeWhitespace">T/F whether to exclude whitespace from results</param>
		/// <param name="paramStrings">Array of strings to remove from the source string</param>
		/// <returns>A string containing all characters except that of the substrings sent in.</returns>
		public static string RemoveSubstring(this string source, bool excludeWhitespace = false, params string[] paramStrings)
		{
			foreach (string subString in paramStrings)
			{
				source = source.Replace(subString, string.Empty);
			}

			if (excludeWhitespace)
			{
				source = Regex.Replace(source, @"\s", "");
			}

			return source;
		}

		/// <summary>
		///     Replaces all diacritics in the source string with their romanized counterpart
		/// </summary>
		/// <param name="source">Source string</param>
		/// <returns>Completely Romanized string</returns>
		public static string ReplaceUnicode(this string source)
		{
			StringBuilder result = new StringBuilder();
			try
			{

				foreach (char character in source)
				{
					if (character > 127)
					{
						result.Append(Constants.Diacritics[character.ToString()]);
					}
					else
					{
						result.Append(character);
					}
				}

			}
			catch (Exception ex)
			{
				_logger.Error($"There was a problem converting {source} into its romanized form. Perhaps a diacritic is missing?", ex);
			}

			return result.ToString();
		}

		/// <summary>
		///     Reverses the string
		/// </summary>
		/// <param name="source">String to reverse</param>
		/// <returns></returns>
		public static string Reverse(this string source)
		{
			char[] chars = source.ToCharArray();
			Array.Reverse(chars);
			return chars.ToSafeString();
		}

		/// <summary>
		///     Splits the string by pascal case
		/// </summary>
		/// <example>
		///     The following returns "This Is A Pascal Case String"
		///     <code>
		/// var str = "ThisIsAPascalCaseString";
		/// return str.SplitPascalCase();
		/// </code>
		/// </example>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string SplitPascalCase(this string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return source;
			}

			return Regex.Replace(source, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
		}

		/// <summary>
		///     Splits the string by underlines
		/// </summary>
		/// <example>
		///     The following returns "This Is An Underlined String"
		///     <code>
		/// var str = "This_Is_An_Underlined_String";
		/// return str.SplitUnderlines();
		/// </code>
		/// </example>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string SplitUnderlines(this string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return source;
			}

			return Regex.Replace(source, "(_)", " $1", RegexOptions.Compiled).Trim();
		}

		/// <summary>
		///     Converts a string into pascal case (UpperCamelCase) with an invariant culture
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string ToPascalCase(this string source)
		{
			return source.ToPascalCase(true, CultureInfo.InvariantCulture);
		}

		/// <summary>
		///     Converts a string into pascal case (UpperCamelCase)
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="cultureInfo">Culture of the string</param>
		/// <returns></returns>
		public static string ToPascalCase(this string source, CultureInfo cultureInfo)
		{
			return source.ToPascalCase(true, cultureInfo);
		}

		/// <summary>
		///     Converts a string into pascal case (UpperCamelCase) with the option to remove underscores
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="removeUnderscores">Option to remove underscores</param>
		/// <param name="cultureInfo">Culture of the string</param>
		/// <returns></returns>
		public static string ToPascalCase(this string source, bool removeUnderscores, CultureInfo cultureInfo)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				return source;
			}

			source = source.Replace("_", " ");
			var delimiter = removeUnderscores ? string.Empty : "_";
			string[] strArray = source.Split(' ');
			if (strArray.Length <= 1 && !strArray[0].IsUppercase())
			{
				return strArray[0].Substring(0, 1).ToUpper(cultureInfo) + strArray[0].Substring(1);
			}

			for (int idx = 0; idx < strArray.Length; idx++)
			{
				if (strArray[idx].Length <= 0)
				{
					continue;
				}

				string str = strArray[idx];
				string input = str.Substring(1);
				input = input.ToLower(cultureInfo);
				char upper = char.ToUpper(str[0], cultureInfo);
				strArray[idx] = upper + input;
			}

			return string.Join(delimiter, strArray);
		}

		/// <summary>
		/// Converts a string to a null-safe (non-null) string.
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns>Null-safe string</returns>
		public static string ToSafeString(this string source)
		{
			return source ?? string.Empty;
		}

		/// <summary>
		///     Returns a string, or a default value if the string is null
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="source">String to convert</param>
		/// <param name="defaultValue">String to display if the source string is null</param>
		/// <returns></returns>
		public static string ToStringOrDefault<T>(this T? source, string defaultValue)
			where T : struct
		{
			return source.HasValue ? source.Value.ToString() : defaultValue;
		}

		/// <summary>
		///     Returns a formatted string, or a default value if the string is null
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <param name="source">String to display</param>
		/// <param name="format">Format of the string</param>
		/// <param name="defaultValue">String to display if the source string is null</param>
		/// <returns></returns>
		public static string ToStringOrDefault<T>(this T? source, string format, string defaultValue)
			where T : struct, IFormattable
		{
			return source.HasValue ? source.Value.ToString(format, CultureInfo.InvariantCulture) : defaultValue;
		}

		/// <summary>
		///     Removes the first character from the string
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string TruncateFirstChar(this string source)
		{
			return source.Substring(1);
		}

		/// <summary>
		///     Removes a number of characters from the beginning of the string
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="numberOfChars">Number of characters to remove</param>
		/// <returns></returns>
		public static string TruncateFromLeft(this string source, int numberOfChars)
		{
			return source.Truncate(numberOfChars, null, Truncator.FixedLength, TruncateFrom.Left);
		}

		/// <summary>
		///     Removes a number of characters from the end of the string
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <param name="numberOfChars">Number of characters to remove</param>
		/// <returns></returns>
		public static string TruncateFromRight(this string source, int numberOfChars)
		{
			return source.Truncate(numberOfChars, null, Truncator.FixedLength, TruncateFrom.Right);
		}

		/// <summary>
		///     Removes the last character from the string
		/// </summary>
		/// <param name="source">String to convert</param>
		/// <returns></returns>
		public static string TruncateLastChar(this string source)
		{
			return source.Substring(0, source.Length - 1);
		}
	}
}
