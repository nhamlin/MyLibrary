#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:Post.cs
// Usage:          

#endregion

namespace MyLibrary.EF.Models
{
	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int BlogId { get; set; }
		/// <summary>
		/// Marked virtual to allow lazy loading
		/// </summary>
		public virtual Blog Blog { get; set; }

	}
}
