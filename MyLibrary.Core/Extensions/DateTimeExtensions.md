# DateTime Extensions

```csharp
DateTime source = new DateTime(2019, 1, 1);
```

---
#### IsWeekday() : bool
Returns whether a date is between Monday and Friday.
```csharp
bool result = source.IsWeekday();
```
**Output:**  
_`true`_

---
#### IsWeekend() : bool
Returns whether a date is Saturday or Sunday.
```csharp
bool result = source.IsWeekend();
```
**Output:**  
_`false`_

---