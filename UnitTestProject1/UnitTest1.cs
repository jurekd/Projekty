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
            Cz�onekZespo�u cz = new Cz�onekZespo�u("A", "B");
            Assert.AreEqual(cz.Imie, "A");
        }
    }
}
