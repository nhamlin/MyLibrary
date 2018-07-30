#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/30/2018
// Filename: MyLibrary:MyLibrary.EF:User.cs
// Usage:          
#endregion

using System.ComponentModel.DataAnnotations;

namespace MyLibrary.EF.Models
{
	public class User
	{
		/// <summary>
		/// [Key] tells EF that Username is the primary key
		/// </summary>
		[Key]
		public string Username { get; set; }
		public string DisplayName { get; set; }
	}
}
