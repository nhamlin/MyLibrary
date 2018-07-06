#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:RssItem.cs
// Usage:          
#endregion

using MyLibrary.Interfaces;
#pragma warning disable 1591

namespace MyLibrary.Models
{
	/// <summary>
	/// Concrete instance of an Rss Item
	/// </summary>
	public class RssItem : IRssItem
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public string Description { get; set; }
		public string PublicationDate { get; set; }
	}
}
