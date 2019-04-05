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
    public class ImportFileTests
    {
        [TestMethod()]
        public void ImportMyFileTest()
        {
            Assert.IsTrue(ImportFile.ImportMyFile("test.txt")== "This is a file that is used to test"&&ImportFile.FileLines("test.txt")==1);
            Assert.IsFalse(ImportFile.ImportMyFile("test.txt") != "This is a file that is used to test" && ImportFile.FileLines("test.txt") != 1);
        }
    }
}