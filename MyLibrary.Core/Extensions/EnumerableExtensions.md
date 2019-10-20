# Enumerable Extensions

```csharp
IEnumerable<string> source = new List<string> { "This", "is", "a", "list", "of", "strings" };
```

---
#### Append&lt;TSource&gt;(IEnumerable&lt;TSource&gt;[]) : IEnumerable&lt;TSource&gt;
Appends multiple elements to the given sequence.
```csharp

```
**Output:**  
_` `_

---
#### Concat&lt;TSource&gt;(IEnumerable&lt;TSource&gt;[]) : IEnumerable&lt;TSource&gt;
Concatenates multiple sequences.
```csharp

```
**Output:**  
_` `_

---
#### Contains&lt;TSource&gt;(Func&lt;TSource, bool&gt;) : bool
Returns whether the sequence has any elements that match the LINQ qualifier.
```csharp

```
**Output:**
_` `_

---
#### Contains&lt;TSource&gt;(TSource) : bool
Returns whether the sequence has any elements that match the object
```csharp

```
**Output:**
_` `_

---
#### DistinctBy&lt;T, TKey&gt;(Func&lt;T, TKey&gt;, IEqualityComparer&lt;TKey&gt;) : IEnumerable&lt;T&gt;
Selects distinct items in a sequence by using a comparison delegate
```csharp

```
**Output:**
_` `_

---
#### GetRandomItem&lt;T&gt;(int?) : T
Picks a random element from the source, or default(T) if the enumerable is null or empty
```csharp

```
**Output:**
_` `_

---
#### GetSafeVersion&lt;T&gt;() : IEnumerable&lt;T&gt;
Returns an empty enumerable if null, otherwise returns the enumerable
```csharp

```
**Output:**
_` `_

---
#### Has&lt;TSource&gt;(TSource) : bool
[Obsolete] Returns whether the enumerable has any elements that match the predicate
```csharp

```
**Output:**
_` `_

---
#### Has&lt;TSource&gt;(Func&lt;TSource, bool&gt;) : bool
[Obsolete] Returns whether the enumerable has any elements that match the LINQ delegate
```csharp

```
**Output:**
_` `_

---
#### IsEmpty&lt;T&gt;() : bool
Returns whether the enumerable is empty and throws an error if null
```csharp

```
**Output:**
_` `_

---
#### IsNullOrEmpty&lt;T&gt;() : bool
Returns whether the enumerable is null or empty
```csharp

```
**Output:**
_` `_

---
#### Join(string) : string
Flattens the elements of an enumerable into a string
```csharp

```
**Output:**
_` `_

---
#### RemoveNulls&lt;T&gt;() : IEnumerable&lt;T&gt;
Removes all null values from the collection
```csharp

```
**Output:**
_` `_

---
#### ToHashSet&lt;T&gt;() : HashSet&lt;T&gt;
Converts an enumerable into a HashSet
```csharp

```
**Output:**
_` `_

---
#### ToString&lt;T&gt;(string) : string
Flattens the elements of an enumerable into a string
```csharp

```
**Output:**
_` `_

---
#### TrimEachElement() : IEnumerable&lt;string&gt;
Trims whitespace characters from the beginning and end of each string element in the collection
```csharp

```
**Output:**
_` `_

---
#### WhereIn&lt;T&gt;(Func&lt;T, T&gt;, IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
Finds all elements in the parameter enumerable that exist within the source enumerable using a LINQ delegate to compare
```csharp

```
**Output:**
_` `_

---
#### WhereIn&lt;T&gt;(IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
Finds all elements in the parameter enumerable that exist within the source enumerable
```csharp

```
**Output:**
_` `_

---
#### WhereNotIn&lt;T&gt;(Func&lt;T, T&gt;, IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
Finds all elements in the parameter enumerable that do not exist within the source enumerable using a LINQ delegate to compare
```csharp

```
**Output:**
_` `_

---
#### WhereNotIn&lt;T&gt;(IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
Finds all elements in the parameter enumerable that do not exist within the source enumerable
```csharp

```
**Output:**
_` `_

---
















