using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\cyh\Desktop\chenyuhangbaba\quote.txt
            Console.Write("Please enter the document path:");
            string testword = Console.ReadLine();
            READ W = new READ();
            int lines = W.lines(testword);
            int characters = W.characters(testword);
            int word = W.word(testword);
            Console.WriteLine("lines = " + lines);
            Console.WriteLine("characters = " + characters);
            Console.WriteLine("word = " + word);
            W.most(testword);
        }
    }
    class READ
    {
        public string[] B = new string[1000];
        public int lines(String testword)
        {
            Stopwatch sw = new Stopwatch();
            var path = testword;
            int i = 0;
            //按行读取
            sw.Restart();
            using (var sr = new StreamReader(path))
            {
                var ls = "";
                while ((ls = sr.ReadLine()) != null)
                {
                    i++;
                }
            }
            sw.Stop();
            return i;
        }
        public int characters(string testword)//读取字符数
        {
            int i = 0;
            StreamReader sr = new StreamReader(testword);
            while (!sr.EndOfStream)
            {
                int z = sr.Read();
                if (z >= 32 && z <= 126 || z == 10)
                    i++;
            }
            sr.Close();
            return i;
        }
        public int word(string testword)
        {
            int i = 0, j = 1;
            string[] A = new string[20];
            StreamReader sr = new StreamReader(testword);
            while (!sr.EndOfStream)
            {
                int z = sr.Read();
                if ((z >= 65 && z <= 90) || (z >= 96 && z <= 122))
                {
                    i++;
                    A[i] = ((char)z).ToString();
                }
                else if (z < 65 || z > 122)
                {
                    if (i >= 4)
                    {
                        B[j] = String.Join("", A);
                        j++;
                    }
                    i = 0;
                }
            }
            return j;
        }
        public void most(string testword)
        {
            string fn = testword;
            string all = File.ReadAllText(fn, Encoding.UTF8);
            string[] words = all.Split(new char[] { ' ', '\r', '\n', '?', ',', '.', '"', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var kv in words.GroupBy(x => x).OrderBy(x => x.Key))
            {
                Console.WriteLine("{0}\t\t{1}", kv.Key, kv.Count());
            }
        }
    }
}
