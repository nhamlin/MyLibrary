namespace MyLibrary.Models
{
	/// <summary>
	/// Class to hold information about states
	/// </summary>
	public abstract class State
    {
		/// <summary>
		/// ISO standard state name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// ISO standard state code
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Country the state belongs to
		/// </summary>
		public Country Country { get; set; }
    }
}
