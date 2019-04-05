using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testWordCount
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string filepath = (@"E:\gitlearn\WordCount\guozhaojie\WordCount\ConsoleApp1\bin\Debug\love.txt");
            Assert.IsTrue(System.IO.File.Exists (filepath));
            
        }
    }
}
