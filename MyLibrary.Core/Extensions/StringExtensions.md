# String Extensions

```csharp
string source = "This is my string.";
```

---
#### AddPrefix&lt;T&gt;(IEnumerable&lt;T&gt;) : string
Appends a string of a joined IEnumerable&lt;T&gt; to the beginning of another string.
```csharp
string result = source.AddPrefix<char>(new char[] { 'a', 'b', 'c' });
```  
**Output:**  
_`abcThis is my string.`_

---    
#### AddPrefix(string) : string
Appends a string to the beginning of another string.

```csharp
string result = source.AddPrefix("abc_");
```  
**Output:**  
_`abc_This is my string.`_

---
#### AddSuffix&lt;T&gt;(IEnumerable&lt;T&gt;) : string
Appends a string of a joined IEnumerable&lt;T&gt; to the end of another string.

```csharp
IEnumerable<string> paramList = new List<string> { "...", "abc", "_", "def" };
string result = source.AddSuffix<string>(paramList); 
```
**Output:**  
_`This is my string....abc_def`_

---
#### AddSuffix(string) : string
Appends a string to the end of another string.

```csharp
string result = source.AddSuffix("...and don't call me Shirley.");
```
**Output:**  
_`This is my string....and don't call me Shirley.`_

---
#### Capitalize(CultureInfo?) : string
Converts the first letter of a string to uppercase.

```csharp
string result = source.Capitalize();
```
**Output:**  
_`This is my string.`_

---
#### Encrypt(EncryptionPolicy) : string
Encrypts a string using a specific EncryptionPolicy.  
**_(Not Implemented)_**

```csharp
string result = source.Encrypt(EncryptionPolicy.RequireEncryption);
```
**Output:**  
_`{some string}`_

---
#### GetFromEnd(int) : string
Removes a number of characters from the beginning of a string.

```csharp
string result = source.GetFromEnd(3);
```
**Output:**  
_`ng.`_

---
#### GetFromBeginning(int) : string
Removes a number of characters from the end of a string.

```csharp
string result = source.GetFromBeginning(3);
```
**Output:**  
_`Thi`_

---
#### HasValue() : bool
Returns whether the string is not null or only white space.

```csharp
bool result = source.HasValue();
```
**Output:**  
_`True`_

---
#### InitialLetterToLower() : string
Converts the first letter of a string to lowercase, using an invariant culture.

```csharp
string result = source.InitialLetterToLower();
```
**Output:**  
_`this is my string.`_

---
#### InitialLetterToLower(CultureInfo)
Converts the first letter of a string to lowercase for a specific culture.

```csharp
string result = source.InitialLetterToLower(new CultureInfo("ru-RU"));
```
**Output:**  
_`this is my string.`_

---
#### InitialLetterToUpper() : string
Converts the first letter of a string to uppercase, using an invariant culture.

```csharp
string example = "ingress";
string result = example.InitialLetterToUpper();
```
**Output:**  
_`Ingress`_

---
#### InitialLetterToUpper(CultureInfo) : string
Converts the first letter of a string to uppercase for a specific culture.

```csharp
string example = "до свидания";
string result = example.InitialLetterToUpper(new CultureInfo("ru-RU"));
```
**Output:**  
`До свидания`

---
#### IsBlank() : bool
Returns whether the string is null or empty.  
```csharp
"".IsBlank(); 
" ".IsBlank();  
source.IsBlank();
```

**Output:**   
_`False`_  
_`True`_  
_`False`_

---
#### IsLowercase() : bool
Returns whether a string is all lowercase.

```csharp
bool result = source.IsLowercase();
bool result2 = "xml-doc".IsLowercase(); 
```
**Output:**  
_`False`_  
_`True`_

---
#### IsNullOrWhiteSpace() : bool
Returns whether a string is null or empty, including whitespaces.

```csharp
bool result = source.IsNullOrWhitespace();
```
**Output:**  
_`False`_

---
#### IsUppercase() : bool
Returns whether a string is all uppercase.

```csharp
bool result = source.IsUppercase();
bool result2 = "FBI".IsUppercase();
```
**Output:**  
_`False`_  
_`True`_

---
#### Matches(string) : bool
Returns whether the pattern can be found within the string.

```csharp
bool result = source.Matches("my");
bool result2 = source.Matches("strings");
```
**Output:**  
_`True`_

