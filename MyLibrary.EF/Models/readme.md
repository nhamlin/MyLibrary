# Data Annotations

## Key & ForeignKey
### Custom Primary Key

<table>
	<tr>
		<td><code>[Key]</code></td>
	</tr>
	<tr>
		<td><i>none</i></td>
	</tr>
</table>

[Passport.cs](Passport.cs)

```csharp
[Key]
public int PassportNumber { get; set; }
```

The convention is to look for a property named `Id` or one that combines the class name with `Id`, such as `PassportId`. If it does not find a property matching this convention, it will throw an exception because of the requirement that you must have a key property. To circumvent this, decorate the property with the `[Key]` attribute.

**_Notes:_**
* If a field is marked as `[Key]` and is of the data type `integer`, it will be automatically assigned as an `identity` field (auto generated) in the database.

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

<table>
	<tr>
		<td colspan="2"><code>[ForeignKey(name string)]</code></td>
	</tr>
	<tr>
		<td><i>name</i></td>
		<td>Name of the associated foreign key(s)</td>
	</tr>
</table>

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

<table>
	<tr>
		<td colspan="2"><code>[Required([AllowEmptyStrings = allowEmptyStrings bool, ErrorMessage = errorMessage string])]</code></td>
	</tr>
	<tr>
		<td><i>allowEmptyStrings</i></td>
		<td>Although the field is marked required, an empty string (" ") is allowed. True empty strings will always evaluate to <code>null</code> so those will fail validation. (Optional)</td>
	</tr>
	<tr>
		<td><i>errorMessage</i></td>
		<td>Message to be displayed during client-side validation if the required field is empty (Optional)</td>
	</tr>
</table>

[Passport.cs](Passport.cs) 

```csharp
[Required(ErrorMessage = "This passport requires an expiration date.")]
public DateTime Expires { get; set; }
```

Adding `[Required]` to a property will designate a property as needing to have a value when submitted. MVC will perform client-side validation, and any field marked Required that does not have data will be marked as an error and processing will not continue.

The `[Required]` attribute will also mark a property as needing to be set as `NOT NULL` in the database.

**_Notes:_** 
* Using a non-nullable data type will not mark the database field as `NOT NULL`. For this, the `[Required]` attribute is needed.

---

## MaxLength & MinLength
### MaxLength

<table>
	<tr>
		<td colspan="2"><code>[MaxLength(length int, [ErrorMessage = errorMessage string)]]</code></td>
	</tr>
	<tr>
		<td><i>errorMessage</i></td>
		<td>Message to be displayed during client-side validation if the allowable length is exceeded (Optional)</td>
	</tr>
	<tr>
		<td><i>length</i></td>
		<td>Maximum allowable length</td>
	</tr>
</table>

[Blog.cs](Blog.cs)

```csharp
[MaxLength(30, ErrorMessage = "The name can't be more than 30 characters long.")]
public string Name { get; set; }
```

`[MaxLength]` set a limit of what is an acceptable maximum length of the data that will be stored in the property.

**_Notes:_**
* `[MaxLength]` will impact the database by setting the database field's length.

### MinLength

<table>
	<tr>
		<td colspan="2"><code>[MinLength(length int, [ErrorMessage = errorMessage string)]]</code></td>
	</tr>
	<tr>
		<td><i>errorMessage</i></td>
		<td>Message to be displayed during client-side validation if the allowable length is not met (Optional)</td>
	</tr>
	<tr>
		<td><i>length</i></td>
		<td>Minimum allowable length</td>
	</tr>
</table>

[Blog.cs](Blog.cs)

```csharp
[MinLength(5, ErrorMessage = "The name can't be fewer than 5 characters long.")]
public string Name { get; set; }
```

`[MinLength]` set a limit of what is an acceptable minimum length of the data that will be stored in the property.

---

## NotMapped

<table>
	<tr>
		<td><code>[NotMapped]</code></td>
	</tr>
	<tr>
		<td><i>none</i></td>
	</tr>
</table>

[SchoolEntities.cs](/MyLibrary.EF/Context/SchoolEntities.cs)

```csharp
[NotMapped]
public string CatalogEntry => CourseID + ": " + Title;
```

