using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace MyLibrary.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNullOrWhiteSpace(this string source)
		{
			return string.IsNullOrWhiteSpace(source);
		}

		public static string InitialLetterToUpper(this string source)
		{
			return char.ToUpperInvariant(source[0]) + source.Substring(1);
		}

		public static string InitialLetterToLower(this string source)
		{
			return char.ToLowerInvariant(source[0]) + source.Substring(1);
		}

		public static string ProperCapitalization(this string source)
		{
			throw new NotImplementedException();
		}

		public static string Encrypt(this string source, EncryptionPolicy encryptionPolicy)
		{
            throw new NotImplementedException();
		}

		public static string RemoveLastCharacter(this string source)
		{
			return source.Substring(0, source.Length - 1);
		}
		public static string RemoveLastSubstring(this string source, int numberOfChars)
		{
			return source.Substring(0, source.Length - numberOfChars);
		}
		public static string RemoveFirstCharacter(this string source)
		{
			return source.Substring(1);
		}
		public static string RemoveFirstSubstring(this string source, int numberOfChars)
		{
			return source.Substring(numberOfChars);
		}

        public static string Reverse(this string source) {
            char[] chars = source.ToCharArray();
            Array.Reverse(chars);
            return chars.ToSafeString();
        }

        public static string ToSafeString(this char[] source) {
            return source == null ? null : new string(source);
		}

		/// <summary>
		/// Splits the string by pascal case.
		/// </summary>
		/// <example>var str = "ThisIsAPascalCaseString";
		/// return str.SplitPascalCase(); => "This Is A Pascal Case String"</example>
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