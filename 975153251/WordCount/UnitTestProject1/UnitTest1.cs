using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileInfo file = new FileInfo(@"D:\input.txt");
            StreamReader sw = file.OpenText();
            List<string> test = new List<string>();
            string str = sw.ReadToEnd();
            int twords = 314;
            S  s = new S() ;
            int words = s.Countwords(str, test);
            Assert.IsTrue(words == twords);
        }
    }
}
