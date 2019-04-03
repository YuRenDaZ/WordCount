using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileInfo file = new FileInfo(@"D:\input.txt");
            StreamReader sw = file.OpenText();
            List<string> test = new List<string>();
            string str = sw.ReadToEnd();
            int tlines = 6;
            S s = new S();
            int words = s.Countlines(str);
            Assert.IsTrue(words == tlines);
        }
    }
}
