using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace ZUOYE
{
   public  class wordCount
    {
        //获取字符数
        public int getAsc(string path)
        {
            string text = File.ReadAllText(path);
            int num = 0;
            foreach(var i in text)
            {
                if (32 <= i && i <= 126)
                    num++;
            }
            return num;
        }
        //获取行数
        public int getwords_lines(string path)
        {
            int count = 0;                                
            StreamReader streamReader = new StreamReader(path);
            while (streamReader.Peek() != -1)
            {               
                string str = streamReader.ReadLine();
                count++;               
            }
            return count;
        }
        //获取单词总数和词频
        public void getWords(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("文件不存在！");
                return;
            }
            Hashtable ht = new Hashtable(StringComparer.OrdinalIgnoreCase);
            StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8);
            string line = sr.ReadLine();
            string[] wordArr = null;
            int num = 0;
            while (line.Length > 0)
            {
                MatchCollection mc = Regex.Matches(line, @"\b[a-z]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                foreach (Match m in mc)
                {
                    if (ht.ContainsKey(m.Value))
                    {
                        num = Convert.ToInt32(ht[m.Value]) + 1;
                        ht[m.Value] = num;
                    }
                    else
                    {
                        ht.Add(m.Value, 1);
                    }
                }
                line = sr.ReadLine();
                wordArr = line.Split(' ');
                foreach (string s in wordArr)
                {
                    if (s.Length == 0)
                        continue;
                    line = Regex.Replace(line, @"[\p{P}*]", "", RegexOptions.Compiled);
                    if (ht.ContainsKey(s))
                    {
                        num = Convert.ToInt32(ht[s]) + 1;
                        ht[s] = num;
                    }
                    else
                    {
                        ht.Add(s, 1);
                    }
                }
                line = sr.ReadLine();
            }
            ArrayList keysList = new ArrayList(ht.Keys);
            keysList.Sort();           
            string tmp = String.Empty;
            int valueTmp = 0;
            for (int i = 1; i < keysList.Count; i++)

            {
                tmp = keysList[i].ToString();
                valueTmp = (int)ht[keysList[i]];
                int j = i;
                while (j > 0 && valueTmp > (int)ht[keysList[j - 1]])
                {
                    keysList[j] = keysList[j - 1];
                    j--;
                }
                keysList[j] = tmp;
            }
            Console.WriteLine("words：{0}",keysList.Count);
            foreach (object item in keysList)
            {              
                Console.WriteLine(item.ToString() + ":" + ht[item].ToString());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {           
            wordCount wc = new wordCount();
            //string path = Console.ReadLine();
            string path = @"C:\Users\FANGUILIN\Desktop\第三次作业\单词.txt";
            Console.WriteLine("characters：{0}", wc.getAsc(path));            
            Console.WriteLine("lines：{0}", wc.getwords_lines(path));
            wc.getWords(path);
            Console.ReadLine();
        }
    }
}
