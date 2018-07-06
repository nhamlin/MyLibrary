#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:IRssItem.cs
// Usage:          
#endregion

namespace MyLibrary.Interfaces
{
	/// <summary>
	/// Individual RSS Feed article
	/// </summary>
	public interface IRssItem
	{
		/// <summary>
		///  Title of the article
		/// </summary>
		string Title { get; set; }
		/// <summary>
		/// URL of the article
		/// </summary>
		string Link { get; set; }
		/// <summary>
		///  Description of the article
		/// </summary>
		string Description { get; set; }
		/// <summary>
		/// Publication Date of the article
		/// </summary>
		string PublicationDate { get; set; }
	}
}
