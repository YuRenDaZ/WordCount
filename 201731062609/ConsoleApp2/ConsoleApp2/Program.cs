using System;using System.Collections.Generic;using System.Collections;using System.Linq;using System.Text;using System.IO;using System.Threading.Tasks;using System.Text.RegularExpressions;namespace WordCount{    interface ICore
    {
        Hashtable WordCount(string paht,Hashtable ht);
        int WordCount1(string path, Hashtable ht);
        ArrayList oreder(Hashtable ht);
        int letterCount(string path);
        void outPut(string path, Hashtable ht, string outpath, int n, int line, int letcount, ArrayList akeys, int wordcount);
    }    public class Program:ICore    {        public static Hashtable ht = new Hashtable(1000000);//建立哈希表用来储存单词数
        public static Hashtable tmep = new Hashtable();//用于计算总单词
        public  Hashtable WordCount(string path, Hashtable ht)//统计单词的次数并对其进行排序
        {            StreamReader txt = new StreamReader(path);            string[] words = null;            string line;            char[] seperators = new char[] { ' ', ',', ';', '.', '!', '"' };            while ((line = txt.ReadLine()) != null)            {                line = line.ToLower();                line = Regex.Replace(line, @"[\p{P}*]", "", RegexOptions.Compiled);                words = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);                if (words != null && words.Length > 4)                {                    for (int i = 0; i < words.Length; i++)                    {                        if (ht.ContainsKey(words[i]))                        {                            ht[words[i]] = (int)ht[words[i]] + 1;                        }                        else                        {                            ht.Add(words[i], 1);                        }                    }                }            }            return ht;        }        public  int WordCount1(string path, Hashtable ht)//统计单词总数
        {            StreamReader txt = new StreamReader(path);            string[] words = null;            int wordcount1 = 0;            string line;            char[] seperators = new char[] { ' ', ',', ';', '.', '!', '"' };            while ((line = txt.ReadLine()) != null)            {                line = line.ToLower();                line = Regex.Replace(line, @"[\p{P}*]", "", RegexOptions.Compiled);                words = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);                if (words != null && words.Length > 4)                {                    for (int i = 0; i < words.Length; i++)                    {                        wordcount1++;                    }                }            }            return wordcount1;        }        public  ArrayList oreder(Hashtable ht)        {            ArrayList akeys = new ArrayList(ht.Keys);            akeys.Sort(); //按字母顺序进行排序

            string temp = String.Empty;            int valuetemp = 0;            for (int i = 1; i < ht.Count; i++)            {                temp = akeys[i].ToString();                valuetemp = (int)ht[akeys[i]];//次数
                int j = i;                while (j > 0 && valuetemp > (int)ht[akeys[j - 1]])                {                    akeys[j] = akeys[j - 1];                    j--;                }                akeys[j] = temp;//j=0
            }            return akeys;        }        public  int letterCount(string path)//统计字符数
        {            StreamReader txt = new StreamReader(path);            string line;            int letcount = 0;            while ((line = txt.ReadLine()) != null)            {                char[] ch = line.ToCharArray();                for (int i = 0; i < line.Length; i++)                    letcount++;            }            txt.Close();            return letcount;        }        public  int LineCount(string path)//统计行数
        {            StreamReader txt = new StreamReader(path);            int i = 0;            string line;            while ((line = txt.ReadLine()) != null)            {                if (line.Length == 0) continue;//判断是否为空行
                i++;            }            return i;        }        public  void outPut(string path, Hashtable ht, string outpath, int n, int line, int letcount, ArrayList akeys, int wordcount) //输出到文件
        {            StreamReader txt = new StreamReader(path);            StreamWriter sw = new StreamWriter(outpath, true, Encoding.Default);            int i = 0;            sw.WriteLine("Characters : {0}", letcount);            Console.WriteLine("Characters : {0}", letcount);//输出字符数量
            sw.WriteLine("Words : {0}", wordcount);            Console.WriteLine("Words : {0}", wordcount);//输出单词数
            sw.WriteLine("Lines : {0}", line);            Console.WriteLine("lines : {0}", line);//输出有效行数
            foreach (object ll in akeys)//输出频数前n的单词及频数
            {                sw.WriteLine("{0}:{1}", ll, ht[ll].ToString());                Console.WriteLine("{0}:{1}", ll, ht[ll].ToString());                i++;                if (i >= n) break;            }            sw.Close();        }        public static void Main(string[] args)        {            Program pro = new Program();            pro.Test();        }        public  void Test()        {            string path = @"E:\Text\txt.txt";            StreamReader txt = new StreamReader(path);//读取文件内容

            ArrayList AKEYS = new ArrayList(ht.Keys);            string outpath = @"E:\Text\txt1.txt";            int line, letcount, n;            int wordcount = 0;            Console.WriteLine("列出前n个频数的单词");            n = int.Parse(Console.ReadLine().ToString());            line = LineCount(path);//行数统计
            letcount = letterCount(path);//字符数统计
            ht = WordCount(path, ht);//单词频数统计
            wordcount = WordCount1(path, tmep);//单词总数统计
            AKEYS = oreder(ht);//单词频数降序排列
            outPut(path, ht, outpath, n, line, letcount, AKEYS, wordcount);//输出至文本内
            txt.Close();            Console.WriteLine(ht[0]);            Console.ReadKey();        }    }}

