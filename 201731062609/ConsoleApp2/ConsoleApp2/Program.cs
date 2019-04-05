using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WordCount
{

    public class Program
    {
        public static Hashtable ht = new Hashtable(1000000);//建立哈希表用来储存单词数

        public static Hashtable WordCount(string path, Hashtable ht)//统计单词的次数并对其进行排序
        {
            StreamReader txt = new StreamReader(path);
            string[] words = null;
            string line;
            char[] seperators = new char[] { ' ', ',', ';', '.', '!', '"' };
            while ((line = txt.ReadLine()) != null)
            {
                line = line.ToLower();
                line = Regex.Replace(line, @"[\p{P}*]", "", RegexOptions.Compiled);
                words = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                if (words != null && words.Length > 4)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (ht.ContainsKey(words[i]))
                        {
                            ht[words[i]] = (int)ht[words[i]] + 1;
                        }
                        else
                        {
                            ht.Add(words[i], 1);
                        }
                    }
                }

            }
            return ht;
        }
        public static ArrayList oreder(Hashtable ht)
        {
            ArrayList akeys = new ArrayList(ht.Keys);
            akeys.Sort(); //按字母顺序进行排序

            string temp = String.Empty;
            int valuetemp = 0;
            for (int i = 1; i < ht.Count; i++)
            {
                temp = akeys[i].ToString();
                valuetemp = (int)ht[akeys[i]];//次数
　　              int j = i;
                while (j > 0 && valuetemp > (int)ht[akeys[j - 1]])
                {
                    akeys[j] = akeys[j - 1];
                    j--;
                }
                akeys[j] = temp;//j=0
            }
            return akeys;
        }
        public static int letterCount(string path)//统计字符数
        {
            StreamReader txt = new StreamReader(path);
            string line;
            int letcount = 0;

            while ((line = txt.ReadLine()) != null)
            {
                char[] ch = line.ToCharArray();
                for (int i = 0; i < line.Length; i++)
                    letcount++;
            }
            txt.Close();
            return letcount;

        }


        public static int LineCount(string path)//统计行数
        {
            StreamReader txt = new StreamReader(path);
            int i = 0;
            string line;

            while ((line = txt.ReadLine()) != null)
            {
                if (line.Length == 0) continue;//判断是否为空行
                i++;
            }
            return i;
        }
        public static void outPut(string path, Hashtable ht, string outpath, int n, int line, int letcount, ArrayList akeys) //输出到文件
        {
            StreamReader txt = new StreamReader(path);
            StreamWriter sw = new StreamWriter(outpath, true, Encoding.Default);
            int i = 0;
            sw.WriteLine("Characters : {0}", letcount);
            Console.WriteLine("Characters : {0}", letcount);//输出字符数量
            sw.WriteLine("Words : {0}", akeys.Count);
            Console.WriteLine("Words : {0}", akeys.Count);//输出单词数
            sw.WriteLine("Lines : {0}", line);
            Console.WriteLine("lines : {0}", line);//输出有效行数
            foreach (object ll in akeys)//输出频数前n的单词及频数
            {
                sw.WriteLine("{0}:{1}", ll, ht[ll].ToString());
                Console.WriteLine("{0}:{1}", ll, ht[ll].ToString());
                i++;
                if (i >= n) break;
            }
            sw.Close();
        }
        public static void Main(string[] args)

        {
            Test();
        }
        public static void Test()
        {
            string path = @"E:\作业三1\WordCount\txt.txt";

            StreamReader txt = new StreamReader(path);//读取文件内容

            ArrayList AKEYS = new ArrayList(ht.Keys);

            string outpath = @"E:\作业三1\WordCount\txt1.txt";
            int line, letcount, n;
            Console.WriteLine("列出前n个频数的单词");
            n = int.Parse(Console.ReadLine().ToString());

            line = LineCount(path);
            letcount = letterCount(path);
            ht = WordCount(path, ht);
            AKEYS = oreder(ht);
            outPut(path, ht, outpath, n, line, letcount, AKEYS);
            txt.Close();
            Console.WriteLine(ht[0]);
            Console.ReadKey();
        }
    }
}

