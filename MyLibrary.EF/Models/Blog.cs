#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:Blog.cs
// Usage:          
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.EF.Models
{
	public class Blog
	{
		public int BlogId { get; set; }
		[ConcurrencyCheck]
		[MinLength(5)]
		[MaxLength(30, ErrorMessage = "The name can't be more than 30 characters long.")]
		public string Name { get; set; }
		public string Url { get; set; }
		public User Owner { get; set; }
		public int Rating { get; set; }
		public BlogDetails BlogDetails { get; set; }

		/// <summary>
		/// Marked virtual to allow lazy loading.
		/// </summary>
		public virtual List<Post> Posts { get; set; }
	}
}
