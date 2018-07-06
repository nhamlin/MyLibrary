using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EpiServer.Extensions
{
	public static class PageExtensions
	{
		public static string GetLinkTarget(this PageData page)
		{
			return (page.Property["PageTargetFrame"] as PropertyFrame)?.FrameName;
		}

		public static PageReference GetShortcutPageReference(this PageData page)
		{
			return page["PageShortcutLink"] as PageReference;
		}
	}
}
