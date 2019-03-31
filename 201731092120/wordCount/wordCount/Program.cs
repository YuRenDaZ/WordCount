﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\SoftWork\WordCount\201731092120\wordCount\hamlet.txt";
            string text = ReadFile(path).ToLower();
            Console.Write("characters:");
            Console.Write(CountChars(text));
            Console.Write("\n");

            Console.Write("lines:");
            Console.Write(CountLines(path));
            Console.Write("\n");

            Console.Write("words:");
            Console.Write(CountWords(path));
            Console.Write("\n");

            CoutWords(text);

            Console.ReadKey();
        }

        public static string ReadFile(string path)
        {
            string text = "";
            try
            {
                FileStream aFile = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                text = sr.ReadToEnd();
                sr.Close();
                return text;
            }

            catch (IOException ex)
            {
                Console.WriteLine("文件操作异常");
                Console.WriteLine(ex.ToString()); //输出异常原因
                return text;
            }
            
        }

        public static int CountChars(string text)
        {
            int count = 0;
            foreach (var item in text)
            {
                if (item < 128 && item >= 0)
                    count++;
            }
            return count;
        }

        public static int CountLines(string path)
        {
            FileStream aFile = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            int lines = 0;
            var ls = "";
            while ((ls = sr.ReadLine()) != null)
            {
                lines++;
            }
            sr.Close();
            return lines;
        }

        public static int CountWords(string path)
        {

            string Text = ReadFile(path);
            string text = Text.ToLower();
            int length = 0;

            foreach (char a in "[\']#$%&()*+,-./:;<=>?@[\\]^_{|}~".ToCharArray())
            {
                text = text.Replace(a.ToString(), "");
            }
            string[] texts = text.Split(' ');
            foreach(var word in texts)
            {
                foreach(var w in word)
                {
                    if(w>=97&&w<=122)
                    {
                        break;
                    }
                   
                }
                if (word.Length >= 4)
                    length++;

            }
            return length;

        }

        static Dictionary<string, int> CoutWords(string text)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }
         
            foreach (KeyValuePair<string, int> entry in frequencies)
            {
                
                string word = entry.Key;
                int frequency = entry.Value;
                
            }


            //对值进行排序
            
            Dictionary<string, int> dicDesc = frequencies.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);

                foreach (KeyValuePair<string, int> k in dicDesc.Take(10))
                {

                    Console.WriteLine(k.Key + ":" + k.Value);
                }

            return frequencies;

        }


    }
}