Not all of the properties in the class need to be represented in the database. For example, if there is a calculated field based on the values of other fields, that doesn't need to be stored in a database. To bypass the creation of fields in the database for a property, decorate it with the `[NotMapped]` attribute.

---

## ComplexType

<table>
	<tr>
		<td><code>[ComplexType]</code></td>
	</tr>
	<tr>
		<td><i>none</i></td>
	</tr>
</table>

[BlogDetails.cs](BlogDetails.cs)

```csharp
[ComplexType]
public class BlogDetails
{
	public DateTime Time { get; set; }
}
```

A class that does not have any type of key property, and therefore is not tracked on its own in Entity Framework, is considered to be a _complex type_. However, if you use that class inside another class, and want to track the class, you must mark the class as `[ComplexType]`. 

An Example that will be tracked:
[Blog.cs](Blog.cs)
```csharp
public class Blog
{
	public int BlogId { get; set; }
	public BlogDetails BlogDetails { get; set; }
}
```

---

## ConcurrencyCheck

<table>
	<tr>
		<td><code>[ConcurrencyCheck]</code></td>
	</tr>
	<tr>
		<td><i>none</i></td>
	</tr>
</table>

[Blog.cs](Blog.cs)

```csharp
[ConcurrencyCheck]
[MinLength(5)]
[MaxLength(30, ErrorMessage = "The name can't be more than 30 characters long.")]
public string Name { get; set; }
```

Concurrency checking refers to checking for situations in which multiple processes or users access or change the same data in a database at the same time. Decorating a property with the `[ConcurrencyCheck]` attribute will tell EF to include the property's original value in any filtering before processing an `UPDATE` or `DELETE` command in the database, along with the primary key that it already uses.

An example of how the SQL would look:
```sql
WHERE (([PrimaryTrackingKey] = @4) AND ([BloggerName] = @5))
    @4=1,@5=N'Julie'
```

---

## Timestamp

<table>
	<tr>
		<td><code>[Timestamp]</code></td>
	</tr>
	<tr>
		<td><i>none</i></td>
	</tr>
</table>

[BlogDetails.cs](BlogDetails.cs)

```csharp
[Timestamp]
public Byte[] Timestamp { get; set; }
```

Timestamps are more commonly used for concurrency checking. If the type of property is a `Byte[]` array, you can use it as a timestamp. 

**_Notes:_** 
* You can only have one timestamp property per class.

---

## Table & Column
### Table

<table>
	<tr>
		<td colspan="2"><code>[Table(name string, [Schema = schema string])]</code></td>
	</tr>
	<tr>
		<td><i>name</i></td>
		<td>Name of the database table</td>
	</tr>
	<tr>
		<td><i>schema</i></td>
		<td>Name of the database schema in which a specific table should be created (Optional)</td>
	</tr>
</table>

[BlogDetails.cs](BlogDetails.cs)

```csharp
[Table("InternalBlogs", Schema = "dbo.LunchApp")]
public class MWBlogs
{
}
```

To change the name of the table created by code-first programming, use the `[Table("name")]` attribute. If the name 

### Column

<table>
	<tr>
		<td colspan="2"><code>[Column(name string, [TypeName = typeName string, Order = order int])]</code></td>
	</tr>
	<tr>
		<td><i>name</i></td>
		<td>Name of a field in the db table</td>
	</tr>
	<tr>
		<td><i>order</i></td>
		<td>Positional order of the field in a 0-based array indicated as an integer (Optional)</td>
	</tr>
	<tr>
		<td><i>typeName</i></td>
		<td>SQL datatype to use for this field (Optional)</td>
	</tr>
</table>

[BlogDetails.cs](BlogDetails.cs)

```csharp
[Column("CreatedDate", TypeName = "datetime")]
public DateTime PublishDate { get; set; }
```

or

```csharp
[Column("BlogDescription", TypeName = "ntext")]
public string Description { get; set; }
```

The same attribute as used to designate the order in created a complex key, `[Column]` will also set the column name and properties when created by code-first programming.

---

## DatabaseGenerated

<table>
	<tr>
		<td colspan="2"><code>[DatabaseGenerated(databaseGeneratedOption DatabaseGeneratedOption)]</code></td>
	</tr>
	<tr>
		<td><i>databaseGeneratedOption</i></td>
		<td>Enum that represents when the database should automatically generate a value</td>
	</tr>
