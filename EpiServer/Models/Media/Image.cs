using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EpiServer.Models.Media
{
	[ContentType(DisplayName = "Image", GUID = "82d9ce3b-8524-478a-b17a-fa248726cf06", Description = "")]
	[MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif,tiff,svg")]
	public class Image : ImageData
	{
		[CultureSpecific]
		[Display(
			Name = "Image Title",
			GroupName = SystemTabNames.Content,
			Order = 10)]
		public virtual string Title { get; set; }

		[CultureSpecific]
		[Display(
			Name = "Description",
			GroupName = SystemTabNames.Content,
			Order = 20)]
		public virtual string Description { get; set; }

		[CultureSpecific]
		[Display(
			Name = "Alt Text",
			GroupName = SystemTabNames.Content,
			Order = 30)]
		public virtual string AltText { get; set; }
	}
}
