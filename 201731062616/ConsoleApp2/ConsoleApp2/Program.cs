using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsoleApp52
{
    class zifu//统计字符数
    {
        public void A(string path)
        {
            int charcount = 0;
            int nchar;
            StreamReader sr = new StreamReader(path);
            char[] symbol = { ' ', '\t', ',', '.', '?', '!', ':', ';', '\'', '\"', '\n', '{', '}', '(', ')', '+' ,'-',
             '*', '='};
            while ((nchar = sr.Read()) != -1)
            {
                charcount++;
            }
            Console.WriteLine("characters :{0}", charcount);

        }

    }
    class word//统计字母数大于4的单词
    {
        int wordcount = 0;
        public void B(string path)
        {
            string pattren = @"\s+|,\s*";
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadToEnd();
            Regex myregex = new Regex(pattren);
            string[] output = myregex.Split(line);
            foreach (string s in output)
            {
                if (s.Length > 3)
                    wordcount++;
            }
            Console.WriteLine("words :{0}", wordcount);

        }

    }
    class line//统计行数
    {

        public void C(string path)
        {
            int linecount = 0;
            string nchar;
            StreamReader sr = new StreamReader(path);
            while ((nchar = sr.ReadLine()) != null)
            {

                linecount++;

            }
            Console.WriteLine("line :{0}", linecount);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\git\WordCount\201731062616\ConsoleApp2\ConsoleApp2\bin\Debug\第三次作业.txt";
            List<string> listnew = new List<string>();//所有单词放在listnew中
            string pattren = @"\s+|,\s*";
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadToEnd();
            Regex myregex = new Regex(pattren);
            string[] output = myregex.Split(line);
            foreach (string s in output)
            {
                if (s.Length > 3)
                    listnew.Add(s);
            }

            zifu a = new zifu();
            word b = new word();
            line c = new line();
            a.A(path);
            b.B(path);
            c.C(path);

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (var word in listnew)
            {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                }
                else
                {
                    keyValuePairs.Add(word, 1);
                }
            }
            List<int> value = new List<int>();
            foreach (var s in keyValuePairs.Values)
            {
                value.Add(s);
            }
            value.Sort((x, y) => -x.CompareTo(y));
            int count = 0;
            // Console.Write("频率：" + value[0] + " ");
            foreach (var s in keyValuePairs)
            {
                if (s.Value.Equals(value[0]))
                {
                    Console.WriteLine(s.Key + ":" + value[0]);
                    count++;
                }
            }

            for (int i = 1; i < value.Count; i++)
            {
                if (count != 10)
                {
                    if (value[i] == value[i - 1])
                        continue;
                    foreach (var s in keyValuePairs)
                    {
                        if (s.Value.Equals(value[i]))
                        {
                            if (count != 10)
                            {
                                Console.WriteLine(s.Key + ":" + value[i]);
                                count++;
                            }
                            else
                                break;
                        }
                    }
                }
                else
                    break;

            }




        }
    }
}