</table>

[SchoolEntities.cs](/MyLibrary.EF/Context/SchoolEntities.cs)

```csharp
[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
public string CatalogId { get; set; }
```

If you have computed fields in the database, you don't want to update them when updating the table. Marking these fields as `[DatabaseGenerated(DatabaseGenerationOption.Computed)]` will ensure that the fields are not updated, but they do return a value when requested.

**_Notes:_**
* Use this attribute on byte or timestamp columns when code first is generating the database. Otherwise, only use this when pointing to existing databases.
* A primary key that is an integer will automatically become an identity column (auto-generated). Use DatabaseGenerationOption.None to override that setting.
---

## Index

<table>
	<tr>
		<td colspan="2"><code>[Index(name string, [IsClustered = isClustered bool, IsUnique = isUnique bool, Order = order int])]</code></td>
	</tr>
	<tr>
		<td colspan="2"><code>[Index(name string, order int, [IsClustered = isClustered bool, IsUnique = isUnique bool])]</code></td>
	</tr>
	<tr>
		<td colspan="2"><code>[Index([name string, IsClustered = isClustered bool, IsUnique = isUnique bool, Order = order int])]</code></td>
	</tr>
	<tr>
		<td><i>isClustered</i></td>
		<td>Whether the index is defined as a clustered index, which stores rows in the table in a sorted order. (Optional)</td>
	</tr>
	<tr>
		<td><i>isUnique</i></td>
		<td>Whether the index enforces that all values inside must be unique (Optional)</td>
	</tr>
	<tr>
		<td><i>name</i></td>
		<td>Name of the index (Optional)</td>
	</tr>
	<tr>
		<td><i>order</i></td>
		<td>Positional order of the field in a 0-based array indicated as an integer (Optional)</td>
	</tr>
</table>

### One-column Index
[User.cs](User.cs)

```csharp
[Index(IsUnique = true)]
public string Username { get; set; }
```

In order to create an index on one or more fields, decorate them with the `[Index]` attribute.

**_Notes:_** 
* By default, if no name is specified, the index will be named "IX_{columnName}". 
* There can only be one clustered index on a table, since a cluster will reorganize the rows inside the table and there can only be one order.

### Multi-column Index

[SchoolEntities.cs](/MyLibrary.EF/Context/SchoolEntities.cs)

```csharp
[Index("Catalog", Order = 1)]
public int CourseID { get; set; }
[Index("Catalog", 2)]
public string Title { get; set; }
```

In order to create an index on more than one fields, decorate them with the `[Index]` attribute, name the index, and specify the order in which the columns are to be indexed, similar to how the `[Key]` attribute works.

**_Notes:_** 
* There are multiple constructors for this attribute.

---

## InverseProperty

<table>
	<tr>
		<td colspan="2"><code>[InverseProperty(property string)]</code></td>
	</tr>
	<tr>
		<td><i>property</i></td>
		<td>The navigation property representing the other end of the same relationship</td>
	</tr>
</table> 

[SchoolEntities.cs](/MyLibrary.EF/Context/SchoolEntities.cs)

```csharp
public class Course
{
	// Primary key
	public int CourseID { get; set; }

	// Navigation properties
	public virtual Department Department { get; set; }
	[ForeignKey("OnlineTeacher")]
	public int? OnlineTeacherId {get; set;}
	public Teacher OnlineTeacher { get; set; }	
	public Teacher ClassRoomTeacher { get; set; }
}

public class Teacher
{
	public int TeacherId { get; set; }
	public string Name { get; set; }

	[InverseProperty("OnlineTeacher")]
	public ICollection<OnlineCourse> OnlineCourses { get; set; }
	[InverseProperty("ClassRoomTeacher")]
	public ICollection<OnsiteCourse> ClassRoomCourses { get; set; }
}
```

When there is a many-to-many relationship between properties, EF doesn't know how to create the relationships. Marking the navigation properties as `[InverseProperty(property)]` tells EF that the corresponding field (the other side of the many-to-many) can be found at `property`.

**_Notes:_** 
* Decorating the property with the `[ForeignKey(name)]` attribute will set the name of the index. Otherwise, it will be named "{property}\_{propertyname}".