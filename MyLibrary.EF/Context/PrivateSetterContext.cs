using System.Data.Entity;
using MyLibrary.EF.Models;

namespace MyLibrary.EF.Context
{
	public class PrivateSetterContext : DbContext
	{
		// Note: that DbContext caches the instance of DbSet returned from the Set method.
		public virtual DbSet<Blog> Blogs => Set<Blog>();
		public virtual DbSet<Post> Posts => Set<Post>();

		public PrivateSetterContext()
			: base("name=PrivateSetterContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
