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
    public class CountTests
    {
        [TestMethod()]
        public void CountWordTest()
        {
            List<string> temp = new List<string>();
            temp.Add("a");
            temp.Add("b");
            temp.Add("b");
            temp.Add("c");
            temp.Add("c");
            temp.Add("c");
            Dictionary<string, int> worddic = new Dictionary<string, int>();
            Dictionary<string, int> wordtempdic = new Dictionary<string, int>();
            worddic = Count.CountWord(temp);
            int flag = 0;
            int res = 1;
            foreach(string key in worddic.Keys)
            {
                if (worddic[key] != res)
                {
                    flag++;
                }
                res++;
            }
            Assert.IsTrue(flag == 0);
            Assert.IsFalse(flag != 0);
            
        }

        [TestMethod()]
        public void SortValueTest()
        {
            List<string> temp = new List<string>();
            temp.Add("a");
            temp.Add("b");
            temp.Add("b");
            temp.Add("c");
            temp.Add("c");
            temp.Add("c");
            Dictionary<string, int> sortDic = new Dictionary<string, int>();
            Dictionary<string, int> sortTempDic = new Dictionary<string, int>();
            sortTempDic = Count.SortValue(sortDic);
            string[] tempStr = { "c", "b", "a" };
            int tempNum = 0;
            int flag = 0;
            foreach (string key in sortTempDic.Keys)
            {
                if (key == tempStr[tempNum])
                {
                    flag++;
                }
                tempNum++;
            }
            Assert.IsTrue(flag == 0);
            Assert.IsFalse(flag != 0);
        }

        [TestMethod()]
        public void SortKeyTest()
        {
            List<string> temp = new List<string>();
            temp.Add("a");
            temp.Add("b");
            temp.Add("b");
            temp.Add("c");
            temp.Add("c");
            temp.Add("c");
            Dictionary<string, int> sortDic = new Dictionary<string, int>();
            Dictionary<string, int> sortTempDic = new Dictionary<string, int>();
            sortTempDic = Count.SortValue(sortDic);
            string[] tempStr = { "a", "b", "c" };
            int tempNum = 0;
            int flag = 0;
            foreach (string key in sortTempDic.Keys)
            {
                if (key == tempStr[tempNum])
                {
                    flag++;
                }
                tempNum++;
            }
            Assert.IsTrue(flag == 0);
            Assert.IsFalse(flag != 0);
        }
    }
}