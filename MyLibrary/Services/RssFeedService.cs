using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using MyLibrary.Interfaces;
using MyLibrary.Models;

namespace MyLibrary.Core.Services
{
	/// <summary>
	///     Helper method to get an RSS Feed and populate articles
	/// </summary>
	public static class RssFeedService
	{
		/// <summary>
		///     Method to get all Rss Articles from a feed
		/// </summary>
		/// <example>IEnumerable&lt;RssItem&gt; myArticles = RssFeedService.GetRssItems(myRssFeed)</example>
		/// <param name="rssFeed"></param>
		/// <returns></returns>
		public static IEnumerable<RssItem> GetRssItems(IRssFeed rssFeed)
		{
			WebClient wClient = new WebClient();
			string rssData = wClient.DownloadString(rssFeed.FeedUrl.AbsoluteUri);
			XDocument xDoc = XDocument.Parse(rssData);
			var rssFeedData = from x in xDoc.Descendants("item")
			                  select new RssItem
			                  {
				                  Title = (string)x.Element("title"),
				                  Link = (string)x.Element("link"),
				                  Description = (string)x.Element("description"),
				                  PublicationDate = (string)x.Element("pubDate")
			                  };
			return rssFeedData;
		}
	}
}
