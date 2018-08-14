using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MyLibrary.EF.Context
{
	#region Contexts

	/// <summary>
	/// Makes specific types named "Key" as primary key.
	/// </summary>
	public class CustomPrimaryKeyContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomPrimaryKeyContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomPrimaryKeyContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Note: Leave off "<int>" to assign this to properties of all types.
			modelBuilder.Properties<int>()
						.Where(p => p.Name == "Key")
						.Configure(p => p.IsKey());
		}
	}

	/// <summary>
	/// Builds a composite key off multiple fields
	/// </summary>
	public class CustomCompositeKeyContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomCompositeKeyContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomPrimaryKeyContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Note: When building composite keys, the order of the keys must also be included
			// Also see Attributes of [Key] & [Column(Order=n)]
			modelBuilder.Properties<int>()
						.Where(x => x.Name == "Key")
						.Configure(x => x.IsKey().HasColumnOrder(1));

			modelBuilder.Properties()
						.Where(x => x.Name == "Name")
						.Configure(x => x.IsKey().HasColumnOrder(2));
		}
	}

	/// <summary>
	/// Sets all DataTime properties to map to the datetime2 type in SQL Server instead of datetime
	/// </summary>
	public class CustomDatatypeContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomDatatypeContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomDatatypeContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<DateTime>()
						.Configure(x => x.HasColumnType("datetime2"));
		}
	}

	/// <summary>
	/// A class that defines a custom convention to be used in the DbContext
	/// </summary>
	public class CustomConventionClassContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomConventionClassContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomDatatypeContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<int>()
						.Where(x => x.Name.EndsWith("Key"))
						.Configure(p => p.IsKey());

			modelBuilder.Conventions.Add(new DateTime2Convention());
		}
	}

	/// <summary>
	/// Applying a convention based on an attribute decorating a property
	/// </summary>
	public class CustomAttributeAllPropertyTypesContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomAttributeAllPropertyTypesContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomAttributeAllPropertyTypesContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties()
						.Where(x => x.GetCustomAttributes(false).OfType<NonUnicode>().Any())
						.Configure(p => p.IsUnicode(false));
			// Note: This attribute is intended for strings only. If it is placed on any other type,
			// this will fail.
		}
	}

	/// <summary>
	/// Applying a convention based on an attribute decorating a property for a specific data type
	/// </summary>
	public class CustomAttributeSpecificTypeContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public CustomAttributeSpecificTypeContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomAttributeSpecificTypeContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties()
						.Where(x => x.GetCustomAttributes(false).OfType<IsUnicode>().Any())
						.Configure(p => p.IsUnicode(p.ClrPropertyInfo.GetCustomAttribute<IsUnicode>().Unicode));

			// Note: Or, by using the .Having() method:
			modelBuilder.Properties()
						.Having(x => x.GetCustomAttributes(false).OfType<IsUnicode>().FirstOrDefault())
						.Configure((config, att) => config.IsUnicode(att.Unicode));
			// If the returned object is null then the property will not be configured, which means
			// you can filter out properties with it just like Where, but it is different in that it
			// will also capture the returned object and pass it to the Configure method.
		}
	}

	/// <summary>
	/// Creating a new convention for a type instead of a property. This will change CamelCase table
	/// names to lower_case_with_underscores
	/// </summary>
	public class CustomTypeConventionContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		private string GetTableName(Type type)
		{
			// Note: This gets the pluralization service from DI since when you call ToTable() below,
			// it will take the string provided as the exact table name. Pluralizing it first will
			// mitigate this issue.
			var pluralizationService = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();

			var result = pluralizationService.Pluralize(type.Name);
			result = Regex.Replace(result, ".[A-Z]", m => m.Value[0] + "_" + m.Value[1]);
			return result.ToLowerInvariant();
		}

		public CustomTypeConventionContext()
			: base("MyLibrary.Database")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomTypeConventionContext>());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Types()
						.Configure(x => x.ToTable(GetTableName(x.ClrType)));

			// Note: Because the following two things modify string properties, they execute in
			//       order, so the latter one overwrites the first for properties where the name = "Name"
			// Tags: execution, order, execution order, built-in, conventions, built in
			modelBuilder.Properties<string>()
						.Configure(c => c.HasMaxLength(500));

			modelBuilder.Properties<string>()
						.Where(x => x.Name == "Name")
						.Configure(c => c.HasMaxLength(250));

			// Note: This will remove a built-in convention, specifically the one that pluralizes table names
			// Tags: built-in, convention, plural, pluralizing, remove
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}

	#endregion Contexts

	#region Models

	public class Product
	{
		public int Key { get; set; }
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public ProductCategory Category { get; set; }
	}

	public class ProductCategory
	{
		public int Key { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; }
	}

	#endregion Models

	#region Classes

	public class DateTime2Convention : Convention
	{
		public DateTime2Convention()
		{
			Properties<DateTime>()
				.Configure(x => x.HasColumnType("datetime2"));
		}
	}

	#endregion Classes

	#region Attributes

	[AttributeUsage(AttributeTargets.Property)]
	public class NonUnicode : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class IsUnicode : Attribute
	{
		public bool Unicode { get; set; }

		public IsUnicode(bool isUnicode)
		{
			Unicode = isUnicode;
		}
	}

	#endregion Attributes
}