﻿# Data Annotations

## Key & ForeignKey
### Custom Primary Key

[Passport.cs](Passport.cs)

```csharp
[Key]
public int PassportNumber { get; set; }
```

The convention is to look for a property named `Id` or one that combines the class name with `Id`, such as `PassportId`. If it does not find a property matching this convention, it will throw an exception because of the requirement that you must have a key property. To circumvent this, decorate the property with the `[Key]` attribute.

### Composite Keys

[Passport.cs](Passport.cs) 

```csharp
[Key]
[Column(Order = 1)]
public int PassportNumber { get; set; }

[Key]
[Column(Order = 2)]
public string IssuingCountry { get; set; }
```

If the primary key consists of more than one property, simply decorate the properties with the `[Key]` attribute. But because you have more than one property, EF doesn't know which order to use when building the composite key. Decorate the properties with the `[Column(Order = n)]` attribute, specifying the Order in which to build the composite key.

### Foreign Keys

[Passport.cs](Passport.cs) 

```csharp
[ForeignKey("Passport")]
[Column(Order = 1)]
public int PassportNumber { get; set; }

[ForeignKey("Passport")]
[Column(Order = 2)]
public string IssuingCountry { get; set; }
```

Using the same concept as the two previous examples, setting the foreign keys is done by decorating with the `[ForeignKey(FK_name)]` attribute. If a composite foreign key is made, also include the `[Column(Order = n)]` attribute to specify the order in which the key is built.

---

## Required

[Passport.cs](Passport.cs) 

```csharp
[Required]
public DateTime Expires { get; set; }
```

Adding `[Required]` to a property will designate a property as needing to have a value when submitted. MVC will perform client-side validation, and any field marked Required that does not have data will be marked as an error and processing will not continue.

The `[Required]` attribute will also mark a property as needing to be set as `NOT NULL` in the database.

**_Note:_** Using a non-nullable data type will not mark the database field as `NOT NULL`. For this, the `[Required]` attribute is needed.

---

## MaxLength & MinLength

[Blog.cs](Blog.cs)

```csharp
[MinLength(5)]
[MaxLength(30, ErrorMessage = "The name can't be more than 30 characters long.")]
public string Name { get; set; }
```

`[MinLength]` and `[MaxLength]` set limits to the acceptable length of the data that can be stored in the property.

`[MaxLength]` will impact the database by setting the database field's length.

`ErrorMessage` is what will be displayed during client-side validation if the limit is exceeded.

---

## NotMapped

[SchoolEntities.cs](SchoolEntities.cs)

```csharp
[NotMapped]
public string CatalogEntry => CourseID + ": " + Title;
```

Not all of the properties in the class need to be represented in the database. For example, if there is a calculated field based on the values of other fields, that doesn't need to be stored in a database. To bypass the creation of fields in the database for a property, decorate it with the `[NotMapped]` attribute.

---

## ComplexType

[BlogDetails.cs](BlogDetails.cs)

```csharp
[ComplexType]
public class BlogDetails
{
	public DateTime Time { get; set; }
}
```

A class that does not have any type of key property, and therefore is not tracked on its own in Entity Framework, are considered to be _complex types_. However, if you use that class inside another class, and want to track the class, you must mark the class as `[ComplexType]`. 

---

## ConcurrencyCheck

[Blog.cs](Blog.cs)

```csharp
[ConcurrencyCheck]
[MinLength(5)]
[MaxLength(30, ErrorMessage = "The name can't be more than 30 characters long.")]
public string Name { get; set; }
```

Concurrency checking refers to checking for situations in which multiple processes or users access or change the same data in a database at the same time. Decorating a property with the `[ConcurrencyCheck]` attribute will tell EF to include the property's original value in any filtering before processing an `UPDATE` or `DELETE` command in the database, along with the primary key that it already uses.

An example:
```sql
where (([PrimaryTrackingKey] = @4) and ([BloggerName] = @5))
    @4=1,@5=N'Julie'
```

---

## TimeStamp

[]()

```csharp
```



---

## Table & Column

[]()

```csharp
```



---

## DatabaseGenerated

[]()

```csharp
```



---

## Index

[]()

```csharp
```



---

## InverseProperty

[]()

```csharp
```