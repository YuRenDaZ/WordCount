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
        public void WriteToTxt(string path,string outPath)//将结果写入文件，path为读入文件路径（以下path均为读入文件路径），outPath为输入结果文件路径
        {
            DoCount doCount = new DoCount();
            int countword = doCount.CountWord(path);//调用计算总单词数方法，结果保存在countword
            int countchar = doCount.CountChar(path);//调用计算总字符数方法，结果保存在countchar
            int countline = doCount.CountLine(path);//调用计算行数方法，结果保存在countline
            StreamWriter sw=null;
            Dictionary<string, int> a = doCount.SortDictionary_Desc(doCount.CountFrequency(path));//调用计算频数并排序的方法，将结果保存到dictionary字典中
            if (outPath == null)
            {
                sw = new StreamWriter(@"E:\博客\201731062509\output.txt");//在默认路径创建写文件流
            }
            if (outPath != null)
            {
                sw = new StreamWriter(outPath);//在自定义path路径创建写文件流
            }
            Console.SetOut(sw);//结果写入文件
            Console.WriteLine("字符数：" + countchar);
            Console.WriteLine("单词数：" + countword);
            Console.WriteLine("行数：" + countline);
            Console.WriteLine("出现次数：");
            foreach (KeyValuePair<string, int> pair in a)//遍历a字典里面的每一条信息
            {
                string key = pair.Key;
                int value = pair.Value;
                Console.WriteLine("{0}  {1}", key, value);
            }
            sw.Flush();
            sw.Close();
        }

        public int CountChar(string path) //计算并返回总字符个数
        {
            StreamReader sr = new StreamReader(path);//在自定义path路径创建读文件流
            string s;
            char[] charArray;
            int AllChar = 0;
            while ((s = sr.ReadLine()) != null)//读取文件的每一行
            {
                charArray = s.ToCharArray();//将读取的每一行送入char数组中
                for(int j = 0; j < charArray.Length; j++)
                {
                    AllChar++;//计算每一个字符
                }
            }
            return AllChar;
        }

        public Dictionary<string,int> CountFrequency(string path)//计算每个单词的频数，结果传入字典并返回,字典中的key是单词的值，value是单词的频数
        {
            StreamReader sr = new StreamReader(path);//在自定义path路径创建读文件流
            string s;
            Dictionary<string, int> fre = new Dictionary<string, int>();
            while ((s = sr.ReadLine()) != null)//读取文件的每一行到字符串s
            {
                string[] words = Regex.Split(s, " ");//将字符串s按空格分割，即划分每一个单词
                // string[] words = Regex.Split(s,@"\W+");
                foreach (string word in words)//计算每行各个单词数
                {
                    if (fre.ContainsKey(word))//判断字典是否包含该单词，若包含，该单词频数加一，若不包含，将该单词添加到字典
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

        public int CountLine(string path)//计算并返回总行数
        {
            StreamReader sr = new StreamReader(path);//在自定义path路径创建读文件流
            string s;
            int line = 0;
            while ((s=sr.ReadLine())!=null)//读取文件总行数
            {
                line++;
            }
            return line;
        }

        public int CountWord(string path)//计算总单词个数
        {
            DoCount doCount = new DoCount();
            Dictionary<string, int> dictionary = doCount.CountFrequency(path);
            int AllWord = 0;
            foreach (KeyValuePair<string, int> dic in dictionary)//遍历字典里面的每一个单词，结果为总单词数
            {
                AllWord += dic.Value;
            }
            return AllWord;
        }

        public Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic)//将字母按频数降序排序
        {
            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(dic);
            myList.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)//按value比较两个单词，并按value大小排序
            {
                return s2.Value.CompareTo(s1.Value);
            });
            dic.Clear();
            foreach (KeyValuePair<string, int> pair in myList)//遍历整个字典，并按value值为字典排序
            {
                if(pair.Key!=null&&pair.Key!=":"&&pair.Key!=","&&pair.Key!=".")
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }
    }
}