---
#### NullIfEmpty() : string
Converts an empty string to null instead of string.Empty

```csharp
string example = "";
string result = example.NullIfEmpty();
```
**Output:**  
_`null`_

---
#### OnlyDigits() : string
Returns only the digits found in the string.

```csharp
string example = "123 Easy Street";
string result = example.OnlyDigits();
```
**Output:**  
_`123`_

---
#### Pluralize(string, string) : string
Returns either a singular or plural string based on a quantity.

```csharp
int objectCount = 3;
string result = objectCount.Pluralize("item", "items");
```
**Output:**  
_`3 items`_

---
#### ProperCapitalization() : string
Converts the first letter of the string to either upper case or lower case depending on the word preceeding it.  
**_(Not Implemented)_**

```csharp
string result = source.ProperCapitalization();
```
**Output:**  
_`{some string}`_

---
#### RemoveSubstring(string) : string
Removes a substring from a string.

```csharp
string result = source.RemoveSubstring("is");
```
**Output:**  
_`Th  my string.`_

---
#### RemoveSubstring(bool, string[]) : string
Removes a collection of substrings from a string, optionally removing all whitespace characters.

```csharp
string result = source.RemoveSubstring(true, "is");
```
**Output:**  
_`Thmystring.`_

---
#### ReplaceUnicode() : string
Replaces all diacritics in the string with their romanized counterparts.

```csharp
string example = "Niño";
string result = example.ReplaceUnicode();
```
**Output:**  
_`Nino`_

---
#### Reverse() : string
Reverses the characters in a string.

```csharp
string result = source.Reverse();
```
**Output:**  
_`.gnirts ym si sihT`_

---
#### SplitPascalCase() : string
Splits the string by pascal case.

```csharp
string example = "ThisIsMyString";
string result = example.SplitPascalCase();
```
**Output:**  
_`This Is My String`_

---
#### SplitUnderlines() : string
Splits the string by underscores.

```csharp
string example = "This_is_a_string_with_underscores.";
string result = example.SplitUnderlines();
```
**Output:**  
_`This is a string with underscores.`_

---
#### ToPascalCase() : string
Converts a string to Pascal Case (UpperCamelCase) with an invariant culture.

```csharp
string result = source.ToPascalCase();
```
**Output:**  
_`ThisIsMyString.`_

---
#### ToPascalCase(CultureInfo) : string
Converts a string to Pascal Case (UpperCamelCase) using a specific culture.

```csharp
string result = source.ToPascalCase(new CultureInfo("tr-TR"));
```
**Output:**  
_`ThisIsMyString.`_

---
#### ToPascalCase(bool, CultureInfo) : string
Converts a string to Pascal Case (UpperCamelCase) using a specific culture with the option to remove underscores.

```csharp
string example = "This_is_my_string.";
string result = example.ToPascalCase(true, new CultureInfo("es-ES"));_
```
**Output:**  
_`ThisIsMyString.`_

---
#### ToSafeString() : string
Converts a string to a null-safe string.

```csharp
string example = null;
string result = example.ToSafeString();
```
**Output:**  
_` `_

---
#### ToStringOrDefault&lt;T&gt;(string) : string
Returns a string, or a default value if the string is null.

```csharp
int? example = null;
string result = example.ToStringOrDefault("Default Value");
```
**Output:**  
_`Default Value`_

---
#### ToStringOrDefault&lt;T&gt;(string, string) : string
Returns a formatted string in an invariant culture, or a default value if the string is null.

```csharp
int? example = null;
string result = example.ToStringOrDefault("N1", "Default");
```
**Output:**  
_`Default`_

---
#### ToStringOrDefault&lt;T&gt;(string, CultureInfo, string) : string
Returns a formatted string using a specific culture, or a default value if the string is null.

```csharp
int? example = 1234;
string result = example.ToStringOrDefault("N1", "ru-RU", "Default");
```
**Output:**  
_`1 234,0`_

---
#### TruncateFirstChar() : string
Removes the first character of the string.

```csharp
string result = source.TruncateFirstChar();
```
**Output:**  
_`his is my string.`_

---
#### TruncateLastChar() : string
Removes the last character of a string.

```csharp
string result = source.TruncateLastChar();
```
**Output:**  
_This is my string_

---