using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace wordCount
{ 
    public class Fileread
    {
        public int Countwords(string str, List<string> test)
        {
            MatchCollection rel = Regex.Matches(str, "[a-zA-Z]*");
            for (int i = 0; i < rel.Count; i++)
            {
                test.Add(Convert.ToString(rel[i]));
            }
            for (int i = 0; i < test.Count; i++)
            {
                if (test[i] == "")
                {
                    test.Remove(test[i]);
                }
            }
            Console.WriteLine("\nchars:\t{0}", rel.Count);//统计文件的字符总数
            return rel.Count;
        }
        public int Countlines(string str)
        {
            int n = 1;
            MatchCollection strline = Regex.Matches(str, "\n");
            for (int i = 0; i < strline.Count; i++)
            {
                n++;
            }
            Console.WriteLine("lines:\t{0}", n);//统计文件的有效行数
            return n;
        }
        public int Counttimes(string str, List<string> test)
        {
            int j = 1;
            Dictionary<string, int> hot = new Dictionary<string, int>();
            for (int i = 0; i < test.Count; i++)
            {
                if (hot.ContainsKey(test[i]))
                {
                    hot[test[i]]++;
                }
                else
                {
                    hot[test[i]] = 1;
                }
            }
            Dictionary<string, int> hot_sort = hot.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, o => o.Value); ;
            Console.WriteLine("words:\t{0}", test.Count);//统计单词数
            foreach (KeyValuePair<string, int> kvp in hot_sort)
            {
                if (kvp.Key == "")
                {
                    Console.WriteLine("空格数：\t{0}", kvp.Value);
                }
                else
                {
                    Console.WriteLine("单词为：{0}\t次数为：{1}", kvp.Key, kvp.Value);//统计文件中各单词的出现次数
                }
                j++;
                if (j == 12)
                {
                    break;
                }
            }
            return 0;
        }
        public void Output()
        {
            StreamWriter f = new StreamWriter(@"D:\output.txt", true);//输出到文件txt
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("请输入文件路径：");
            string INfile = Console.ReadLine();
            FileInfo file = new FileInfo(@INfile);
            StreamReader sw = file.OpenText();
            List<string> test = new List<string>();
            string str = sw.ReadToEnd();
            sw.Close();
            Fileread t = new Fileread();
            t.Countwords(str, test);
            t.Countlines(str);
            t.Counttimes(str, test);
            t.Output();
            Console.ReadKey();
        }
    }
}