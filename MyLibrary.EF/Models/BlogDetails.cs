#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/31/2018
// Filename: MyLibrary:MyLibrary.EF:BlogDetails.cs
// Usage:          
#endregion

using System;

namespace MyLibrary.EF.Models
{
	public class Details
	{
		// Example of a complex type in Entity Framework. (https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/conventions/built-in#complex-types-convention)
		// Because there isn't a primary key, code first marks this as a complex type.
		// Note: This cannot be referenced from a collection property on another type nor can it have properties that reference entity types.
		public DateTime Time { get; set; }
		public string Location { get; set; }
		public string Days { get; set; }
	}
}
