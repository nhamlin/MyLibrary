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
Returns whether the sequence has any elements that match the object.
```csharp

```
**Output:**
_` `_

---
#### DistinctBy&lt;T, TKey&gt;(Func&lt;T, TKey&gt;, IEqualityComparer&lt;TKey&gt;) : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### GetRandomItem&lt;T&gt;(int?) : T
```csharp

```
**Output:**
_` `_

---
#### GetSafeVersion&lt;T&gt;() : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### Has&lt;TSource&gt;(TSource) : bool
```csharp

```
**Output:**
_` `_

---
#### Has&lt;TSource&gt;(Func&lt;TSource, bool&gt;) : bool
```csharp

```
**Output:**
_` `_

---
#### IsEmpty&lt;T&gt;() : bool
```csharp

```
**Output:**
_` `_

---
#### IsNullOrEmpty&lt;T&gt;() : bool
```csharp

```
**Output:**
_` `_

---
#### Join(string) : string
```csharp

```
**Output:**
_` `_

---
#### RemoveNulls&lt;T&gt;() : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### ToHashSet&lt;T&gt;() : HashSet&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### ToString&lt;T&gt;(string) : string
```csharp

```
**Output:**
_` `_

---
#### TrimEachElement() : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### WhereIn&lt;T&gt;(Func&lt;T, T&gt;, IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### WhereIn&lt;T&gt;(IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### WhereNotIn&lt;T&gt;(Func&lt;T, T&gt;, IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;
```csharp

```
**Output:**
_` `_

---
#### WhereNotIn&lt;T&gt;(IEnumerable&lt;T&gt;) : IEnumerable&lt;T&gt;















