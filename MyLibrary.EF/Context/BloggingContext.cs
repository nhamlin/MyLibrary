#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:BloggingContext.cs
// Usage:

#endregion header

using System.Data.Entity;
using MyLibrary.EF.Models;

namespace MyLibrary.EF.Context
{
	/// <summary>
	///     <para>
	///         In addition to defining the classes, you also need to let DbContext know which types you want to include in the
	///         model. To do this, you define a context class that derives from DbContext and exposes DbSet properties for the
	///         types that you want to be part of the model.
	///     </para>
	///     <para>
	///         If your types participate in an inheritance hierarchy, it is enough to define a DbSet property for the base
	///         class, and the derived types will be automatically included
	///     </para>
	/// </summary>
	public class BloggingContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		// This is a privately set DbSet
		public DbSet<Post> Posts => Set<Post>();
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Overrides the default column name for DisplayName
			modelBuilder.Entity<User>()
			            .Property(u => u.DisplayName)
			            .HasColumnName("display_name");

			// Configure Code First to ignore PluralizingTableName convention
			// If you keep this convention, the generated tables  
			// will have pluralized names.
			// NOTE: NEVER DO THIS! YOU'RE NOT BRANDON! Tables are collections, and collections potentially have multiple items 
			//modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public BloggingContext()
			: base("MyLibrary.Database")
		{

		}
	}
}
