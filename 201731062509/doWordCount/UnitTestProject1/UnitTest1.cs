using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using doWordCount;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()//测试doCount.CountLine计算文章总行数
        {
            DoCount doCount = new DoCount();
            int line = doCount.CountLine("e:\\Text.txt");
            Console.WriteLine(line);
        }
        [TestMethod]
        public void TestMethod2()//测试doCount.CountFrequency计算每个单词频数
        {
            DoCount doCount = new DoCount();
            Dictionary<string,int> dictionary=doCount.CountFrequency("e:\\Text1.txt");
            dictionary=doCount.SortDictionary_Desc(dictionary);
             foreach (KeyValuePair<string,int> dic in dictionary)
             {
                Console.WriteLine("单词：" + dic.Key + "\t         " + "\t频数：" + dic.Value);
            }
        }
        [TestMethod]
        public void TestMethod3()//测试doCount.CountCahr计算文章总的字母个数
        {
            DoCount doCount = new DoCount();
            Console.WriteLine(doCount.CountChar("e:\\Text1.txt"));
        }
        [TestMethod]
        public void TestMethod4()//测试doCount.CountCahr计算文章总的字母个数
        {
            DoCount doCount = new DoCount();
            doCount.WriteToTxt("e:\\Text1.txt","e:\\output.txt");
        }
    }
}
