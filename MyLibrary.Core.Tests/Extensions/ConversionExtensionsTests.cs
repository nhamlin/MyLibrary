using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Core.Extensions;

namespace MyLibrary.Core.MSTests
{
	[TestClass()]
	public class ConversionExtensionsTests
	{
		[TestMethod()]
		public void ConvertToTest()
		{
			Assert.IsTrue(true);
		}

		[TestMethod()]
		public void ConvertToWithErrorTest()
		{
		    string age = "28";
		    var birthday = DateTime.Today.AddYears(-age.ConvertTo<int>());
            
            Assert.IsTrue(birthday.Year == 1991);
		}

		[TestMethod()]
		public void GetSafeTest()
		{
			Assert.IsTrue(true);
		}

		[TestMethod()]
		public void HashByTest()
		{
			Assert.IsTrue(true);
		}
	}
}