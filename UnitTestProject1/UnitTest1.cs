using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekty;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cz³onekZespo³u cz = new Cz³onekZespo³u("A", "B");
            Assert.AreEqual(cz.Imie, "A");
        }
    }
}
