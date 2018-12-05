# Char Extensions

```csharp
char[] source = "This is a character array.".ToCharArray();
```

---
#### RemoveChars(bool, char[]) : char[]
Returns a collection of characters where the second array's characters are subtracted from the first.
```csharp
char[] result = source.RemoveChars(false, "ar".ToCharArray());
```
**Output:**  
_`This is  chcte y.`_

--- 
#### ReplaceUnicode() : string
Replaces the character diacritic with its romanized counterpart string.
```csharp
char[] source = "schön".ToCharArray();
var result = source.Select(x=>x.ReplaceUnicode()).Join("");
```
**Output:**  
_`schoen`_

---- 
#### ToHex() : string
Converts the Unicode value of this character to its equivalent 4-character hexadecimal string representation.
```csharp
var result = source[0].ToHex();
```
**Output:**  
_`0054`_

---- 
#### ToLower() : char
Converts a character to lowercase.
```csharp
char example = 'A';
char result = example.ToLower();
```
**Output:**  
_`a`_

---- 
#### ToLowerInvariant() : char
Converts a character to lowercase, without a specific culture.
```csharp
char example = 'Ñ';
char result = example.ToLowerInvariant();
```
**Output:**  
_`ñ`_

---- 
#### ToSafeString() : string
Converts an array of characters to a null-safe string.
```csharp
char[] example = null;
string result = example.ToSafeString();
```
**Output:**  
_` `_

---- 
#### ToStringInvariant() : string
Converts a char to a string with an invariant culture format.
```csharp
string result = source[0].ToStringInvariant();
```
**Output:**  
_`T`_

---- 
#### ToUpper() : char
Converts a character to uppercase.
```csharp
char example = 'n';
char result = example.ToUpper();
```
**Output:**  
_`N`_

---- 
#### ToUpperInvariant() : char
Converts a character to uppercase, without a specific culture
```csharp
char example = 'ç';
char result = example.ToUpperInvariant();
```
**Output:**  
_`Ç`_

---- 