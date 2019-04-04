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
    public class TransformTests
    {
        [TestMethod()]
        public void TransFormTest()
        {
            Assert.IsTrue(Transform.TransForm("File FILE 123FILE")=="file file 123file");
        }
    }
}