using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Core.Extensions;

namespace MyLibrary.Core.MSTests
{
	[TestClass()]
	public class BufferExtensionsTests
	{
		[TestMethod()]
		public void AsStringTest()
		{
            // Arrange 
		    byte[] source = Encoding.ASCII.GetBytes("My string");

            // Act
		    string result = source.AsString();

            // Assert
            Assert.IsTrue(result == "My string");
		}
	}
}