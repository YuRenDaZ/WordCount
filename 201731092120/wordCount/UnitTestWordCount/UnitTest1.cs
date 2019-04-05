using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;

namespace UnitTestWordCount
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Statistics statistics = new Statistics();
            string text = statistics.ReadFile(@"F:\SoftWork\WordCount\201731092120\wordCount\wordCount\bin\Debug\hamlet.txt");
            Assert.AreEqual(180768, statistics.CountChars(text));
            Assert.AreEqual(5592, statistics.CountLines(text));
            Assert.AreEqual(16235, statistics.CountWords(text));

        }
    }
}