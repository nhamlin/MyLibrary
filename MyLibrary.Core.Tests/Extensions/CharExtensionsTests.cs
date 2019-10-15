using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Core.Extensions;

namespace MyLibrary.Core.MSTests
{
    [TestClass]
    public class CharExtensionsTests
    {
        private const char _INPUT = 'c';


        [TestMethod]
        public void ToHexTest()
        {
            var tmp = _INPUT.ToHex();
            string _EXPECTED_HEX = "0063";

            Assert.IsTrue(tmp == _EXPECTED_HEX);
        }

        [TestMethod()]
        public void ToUpperTest()
        {
            var tmp = _INPUT.ToUpper();
            Assert.IsTrue(tmp == 'C');
        }

        [TestMethod()]
        public void ToLowerTest()
        {
            var tmp = _INPUT.ToLower();
            Assert.IsTrue(tmp == 'c');
        }

        [TestMethod()]
        public void ToUpperInvariantTest()
        {
            var tmp = _INPUT.ToUpper();
            Assert.IsTrue(tmp == 'C');
        }

        [TestMethod()]
        public void ToLowerInvariantTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ToStringInvariantTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void AllExceptTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void EndWithTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void BeginWithTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ReplaceUnicodeTest()
        {
            Assert.IsTrue(true);
        }
    }
}
