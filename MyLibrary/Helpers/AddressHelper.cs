using System;
using System.Collections.Generic;
using MyLibrary.Models;

namespace MyLibrary.Helpers
{
	/// <summary>
	/// Methods to extend and format Addresses
	/// </summary>
    public static class AddressHelper
    {
	    public static string Format(this Address source)
	    {
			throw new NotImplementedException();
	    }

	    public static bool IsValidZip(this string source)
	    {
			throw new NotImplementedException();
	    }

		/// <summary>
		/// Returns a list of <see cref="State"/> for a given country.
		/// </summary>
		/// <param name="country">The <see cref="Country"/> to get the states from.</param>
		/// <returns></returns>
	    public static IList<State> GetStates(this Country country)
	    {
			throw new NotImplementedException();
	    }

		/// <summary>
		/// Returns a list of countries in a given region.
		/// </summary>
		/// <param name="region">The enum of the region represented as an integer</param>
		/// <returns></returns>
	    public static IList<Country> GetCountries(this Region region)
	    {
			throw new NotImplementedException();
	    }


    }
}
