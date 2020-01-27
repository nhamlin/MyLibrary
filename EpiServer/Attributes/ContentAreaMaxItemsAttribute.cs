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

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is ContentArea))
            {
                throw new ValidationException("ContentAreaMaxItemsAttribute is intended to be used with ContentArea properties only.");
            }

            var contentArea = (ContentArea)value;
            if (contentArea.Count > _max)
            {
                ErrorMessage = $"{validationContext.DisplayName} is restricted to a maximum of {_max} content items";
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
