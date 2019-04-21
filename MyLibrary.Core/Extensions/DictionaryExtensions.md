# Dictionary Extensions

```csharp
Dictionary<string, int> source = new Dictionary() {
      { "One", 1 },
      { "Two", 2 },
      { "Three", 3}
  };
```

---
#### MaxKey&lt;TKey, TValue&gt;() : TKey
Gets the key of the largest value in a dictionary
```csharp
var result = source.MaxKey();
```
**Output:**  
_`Three`_

---
#### MaxValue&lt;TKey, TValue&gt;() : TValue
Returns the largest value in a dictionary
```csharp
var result = source.MaxValue();
```
**Output:**  
_`3`_

---