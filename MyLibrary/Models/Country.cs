using System.Collections.Generic;

namespace MyLibrary.Models
{
	/// <summary>
	///     Class to hold information about countries
	/// </summary>
	public abstract class Country
	{
		/// <summary>
		///     ISO standard country name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     ISO standard country code
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		///     Region the country belongs to
		/// </summary>
		public Region Region { get; set; }

		/// <summary>
		///     Country's official currencies
		/// </summary>
		public IEnumerable<string> Currencies { get; set; }

		/// <summary>
		///     Country's official languages
		/// </summary>
		public IEnumerable<string> Languages { get; set; }
	}
}
