using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using doWordCount;

namespace doWordCount
{
    public class DoCount : Count
    {
        public int CountChar(string path) //计算总字母个数
        {
            StreamReader sr = new StreamReader(path);
            string s;
            char[] charArray;
            int AllChar = 0;
            while ((s = sr.ReadLine()) != null)
            {
                charArray = s.ToCharArray();
                for(int j = 0; j < charArray.Length; j++)
                {
                    if ((charArray[j] > 'a' && charArray[j] < 'z') || (charArray[j] > 'A' && charArray[j] < 'Z') || (charArray[j] > '0' && charArray[j] < '9'))
                    {
                        AllChar++;
                    }
                }
            }
            return AllChar;
        }

        public Dictionary<string,int> CountF(string path)//计算每个单词的频数
        {
            StreamReader sr = new StreamReader(path);
            string s;
            Dictionary<string, int> fre = new Dictionary<string, int>();
            while ((s = sr.ReadLine()) != null)
            {
                string[] words = Regex.Split(s, " ");
                // string[] words = Regex.Split(s,@"\W+");
                foreach (string word in words)
                {
                    if (fre.ContainsKey(word))
                    {
                        fre[word]++;
                    }
                    else
                    {
                        fre[word] = 1;
                    }
                }
            }
            return fre;
        }

        public int CountLine(string path)//计算总行数
        {
            StreamReader sr = new StreamReader(path);
            string s;
            int line = 0;
            while ((s=sr.ReadLine())!=null)
            {
                line++;
            }
            return line;
        }

        public int CountWord(string path)//计算总单词个数
        {
            DoCount doCount = new DoCount();
            Dictionary<string, int> dictionary = doCount.CountF(path);
            int AllWord = 0;
            foreach (KeyValuePair<string, int> dic in dictionary)
            {
                AllWord += dic.Value;
            }
            return AllWord;
        }

        public Dictionary<string, int> DescSort(Dictionary<string, int> dic)//将字母按频数降序排序
        {
            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(dic);
            myList.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)
            {
                return s2.Value.CompareTo(s1.Value);
            });
            dic.Clear();
            foreach (KeyValuePair<string, int> pair in myList)
            {
                if(pair.Key!=null&&pair.Key!=":"&&pair.Key!=","&&pair.Key!=".")
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }

        public void Write(string path, string outPath)
        {
            DoCount doCount = new DoCount();
            int countword = doCount.CountWord(path);
            int countchar = doCount.CountChar(path);
            int countline = doCount.CountLine(path);
            StreamWriter sw = null;
            Dictionary<string, int> a = doCount.DescSort(doCount.CountF(path));
            if (outPath == null)
            {
                sw = new StreamWriter(@"C:\Users\19334\Desktop\output.txt");
            }
            if (outPath != null)
            {
                sw = new StreamWriter(outPath);
            }
            Console.SetOut(sw);
            Console.WriteLine("字符数：" + countchar);
            Console.WriteLine("单词数：" + countword);
            Console.WriteLine("行数：" + countline);
            Console.WriteLine("出现次数：");
            foreach (KeyValuePair<string, int> pair in a)
            {
                string key = pair.Key;
                int value = pair.Value;
                Console.WriteLine("{0}  {1}", key, value);
            }
            sw.Flush();
            sw.Close();
        }

    }
}
