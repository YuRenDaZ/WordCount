using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace wordCount
{
    public interface library
    {
        string ReadFile(string path);   //用于打开文件
        int CountChars(string text);    //用于统计文档中的字符个数
        int CountLines(string text);    //用于统计文档行数
        int CountWords(string Text);    //用于统计文档中单词的个数
        Dictionary<string, int> Countphrase(string text, int n);    //用于统计文档中的短语的频率
        Dictionary<string, int> CoutWords(string text, int n);      //用于统计文档中的单词的频率
        void WreteFile(string path);    //用于创建一个文件，将统计结果保存在文件中

    }

    public  class Program
    {
        
        public static void Main(string[] args)
        {
            Statistics statistics = new Statistics();
            string text = "";
            string path = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-i")
                {
                    path = args[i + 1];
                    text = statistics.ReadFile(path).ToLower();
                }
            }
            if (text == "")
            {
                Console.WriteLine("未输入文本信息！");
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-m")
                {
                    statistics.Countphrase(text, int.Parse(args[i + 1]));
                }
                if (args[i] == "-n")
                {
                    statistics.CoutWords(text, int.Parse(args[i + 1]));
                }
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-o")
                {
                    statistics.WreteFile(args[i + 1]);
                }
            }
        }
    }
    public class Statistics : library
    {
        public  StringBuilder sb = new StringBuilder();   //用于存储控制台输出，输入到文件
        public string ReadFile(string path)
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

        public int CountChars(string text)
        {
            int count = 0;
            foreach (var item in text)
            {
                if (item < 128 && item >= 0)
                    count++;
            }
            return count;
        }

        public int CountLines(string text)
        {
            int lines = 0;
            bool flg = true;
            foreach (var item in text)
            {
                if (item == '\n')
                {
                    if (!flg)
                        lines++;
                    flg = true;
                }
                else
                    flg = false;

            }
            return lines;
        }

        public  int CountWords(string Text)
        {

            string text = Text.ToLower();
            int length = 0;

            foreach (char a in "[\']#$%&()*+,-./:;<=>?@[\\]^_{|}~".ToCharArray())
            {
                text = text.Replace(a.ToString(), "");
            }
            string[] texts = text.Split(' ');
            foreach (var word in texts)
            {
                foreach (var w in word)
                {
                    if (w >= 97 && w <= 122)
                    {
                        break;
                    }

                }

                if (word.Length >= 4)
                    length++;
            }
            return length;

        }

        //统计词组长度
        public Dictionary<string, int> Countphrase(string text, int n)
        {
            int sumCount = 0;     //统计单词个数
            Console.WriteLine("characters:{0}", CountChars(text));
            sb.Append(CountChars(text));
            Console.WriteLine("words: {0}", CountWords(text));
            sb.Append(CountWords(text));
            Console.WriteLine("lines:{0}", CountLines(text));
            sb.Append(CountLines(text));
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(text.ToLower(), @"\W+");

            //统计有词组之后的数组
            String[] phrase = new string[words.Length - n];

            //用于将切分过的字符串进行组合，变成词组  然后存入另外一个数组中                                                 
            for (int i = 0; i < words.Length - n; i++)
            {
                StringBuilder ph = new StringBuilder();
                for (int j = i; j < n + i; j++)
                {
                    if (words[j].Equals(" "))
                    {
                        j--;
                        continue;
                    }
                    ph.Append(words[j] + " ");
                }
                phrase[i] = ph.ToString();
            }

            sumCount = phrase.Length;
            //统计的关键代码，若map中存在该单词则数量加1，反之存入map
            for (int i = 0; i < phrase.Length; i++)
            {
                if (frequencies.ContainsKey(phrase[i]))
                {
                    int count = (int)frequencies[phrase[i]];
                    count++;
                    frequencies[phrase[i]] = count;
                }
                else
                {
                    frequencies.Add(phrase[i], 1);
                }
            }
            foreach (KeyValuePair<string, int> k in frequencies)
            {

                Console.WriteLine(k.Key + ":" + k.Value);
                sb.Append(k.Key + ":" + k.Value);
                sb.Append("\n");
            }
            return frequencies;
        }
            
        public Dictionary<string, int> CoutWords(string text, int n)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            string[] words = Regex.Split(text.ToLower(), @"\W+");

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

            foreach (KeyValuePair<string, int> k in dicDesc.Take(n))
            {

                Console.WriteLine(k.Key + ":" + k.Value);
                sb.Append(k.Key + ":" + k.Value);
                sb.Append("\n");
            }
            return frequencies;
        }

        //创建一个.txt文件,并将统计信息输入文件中

        public  void WreteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            try
            {
                StreamWriter sw = new StreamWriter(path, true);

                sw.WriteLine(sb.ToString());
                sw.WriteLine("\n");
                sw.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("文件操作异常");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return;
            }
        }
    }
}
