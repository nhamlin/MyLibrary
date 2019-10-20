# Json Extensions

```csharp
string JsonString = "[{ key : 'description', value : 'This is an example string' }]";
KeyValuePair kvp = new KeyValuePair { { 'description', 'This is an exmaple string' } };
```

---
#### FromJson&lt;T&gt;(JsonSerializerSettings) : T
Deserializes a Json string (with optional settings) into a desired object type
```csharp
KeyValuePair result = JsonString.FromJson&lt;KeyValuePair&gt;();
Console.WriteLine(result["description"]);
```
**Output:**  
_`This is an example string`_

---
#### ToJson(Formatting) : string
Converts any object into a Json-formatted string
```csharp
Console.WriteLine(kvp.ToJson());
```
**Output:**  
_`[{ key : 'description', value : 'This is an example string' }]`_

---