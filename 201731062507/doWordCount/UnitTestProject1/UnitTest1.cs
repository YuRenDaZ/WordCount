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
            int line = doCount.CountLine("C:\\Text.txt");
            Console.WriteLine(line);
        }
        [TestMethod]
        public void TestMethod2()//测试doCount.CountFrequency计算每个单词频数
        {
            DoCount doCount = new DoCount();
            Dictionary<string,int> dictionary=doCount.CountF("c:\\Text.txt");
            dictionary=doCount.DescSort(dictionary);
             foreach (KeyValuePair<string,int> dic in dictionary)
             {
                 Console.WriteLine(dic.Key+" "+dic.Value );
             }
        }
        [TestMethod]
        public void TestMethod3()//测试doCount.CountCahr计算文章总的字母个数
        {
            DoCount doCount = new DoCount();
            Console.WriteLine(doCount.CountChar("c:\\Text.txt"));
        }
        [TestMethod]
        public void TestMethod4()//测试doCount.CountCahr计算文章总的字母个数
        {
            DoCount doCount = new DoCount();
            doCount.Write("c:\\Text.txt", "c:\\output.txt");
        }
    }
}
