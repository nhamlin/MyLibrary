# Buffer Extensions

```csharp
byte[] source = Encoding.ASCII.GetBytes("My string");
```

---
#### AsString() : string
Converts a byte array to a string, using its byte order mark to convert it to the right encoding.
```csharp
string result = source.AsString();
```
**Output:**  
_`My string`_

---