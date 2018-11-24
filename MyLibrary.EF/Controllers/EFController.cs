#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:CodeFirstNewDatabaseController.cs
// Usage:

#endregion header

using System.Data.Entity;
using MyLibrary.EF.Context;
using MyLibrary.EF.Models;
using Blog = MyLibrary.EF.Context.Blog;

namespace MyLibrary.EF.Controllers
{
	public class EFController
	{
		#region Upsert

		public void Upsert(Blog blog)
		{
			using (var context = new BloggingContext())
			{
				context.Entry(blog).State = blog.BlogId == 0 ? EntityState.Added : EntityState.Modified;
				context.SaveChanges();
			}
		}

		#endregion Upsert

		#region Add

		// Adding an entity using the Add method
		public void AddByMethod()
		{
			using (var context = new BloggingContext())
			{
				var blog = new Blog { Name = "AddMethod Blog" };
				context.Blogs.Add(blog);
				context.SaveChanges();
			}
		}

		// Adding an entity by changing its state
		public void AddByChangingState()
		{
			using (var context = new BloggingContext())
			{
				var blog = new Blog { Name = "Add_ChangeState Blog" };
				context.Entry(blog).State = EntityState.Added;
				context.SaveChanges();
			}
		}

		// Adding an entity by setting a reference from an already-tracked entity
		public void AddByReference()
		{
			using (var context = new BloggingContext())
			{
				var blog = context.Blogs.Find(1) ?? new Blog();
				blog.Owner = new User { Username = "johndoe1987" };
				context.SaveChanges();
			}
		}

		// Adding an entity by adding to a collection in an already-tracked entity
		public void AddToCollection()
		{
			using (var context = new BloggingContext())
			{
				var blog = context.Blogs.Find(2) ?? new Blog();
				blog.Posts.Add(new Post { Title = "How To Add Entities" });
				context.SaveChanges();
			}
		}

		#endregion Add

		#region Attach

		/// <summary>
		///     Entity exists in the database, but is not being tracked by the context. This attaches it to the context so it can
		///     be tracked.
		/// </summary>
		public void AttachExistingNotTrackedEntity()
		{
			var existingBlog = new Blog { BlogId = 1, Name = "ADO.NET Blog" };

			using (var context = new BloggingContext())
			{
				context.Blogs.Attach(existingBlog);

				// Do some more work or else SaveChanges() doesn't do anything...

				context.SaveChanges();
			}
		}

		/// <summary>
		///     Entity exists in the database, but is not being tracked by the context. This attaches it to the context by changing
		///     its state so it can be tracked.
		/// </summary>
		public void AttachExistingNotTrackedEntityChangeState()
		{
			var existingBlog = new Blog { BlogId = 1, Name = "ADO.NET Blog" };

			using (var context = new BloggingContext())
			{
				context.Entry(existingBlog).State = EntityState.Unchanged;

				// Do some more work or else SaveChanges() doesn't do anything...

				context.SaveChanges();
			}
		}

		/// <summary>
		///     Entity exists in the database and might be modified but it's not being tracked in the context. This attaches it to
		///     the context by changing its state so it can be tracked.
		///     <para>
		///         Note: When you change the state to Modified all the properties of the entity will be marked as modified and all
		///         the
		///         property values will be sent to the database when SaveChanges is called.
		///     </para>
		/// </summary>
		public void AttachExistingModifiedNotTrackedEntityChangeState()
		{
			var existingBlog = new Blog { BlogId = 1, Name = "ADO.NET Blog with Changes" };

			using (var context = new BloggingContext())
			{
				context.Entry(existingBlog).State = EntityState.Modified;

				// Do some more work or else SaveChanges() doesn't do anything...

				context.SaveChanges();
			}
		}

		#endregion Attach
	}
}