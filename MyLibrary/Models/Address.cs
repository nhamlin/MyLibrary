namespace MyLibrary.Models
{
	/// <summary>
	/// Class to hold information about addresses
	/// </summary>
    public class Address
    {
		/// <summary>
		/// Address line one
		/// </summary>
		public string AddressLine1 { get; set; }

		/// <summary>
		/// Address line two
		/// </summary>
		public string AddressLine2 { get; set; }

		/// <summary>
		/// Address line three
		/// </summary>
		public string AddressLine3 { get; set; }

		/// <summary>
		/// City
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// State
		/// </summary>
		public State State { get; set; }

		/// <summary>
		/// Country
		/// </summary>
		public Country Country { get; set; }

		/// <summary>
		/// Postal/Zip code
		/// </summary>
		public string PostalCode { get; set; }
    }
}
