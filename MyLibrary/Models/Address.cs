namespace MyLibrary.Models
{
    public class Address
    {
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string City { get; set; }
		public State State { get; set; }
		public Country Country { get; set; }
		public string PostalCode { get; set; }
    }
}
