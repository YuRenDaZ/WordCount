using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wordCount
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file = null,output = null;
            int a = 1, b = 10;
            for (int i = 0; i < args.Length; i += 2)
            {
                if (!(args.Length > i + 1))
                    break;
                if (args[i] == "-i")//-i参数配置使用
                    file = args[i + 1];
                else if (args[i] == "-n")//-n参数使用
                {
                    if (!int.TryParse(args[i + 1], out b))
                        b = 10;
                }
                else if (args[i] == "-o")//-o参数使用
                {
                    output = args[i + 1];
                }
                else if (args[i] == "-m")//-m参数使用
                {
                    if (!int.TryParse(args[i + 1], out a))
                        a = 1;
                }
            }
            string text;//读入
            if (PrintFile(file, out text))
            {
                Analyze(text, a,b, output);
            }
        }
        //读取文件
        public static bool PrintFile(string file, out string text)
        {
            try
            {
                text = System.IO.File.ReadAllText(file);
                return true;
            }
            catch (Exception e)
            {
                text = "";
                return false;
            }
        }
        //统计字符
        public static int Char(string text)
        {
            int a = 0;
            foreach (var chara in text)
            {
                if (chara < 128 && chara >= 0)
                    a++;
            }
            return a;
        }
        //统计行数
        public static int Line(string text)
        {
            bool a = true;
            int count = 0;
            foreach (var line in text)
            {
                if (line == '\n')
                {
                    if (!a)
                        count++;
                    a = true;
                }
                else
                    a = false;

            }
            return count;
        }
        //统计单词
        public static Dictionary<string, int> Word(string text, int splite = 1)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int b = 0;
            string c = "";
            bool isChecked = false;
            foreach (var item in text)
            {
                if (char.IsNumber(item))
                {
                    if (c.Length >= 4)
                    {
                        c += item;
                        isChecked = true;
                        continue;
                    }

                }
                else if (char.IsLetter(item))
                {
                    var letter = char.ToLower(item);
                    c += letter;
                    isChecked = true;
                    continue;
                }
                else if (c.Length == 0)
                    continue;

                if (isChecked)
                { isChecked = false; b++; }

                if (b <= splite)
                {
                    c += item;
                    continue;
                }
                b = 0;
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
                c = "";
            }
            return dic;
        }
        //输出格式的要求
        public static void Analyze(string text, int p = 1, int q = 10, string output = "output.txt")
        {
            var words = Word(text, p);
            var list = words.ToList();
            list.Sort((x, y) =>
            {
                if (x.Value == y.Value)
                    return x.Key.CompareTo(y.Key);
                return -x.Value.CompareTo(y.Value);
            });
            StreamWriter s = new StreamWriter(output);
            Console.SetOut(s);
            Console.WriteLine("characters: {0}", Char(text));
            Console.WriteLine("words: {0}", words.Count);
            Console.WriteLine("lines: {0}", Line(text));
            for (int i = 0; i < q; i++)
            {
                if (list.Count >= i + 1)
                Console.WriteLine("{0}: {1}", list[i].Key, list[i].Value);
            }
        }
    }
}