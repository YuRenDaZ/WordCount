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
    public class SplitStringTests
    {
        [TestMethod()]
        public void storestringTest()
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.IsTrue(SplitString.storestring("a b c d e"," ").All(list.Contains)&& SplitString.storestring("a b c d e", " ").Count==list.Count);
            Assert.IsFalse(SplitString.storestring("a b c d e", " ").All(list.Contains) && SplitString.storestring("a b c d e", " ").Count != list.Count);
        }
    }
}