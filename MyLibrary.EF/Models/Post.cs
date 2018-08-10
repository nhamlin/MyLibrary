#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:Post.cs
// Usage:

#endregion header

using System.ComponentModel.DataAnnotations;

namespace MyLibrary.EF.Models
{
	public class Post
	{
		public int PostId { get; set; }
		[MaxLength(100)]
		public string Title { get; set; }
		public string Content { get; set; }
		public int BlogId { get; set; }
		public string Abstract { get; set; }

		/// <summary>
		/// Marked virtual to allow lazy loading
		/// </summary>
		public virtual Blog Blog { get; set; }
	}
}