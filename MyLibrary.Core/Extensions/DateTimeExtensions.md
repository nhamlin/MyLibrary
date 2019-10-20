# DateTime Extensions

```csharp
DateTime source = new DateTime(2019, 1, 1);
```

---
#### IsWeekday() : bool
Returns whether a date is between Monday and Friday
```csharp
bool result = source.IsWeekday();
```
**Output:**  
_`true`_

---
#### IsWeekend() : bool
Returns whether a date is Saturday or Sunday
```csharp
bool result = source.IsWeekend();
```
**Output:**  
_`false`_

---
#### IsDate&lt;T&gt;() : bool
Returns whether an object is a DateTime
```csharp
bool result = source.IsDate();
```
**Output:**  
_`true`_

---
#### EndOfDay() : DateTime
Returns the last second of the day (used for ranges)
```csharp
DateTime result = DateTime.Today.EndOfDay();
```
**Output:**  
_`(today)T23:59:59Z`_

---
#### Average() : TimeSpan
Returns an average of a list of TimeSpan values
```csharp
IEnumerable<TimeSpan> source = new List<TimeSpan> { ... };
var result = source.Average();
```
**Output:**  
_`  `_

---
#### Sum() : TimeSpan
Returns a summation of all TimeSpans in a list
```csharp
IEnumerable<TimeSpan> source = new List<TimeSpan> { ... };
var result = source.Sum();
```
**Output:**  
_` `_

---
#### IsHoliday : bool
Returns whether a date falls on a holiday
```csharp

```
**Output:**  
_` `_

---
#### RangeUntil(DateTime) : IEnumerable&lt;DateTime&gt;
Returns a range of individual days between two dates.
```csharp

```
**Output:**  
_` `_

---