using System;
using System.Collections.Generic;//dictionary
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
namespace count
{
    class path
    {
        public static string s;
    }


    class linescount   //统计行数
    {
        public static int counts()
        {
            string str = File.ReadAllText(@path.s);
            int lc = Regex.Matches(str, @"\r").Count+1;
            return lc;
        }
    }


    class asccount
    {
        public static int acounts()
        {
            string str = File.ReadAllText(@path.s);
            int num = Regex.Matches(str, @".").Count;
            return num + linescount.counts() - 1;
        }
    }


    class Change  //统计单词数
    {
        public static string[] change(string[] words,ref int m)
        {
            int k = 0;
            char[] neword = new char[words.Length];
            string[] newords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                char[] words1 = words[i].ToCharArray();
                for (int j = 0; j < words1.Length; j++)
                {
                    if (words1[j] >= 'A' && words1[j] <= 'Z')
                    {
                        words1[j] = Convert.ToChar((Convert.ToInt32(words1[j])) + 32);
                    }
                }
                if (words1.Length >= 4)
                {
                    if ((words1[0] >= 'a' && words1[0] <= 'z') && (words1[1] >= 'a' && words1[1] <= 'z') && (words1[2] >= 'a' && words1[2] <= 'z') && (words1[3] >= 'a' && words1[3] <= 'z'))
                    {
                        neword = words1;
                        string s = String.Join("", neword);
                        newords[k] = s;
                        k++;
                    }
                }
            }
            m = k;
            return newords;
        }
    }
    class wordcount  //统计单词数
    {
        public static Dictionary<string, int> Wcounts()
        {
            string str = File.ReadAllText(@path.s);
            Dictionary<string, int> te = new Dictionary<string, int>();  
            string[] words = Regex.Split(str, @"\W+");
            int k = 0;
            string []newords = Change.change(words,ref k);
            Console.WriteLine("单词总数:" + k);
            string[] newwords1 = new string[k];
            for (int i = 0; i < k; i++)
            {
                newwords1[i] = newords[i];
            }

            foreach (string word in newwords1)
            {

                if (te.ContainsKey(word))
                {
                    te[word]++;
                }
                else
                {
                    te[word] = 1;
                }
            }
            return te;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入文件路径");
            string s = Console.ReadLine();
            path.s = s;//路径
            int temp = 0;
            Console.WriteLine("行数:" + linescount.counts());//计算行数
            Console.WriteLine("字符数:" + asccount.acounts());//计算字符数
            Dictionary<string, int> te2 = wordcount.Wcounts();//调用
            Dictionary<string, int> dic1Asc1 = te2.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            foreach (KeyValuePair<string, int> entry in dic1Asc1 )
            {
                if (temp == 10)
                    break;
                string word = entry.Key;
                int frequency = entry.Value;
                temp++;
                Console.WriteLine("{0}:{1}", word, frequency);
            }
            Console.ReadKey();
        }
    }
}