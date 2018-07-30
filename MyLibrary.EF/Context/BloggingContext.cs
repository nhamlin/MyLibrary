#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:BloggingContext.cs
// Usage:          
#endregion

using System.Data.Entity;
using MyLibrary.EF.Models;

namespace MyLibrary.EF.Context
{
	public class BloggingContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Overrides the default column name for DisplayName
			modelBuilder.Entity<User>()
						.Property(u => u.DisplayName)
						.HasColumnName("display_name");
		}
	}
}
