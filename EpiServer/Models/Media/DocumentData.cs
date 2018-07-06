using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EpiServer.Models.Media
{
	[ContentType(DisplayName = "Document Data", GUID = "43932431-d09c-463b-9666-9b747417eec1", Description = "")]
	/*[MediaDescriptor(ExtensionString = "pdf,doc,docx,xls,xlsx,zip,txt,ppt,pptx,md")]*/
	public class DocumentData : MediaData
	{
		[CultureSpecific]
		[Display(
			Name="Document Title",
			GroupName = SystemTabNames.Content,
			Order=10)]
		public virtual string Title { get; set; }

		[CultureSpecific]
		[Display(
			Name = "Description",
			GroupName = SystemTabNames.Content,
			Order = 20)]
		[UIHint(UIHint.Textarea)]
		public virtual string Description { get; set; }

		[Display(
			Name="Filesize",
			GroupName = SystemTabNames.Content,
			Order=30)]
		[Editable(false)]
		public virtual string Filesize { get; set; }

		public bool IsVideo => false;

		//[Display(
		//	Name = "Associated Products",
		//	GroupName = SystemTabNames.Content,
		//	Order = 40)]
		//[CultureSpecific]
		//public virtual ContentArea Products { get; set; }

		[Display(
			Name="Languages",
			GroupName = SystemTabNames.Content,
			Order=40)]
		//[AllowedTypes(typeof(TagTerm))]
		public virtual ContentArea Languages { get; set; }

		[CultureSpecific]
		[Display(
			Name="Thumbnail Image",
			GroupName = SystemTabNames.Content,
			Order = 50)]
		[UIHint(UIHint.Image)]
		public virtual ContentReference ThumbnailImage { get; set; }
	}
}