#region header
// Copyright (c) 2018
// Author:         Nicholas Hamlin
// Created Date:  07/06/2018
// Filename: MyLibrary:MyLibrary:IRssFeed.cs
// Usage:          
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyLibrary.Interfaces
{
	/// <summary>
	/// An interface for an RSS Feed object
	/// </summary>
	public interface IRssFeed
	{
		/// <summary>
		/// The URL to the HTML website corresponding to the channel
		/// </summary>
		Uri FeedUrl { get; set; }
		/// <summary>
		/// The culture the channel is written in (ex "en-US")
		/// </summary>
		/// <example>FeedLanguage = new CultureInfo("en-US")</example>
		CultureInfo FeedLanguage { get; set; }
		/// <summary>
		/// List of articles from the RSS feed
		/// </summary>
		IEnumerable<IRssItem> Articles { get; set; }
	}
}
