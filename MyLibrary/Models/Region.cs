namespace MyLibrary.Models
{
	/// <summary>
	/// Class to hold information about regions
	/// </summary>
	public abstract class Region
    {
		/// <summary>
		/// ISO standard region name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// ISO standard region code
		/// </summary>
		public string Code { get; set; }
    }
}
