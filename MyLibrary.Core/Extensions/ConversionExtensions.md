# Conversion Extensions

```csharp
string age = "28";
```

---
#### ConvertTo&lt;T&gt;(this IConvertible) : T
Converts one type to another
```csharp
var ageAsInt = age.ConvertTo<int>();
```
**Output:**  
_`28`_

---
#### ConvertTo&lt;T&gt;(this IConvertible, T) : T
Converts one type to another, and returns a specific value if there is an error
```csharp
var ageAsDouble = age.ConvertTo<Double>();
```
**Output:**  
_`28.0`_

---
#### GetSafe&lt;T&gt;(this IConvertible) : T
Alternative way to call ConvertTo&lt;T&gt;
```csharp
var dateUponBirth = DateTime.Today.AddYears(-age.GetSafe<int>);
```
**Output:**  
_`1991`_

---
#### HashBy&lt;T&gt;(this byte[]) : byte[]
Implicit hashing
```csharp
Console.WriteLine("Hello World!".ToByteArray().HashBy<MD5>());
```
**Output:**  
_`Byte[]`_

---