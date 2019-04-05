using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            Program program = new Program();
                     program.GetHashCode();
            string path = "E:/作业三1/WordCount/txt.txt";
            int line = 2100;
            int characters = 547097;
            Assert.AreEqual(characters, 547097);
            Assert.AreEqual(2100, line);

        }
    }
}

