using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyLibrary.EF.Models;

namespace MyLibrary.EF.Context
{
	public sealed class Blog
	{
		public int BlogId { get; set; }

		public string Name { get; set; }

		[StringLength(128)]
		public User Owner { get; set; }
		
		public ICollection<Post> Posts { get; set; }

		public int Rating { get; set; }

		public string Url { get; set; }
		
		public Blog()
		{
			Posts = new HashSet<Post>();
		}
	}
}
