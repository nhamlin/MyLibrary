## Data Annotations

### Key & ForeignKey
#### Custom Primary Key

[Passport.cs](Passport.cs) Lines 18-20

```csharp
[Key]
public int PassportNumber { get; set; }
```

The convention is to look for a property named `Id` or one that combines the class name with `Id`, such as `PassportId`. If it does not find a property matching this convention, it will throw an exception because of the requirement that you must have a key property. To circumvent this, decorate the property with the `Key` attribute.

#### Composite Keys

[Passport.cs](Passport.cs) Lines 18-24

```csharp
[Key]
[Column(Order = 1)]
public int PassportNumber { get; set; }

[Key]
[Column(Order = 2)]
public string IssuingCountry { get; set; }
```

If the primary key consists of more than one property, simply decorate the properties with the `Key` attribute. But because you have more than one property, EF doesn't know which order to use when building the composite key. Decorate the properties with the `Column(Order=n)` attribute, specifying the Order in which to build the composite key.

#### Foreign Keys

[Passport.cs](Passport.cs) Lines 39-45

```csharp
[ForeignKey("Passport")]
[Column(Order = 1)]
public int PassportNumber { get; set; }

[ForeignKey("Passport")]
[Column(Order = 2)]
public string IssuingCountry { get; set; }
```

Using the same concept as the two previous examples, setting the foreign keys is done by decorating with the `ForeignKey(FK_name)` attribute. If a composite foreign key is made, also include the `Column(Order = n)` attribute to specify the order in which the key is built.


### Required

### MaxLength & MinLength

### NotMapped

### ComplexType

### ConcurrencyCheck

### TimeStamp

### Table & Column

### DatabaseGenerated

### Index

### InverseProperty

### ForeignKey