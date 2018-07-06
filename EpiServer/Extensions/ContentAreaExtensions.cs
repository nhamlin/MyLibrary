using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using MyLibrary.Extensions;

namespace EpiServer.Extensions
{
	public static class ContentAreaExtensions
	{
		public static IEnumerable<T> GetContentItems<T>(this ContentArea contentArea)
			where T : ContentData
		{
			if (!contentArea.IsNullOrEmpty())
			{
				return contentArea.FilteredItems.Select(item => item.GetContent() as T).RemoveNull();
			}

			return Enumerable.Empty<T>();
		}

		public static bool IsNullOrEmpty(this ContentArea contentArea)
		{
			return contentArea?.FilteredItems != null && contentArea.FilteredItems.Any();
		}
	}
}
