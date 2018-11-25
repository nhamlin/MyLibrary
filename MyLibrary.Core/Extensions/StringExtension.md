# String Extensions

#### AddPrefix&lt;T&gt;(IEnumerable&lt;T&gt;)
Appends a string of a joined IEnumerable&lt;T&gt; to the beginning of another string.

#### AddPrefix(string)
Appends a string to the beginning of another string.

#### AddSuffix&lt;T&gt;(IEnumerable&lt;T&gt;)
Appends a string of a joined IEnumerable&lt;T&gt; to the end of another string.

#### AddSuffix(string)
Appends a string to the end of another string.

#### Encrypt(EncryptionPolicy)
Not Implemented

#### HasValue()
Returns whether the string is not null or only white space.

#### InitialLetterToLower()
Converts the first letter of a string to lowercase, using an invariant culture.

#### InitialLetterToLower(CultureInfo)
Converts the first letter of a string to lowercase for a specific culture.

#### InitialLetterToUpper()
Converts the first letter of a string to uppercase, using an invariant culture.

#### InitialLetterToUpper(CultureInfo)
Converts the first letter of a string to uppercase for a specific culture.

#### IsBlank()
Returns whether the string is null or empty.  
_Example: " ".IsBlank() => false; "".IsBlank() => true;_

#### IsLowercase()
Returns whether a string is all lowercase.

#### IsNullOrWhiteSpace()
Returns whether a string is null or empty, including whitespaces.

#### IsUppercase()
Returns whether a string is all uppercase.

#### Matches(string)
Returns whether the pattern can be found within the string.

#### NullIfEmpty()
Converts an empty string to null instead of string.Empty

#### OnlyDigits()
Returns only the digits found in the string.

#### ProperCapitalization()
Converts the first letter of the string to either upper case or lower case depending on the word preceeding it.

#### RemoveSubstring(string)
Removes a substring from a string.

#### RemoveSubstring(bool, string[])
Removes a collection of substrings from a string, optionally removing all whitespace characters.

#### ReplaceUnicode()
Replaces all diacritics in the string with their romanized counterparts.

#### Reverse()
Reverses the characters in a string.

#### SplitPascalCase()
Splits the string by pascal case.

#### SplitUnderlines()
Splits the string by underscores.

#### ToPascalCase()
Converts a string to Pascal Case (UpperCamelCase) with an invariant culture.

#### ToPascalCase(CultureInfo)
Converts a string to Pascal Case (UpperCamelCase) using a specific culture.

#### ToPascalCase(bool, CultureInfo)
Converts a string to Pascal Case (UpperCamelCase) using a specific culture with the option to remove underscores.

#### ToSafeString()
Converts a string to a null-safe string.

#### ToStringOrDefault&lt;T&gt;(string)
Returns a string, or a default value if the string is null.

#### ToStringOrDefault&lt;T&gt;(string, string)
Returns a formatted string, or a default value if the string is null.

#### TruncateFirstChar()
Removes the first character of the string.

#### TruncateFromLeft(int)
Removes a number of characters from the beginning of a string.

#### TruncateFromRight(int)
Removes a number of characters from the end of a string.

#### TruncateLastChar()
Removes the last character of a string.