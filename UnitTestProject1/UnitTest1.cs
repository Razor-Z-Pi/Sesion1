using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string login = "1";
            string password = "1";
            bool fff = true;


            Assert.AreEqual(fff, login, password);
        }
    }
}
