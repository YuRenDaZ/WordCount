using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class JudgeTests
    {
        [TestMethod()]
        public void JudgeWordTest()
        {
            Assert.IsTrue(Judge.JudgeWord("123file")=="");
            Assert.IsTrue(Judge.JudgeWord("file") == "file");
        }
    }
}