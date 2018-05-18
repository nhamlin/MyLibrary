using System;
using System.Net.Security;

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
	}
}