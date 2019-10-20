# Url Extensions

```csharp
Uri sourceUri = new Uri();
string sourceStringEncoded = "http://nicholashamlin.com/?test=some%20string";
string sourceStringDecoded = "http://nicholashamlin.com/?test=some string";
```

---
#### IsNullOrEmpty() : bool
Returns whether the url is null or empty
```csharp
bool result = sourceUri.IsNullOrEmpty();
```
**Output:**  
_`true`_

---
#### UrlDecode() : string
Returns a string decoded from a Url
```csharp
string result = sourceString.UrlDecode();
```
**Output:**  
_`http://nicholashamlin.com/?test=some string`_

---
#### UrlEncode() : string
Returns a string encoded as a Url
```csharp
string result = sourceString.UrlEncode();
```
**Output:**  
_`http://nicholashamlin.com/?test=some%20string`_

---