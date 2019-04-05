using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace wordCount
{
    //这是一个统计项目

    class Program
    {
        //统计文件有效行数
        public void counthang(string path)
        {
            int count = 0;
            StreamReader sr = new StreamReader(path, Encoding.ASCII);
            string line;
            while((line=sr.ReadLine())!=null)
            {
                count++;
            }
            Console.WriteLine("有效行数：" + count);
        }
        //统计字符
        public void count1(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.ASCII);
            string line = sr.ReadToEnd();
            char[] x = line.ToCharArray();
            Console.WriteLine("字符数:"+x.Length);
        }
        //统计单词数
        public void count2(string path)
        {
            int sum = 0;
            StreamReader sr = new StreamReader(path, Encoding.ASCII);
            string line = sr.ReadToEnd();
            //匹配正值表达式 逗号，点号，空格，换行符，回车符，问号，,分号，，冒号，感叹号，，左括号，又括号，双引号，左双引号，右双引号，中文字符,数字
            string Pattern = @"\,|\.|\ |\n|\r|\?|\;|\:|\!|\(|\)|\042|\“|\”|\-|[\u4e00-\u9fa5]|[0-9]";
            //Regex类通过正值表达式可以吧字符串分割成字符串数组，通过正值表达式分割
            Regex zz = new Regex(Pattern);
            //split方法把字符串分成字符数组
            string[] words = zz.Split(line);
            for(int i=0;i<words.Length;i++)
            {
                if(words[i].Length>=4)
                {
                    sum++;

                }
            }
            Console.WriteLine("单词数：" + sum);
         

        }
        //统计单词中的频率最高的10个单词,
        //扩展功能:能统计文件夹中指定长度的词组的词频,能输出用户指定的前n多的单词与其数量
        public void count3(string path)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<string> m = new List<string>();
            List<string> word = new List<string>();
            StreamReader sr = new StreamReader(path, Encoding.ASCII);
              
            string line = sr.ReadToEnd();
            string Pattern = @"\,|\.|\ |\n|\r|\?|\;|\:|\!|\(|\)|\042|\“|\”|\-|[\u4e00-\u9fa5]|[0-9]";
            Regex zz = new Regex(Pattern);
            string[] words = zz.Split(line);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= 4)
                {
                    word.Add(words[i].ToLower());

                }
            }
            HashSet<string> b = new HashSet<string>(word);
            foreach (string B in b)
            {
                m.Add(B);
            }
            for(int i=0;i<m.Count;i++)
            {
                int sum = 0;
                for(int j=0;j<word.Count;j++)
                {
                    if(m[i].ToUpper()==word[j].ToUpper())
                    {
                        sum++;

                    }
                }
                dic.Add(m[i],sum);
            }
            Dictionary<string, int> dicdesc = dic.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            int sum1 = 0;
            foreach(KeyValuePair<string,int> k in dicdesc)
            {

                if (sum1 <= 10)
                {
                    Console.WriteLine("单词:" + k.Key + "单词数:" + k.Value);
                    sum1++;
                }
                else
                    break;
                
               
            }
            Console.WriteLine("统计文件夹中指定长度的词组:");
            int n1 =int.Parse( Console.ReadLine());
            foreach(KeyValuePair<string,int> h in dic)
            {
                if(n1==h.Key.Length)
                {
                    Console.WriteLine("单词： " + h.Key + "单词数:" + h.Value);
                }
            }

            Console.WriteLine("输出用户指定的前n多的单词与其数量:");
            int n = int.Parse(Console.ReadLine());
            int sum2 = 0;
            foreach (KeyValuePair<string, int> k in dicdesc)
            {

                if (sum2 <= n)
                {
                    Console.WriteLine("单词:" + k.Key + "单词数:" + k.Value);
                    sum2++;
                }
                else
                    break;


            }

        }
        //对单词进行排序
        public void count4(string path)
        {
            string path3 = @"F:\博客作业3\WordCount\201731062615\测试文本\file3.txt";
            StreamWriter s = new StreamWriter(path3);
            List<string> word = new List<string>();
            List<string> m = new List<string>();
            StreamReader sr = new StreamReader(path, Encoding.ASCII);
            string line = sr.ReadToEnd();
            string Pattern = @"\,|\.|\ |\n|\r|\?|\;|\:|\!|\(|\)|\042|\“|\”|\-|[\u4e00-\u9fa5]|[0-9]";
            Regex zz = new Regex(Pattern);
            string[] words = zz.Split(line);
            for(int i=0;i<words.Length;i++)
            {
                if (words[i].Length >= 4)
                {
                    word.Add(words[i]);
  
                }

            }
            word.Sort();
            /* for(int i=0;i<word.Count;i++)
             {
                 s.WriteLine(word[i].ToLower());
             }*/
            HashSet<string> c = new HashSet<string>(word);
            foreach(string C in c)
            {
                s.WriteLine(C.ToLower());
            }
            s.Close();
        }
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string path1 =@path;
            if(!File.Exists(path1))
            {
                Console.WriteLine("文件不存在！");
                return;
            }
            Program one = new Program();
            one.count1(path1);
            one.counthang(path1);
            one.count2(path1);
            one.count3(path1);
            one.count4(path1);
            Console.ReadKey();

        }
    }
}