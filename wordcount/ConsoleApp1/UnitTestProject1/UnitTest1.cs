using System;
using ConsoleApp2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            Assert.AreEqual(97050, Convert.ToInt32(Program.word()));
        }
    }
}
