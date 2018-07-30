#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:Blog.cs
// Usage:          
#endregion

using System.Collections.Generic;

namespace MyLibrary.EF.Models
{
	public class Blog
	{
		public int BlogId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		/// <summary>
		/// Marked virtual to allow lazy loading.
		/// </summary>
		public virtual List<Post> Posts { get; set; }
	}
}
