# Comparison Extensions

```csharp
string[] names = { "Nick", "Kai", "Sarah" };
IEnumerable<string> employees = SomeAPI.GetAllEmployeeNames();
```

---
#### IsIn&lt;T&gt;(params T[]) : bool
Determines if an object can be found inside a generic list
```csharp
string customerName = SomeAPI.GetOrderCustomerName();
return customerName.IsIn(names)
`or`
return customerName.IsIn("Nick", "Kai", "Sarah");
```
**Output:**  
_`True`_

---
#### IsIn&lt;T&gt;(IEnumerable&lt;T&gt;) : bool
Determines if an object can be found inside a generic list
```csharp
string customerName = SomeAPI.GetOrderCustomerName();
return customerName.IsIn(employees);
```
**Output**  
_`False`_