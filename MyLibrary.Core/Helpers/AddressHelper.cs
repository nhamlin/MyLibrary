﻿using System;
using System.Collections.Generic;
using log4net;
using MyLibrary.Models;

namespace MyLibrary.Core.Helpers
{
	/// <summary>
	///     Methods to extend and format Addresses
	/// </summary>
	public static class AddressHelper
	{
		private static readonly ILog _logger = LogManager.GetLogger(typeof(AddressHelper));

		/// <summary>
		///     Formats an address into a string
		/// </summary>
		/// <param name="source"><see cref="Address" /> to be formatted</param>
		/// <returns></returns>
		public static string Format(this Address source)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Determines whether the postal/zip code is valid.
		/// </summary>
		/// <param name="source">Postal/Zip code</param>
		/// <param name="country">Country of origin</param>
		/// <returns></returns>
		public static bool IsValidZip(this string source, Country country)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Returns a list of <see cref="State" /> for a given country.
		/// </summary>
		/// <param name="country">The <see cref="Country" /> to get the states from.</param>
		/// <returns></returns>
		public static IList<State> GetStates(this Country country)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Returns a list of countries in a given region.
		/// </summary>
		/// <param name="region">The enum of the region represented as an integer</param>
		/// <returns></returns>
		public static IList<Country> GetCountries(this Region region)
		{
			throw new NotImplementedException();
		}
	}
}
