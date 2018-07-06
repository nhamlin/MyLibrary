using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiServer.Models
{
	[ContentType(DisplayName = "Start Page", GUID = "d34c5d0c-320f-470e-99c7-84cc9fb3afc0", Description = "")]
	public class StartPage : PageData
	{
		/*
				[CultureSpecific]
				[Display(
					Name = "Main body",
					Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
					GroupName = SystemTabNames.Content,
					Order = 1)]
				public virtual XhtmlString MainBody { get; set; }
		 */
	}
}
