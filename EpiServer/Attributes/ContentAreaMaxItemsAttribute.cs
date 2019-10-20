using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;

namespace EpiServer.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ContentAreaMaxItemsAttribute : ValidationAttribute
	{
		private int _max;

		public ContentAreaMaxItemsAttribute(int max)
		{
			_max = max;
		}

		public override bool IsValid(object value)
		{
			if (value == null)
			{
				return true;
			}

			if (!(value is ContentArea))
			{
				throw new ValidationException("ContentAreaMaxItemsAttribute is intended to be used with ContentArea properties only.");
			}

			var contentArea = (ContentArea)value;
			if (contentArea.Count > _max)
			{
                ErrorMessage = $"{contentArea} restricted to {_max} content items";
				return false;
			}

			return true;
		}
	}
}
