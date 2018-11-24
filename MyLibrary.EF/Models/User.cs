#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:User.cs
// Usage:

#endregion header

using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.EF.Models
{
	public class User
	{
		public string DisplayName { get; set; }
		public int UserId { get; set; }

		[Index(IsUnique = true)]
		public string Username { get; set; }
	}
}
