using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    public  class Class1:Interface1 
    {
        public string str,temp;
        public int n=0,i=0,m=0,j=0;//n为行数，i为字符数,m为单词数

        int Interface1.Getch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Interface1.Getasc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int Interface1.Getword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Dictionary<string, int> Interface1.Countword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public  int Getch(string str)//得到行数
        {
            for (int count = 0; count < str.Length; count++)
            {
                if (str[count] == '\n')
                    n++;
               // if()
            }
            return n;
        }
        public int Getasc(string str)//得到字符数
        {
            for (int count = 0; count < str.Length; count++)
            {
                if (str[count]>=0&&str[count]<=127)
                    i++;
            }
            return i;
        }
        public int Getword(string str)//得到单词数
        {
            for (int count = 0; count < str.Length; count++)
            {
                if ((str[count] >= 65 && str[count] <= 90) || (str[count] >= 97 && str[count] <= 122))
                {
                    j++;
                    if (j == 4)
                        m++;
                }
                else
                    j = 0;
            }
            return m;
        }
        public Dictionary<string, int> Countword(string str, int n)//排序
        {
            Dictionary<string, int> f;
            f = new Dictionary<string, int>();
            string[] words = Regex.Split(str, @"\W+");
            foreach (string word in words)//计算每个单词的频率
            {
                if (f.ContainsKey(word))
                {
                    f[word]++;
                }
                else
                {
                    f[word] = 1;
                }
            }
            f = f.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);
            FileStream fs = new FileStream(@"F:\word.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0, k = 0; i < f.Count; i++)
            {
                KeyValuePair<string, int> j = f.ElementAt(i);
                if (j.Key.Length >= 4)
                {
                    Console.WriteLine("{0}..........{1}", j.Key, j.Value);
                    sw.WriteLine("{0}..........{1}", j.Key, j.Value);//写入文件
                    k++;
                    if (k == n)
                        break;
                }
            }
            sw.Flush();   //清空缓冲区
            sw.Close();  //关闭流
            fs.Close();
            return f;
        }
    }
}
