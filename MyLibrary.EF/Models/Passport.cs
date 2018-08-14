#region header

// Copyright (c) 2018
// Author:         Nicholas Hamlin Created Date: 08/02/2018
// Filename: MyLibrary:MyLibrary.EF:Passport.cs Usage:

#endregion header

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.EF.Models
{
	public class Passport
	{
		// Tags: Composite Keys, Column Ordering
		[Key]
		[Column(Order = 1)]
		public int PassportNumber { get; set; }

		[Key]
		[Column(Order = 2)]
		public string IssuingCountry { get; set; }

		public DateTime Issued { get; set; }
		[Required]
		public DateTime Expires { get; set; }
	}

	public class PassportStamp
	{
		[Key]
		public int StampId { get; set; }

		public DateTime Stamped { get; set; }
		public string StampingCountry { get; set; }

		// Tags: Composite Foreign Keys
		[ForeignKey("Passport")]
		[Column(Order = 1)]
		public int PassportNumber { get; set; }

		[ForeignKey("Passport")]
		[Column(Order = 2)]
		public string IssuingCountry { get; set; }

		public Passport Passport { get; set; }
	}
}