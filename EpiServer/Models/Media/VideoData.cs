using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EpiServer.Models.Media
{
	[ContentType(DisplayName = "VideoData", GUID = "7ad56ed5-5e8c-4de7-9a0e-3fa8cf685bfa", Description = "")]
	/*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
	public class VideoData : EPiServer.Core.VideoData
	{
		[CultureSpecific]
		[Display(
			Name="Title",
			GroupName = SystemTabNames.Content,
			Order=10)]
		public virtual string Title { get; set; }

		[CultureSpecific]
		[Display(
			Name="Description",
			GroupName = SystemTabNames.Content,
			Order = 20)]
		[UIHint(UIHint.Textarea)]
		public virtual string Description { get; set; }

		[Display(
			Name = "File size",
			GroupName = SystemTabNames.Content,
			Order=30)]
		[Editable(false)]
		public virtual string Filesize { get; set; }

		public bool IsVideo => true;

		[CultureSpecific]
		[Display(
			Name="Thumbnail Image",
			GroupName = SystemTabNames.Content,
			Order = 40)]
		[UIHint(UIHint.Image)]
		public virtual ContentReference ThumnailImage { get; set; }
	}
}