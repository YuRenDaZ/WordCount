using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace WordCount
{
    
    class Word : IComparable
    {
        
        public String wordName;
        public int wordCount;

        public Word(String wordName, int wordCount)
        {
            this.wordName = wordName;
            this.wordCount = wordCount;
        }

        //用于排序
        public int CompareTo(object obj)
        {
            Word word = (Word)obj;
            int result = word.wordCount.CompareTo(this.wordCount);
            if (result == 0)
            {
                return word.wordName.CompareTo(this.wordName);
            }
            return result;
        }
    }

    class WordCount
    {

        public static StringBuilder stringBuilder = new StringBuilder();   //用于存储控制台输出，输入到文件
        /**
         * 排序
         */
        public void Topn(Dictionary<String, int> dict, int topn)
        {
            ArrayList list = new ArrayList();   //用list进行排序
            foreach (KeyValuePair<String, int> kv in dict)
            {
                Word word = new Word(kv.Key, kv.Value);     //把内容封装在word类中存入list
                list.Add(word);
            }
            
            list.Sort();   //会调用word类中的比较器进行比较
            foreach (Word word in list)   //输出topn
            {
                topn--;
                if(topn < 0)
                {
                    return;
                }
                Console.WriteLine(word.wordName + " " + word.wordCount);
                stringBuilder.Append(word.wordName + " " + word.wordCount + "\n");  //用于拼接字符串便于输出到文本文件
            }

        }

        /**
         * 分析文本内容
         */
        public Dictionary<string, int> Analyze(string str, int wordGroup)
        {
            Dictionary<String, int> countChar = new Dictionary<String, int>();

            StringReader reader = new StringReader(str);

            String line;

            int sumCount = 0;     //统计单词个数
            while ((line = reader.ReadLine()) != null)
            {
                
                String[] l = line.Split(' ');
                String[] l2 = new string[l.Length - wordGroup];   //统计有词组之后的数组
                //用于将切分过的字符串进行组合，变成词组  然后存入另外一个数组中
                for(int i = 0; i < l.Length - wordGroup;i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for(int j = i;j < wordGroup+i;j++)
                    {
                        if(l[j].Equals(" "))
                        {
                            j--;
                            continue;
                        }
                        sb.Append(l[j] + " ");
                    }
                    l2[i] = sb.ToString();
                }
                sumCount = l2.Length;
                //统计的关键代码，若map中存在该单词则数量加1，反之存入map
                for (int i = 0; i < l2.Length; i++)
                {
                    if (countChar.ContainsKey(l2[i]))
                    {
                        int count = (int)countChar[l2[i]];
                        count++;
                        countChar[l2[i]] = count;
                    }
                    else
                    {
                        countChar.Add(l2[i], 1);

                    }
                }
            }
            Console.WriteLine("word：" + sumCount);
            stringBuilder.Append("word：" + sumCount + "\n"); 
            return countChar;
        }
        /**
         * 清洗文本
         */
        public string OpenFile(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            StringReader reader = new StringReader(File.ReadAllText(fileName));
            string line;
            int sum_char = 0;   //统计字符个数
            int sum_line = 0;   //统计行
            while ((line = reader.ReadLine()) != null)
            {
                sum_line++;  //循环多少次就有多少行
                for (int i = 0; i < line.Length; i++) 
                {
                    if (line[i] <= 'z')   //字符在‘z’以内就sum_char++
                    {
                        sum_char++;
                        if ('a' <= line[i])  //如果是a到z之间（即字符）就把字符串拼接起来
                            sb.Append(line[i]); 
                        else if('A' <= line[i] && 'Z'>= line[i]) //大写转小写
                        {
                            sb.Append((char)(line[i] + 32));
                        }
                        else   //不规则字符统一变成空格，以便于稍后统计个数根据空格进行切分
                        {
                            String str = sb.ToString();
                            if (str[str.Length - 1] == ' ')
                                continue;
                            sb.Append(" ");
                            
                        }
                    }
                }

            }
            Console.WriteLine("characters：" + sum_char);
            Console.WriteLine("lines：" + sum_line);
            stringBuilder.Append("characters：" + sum_char + "\n").Append("lines：" + sum_line + "\n");  //拼接输出的内容便于写入文件
            return sb.ToString();
        }

        /**
         * 输出内容到文件。
         */
        public void PrintToFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, stringBuilder.ToString());
        }

        public static void Main(String[] args)
        {
            WordCount wordCount = new WordCount();
            string str = null;
            Dictionary<string, int> dictionary = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-i")
                {
                    str = wordCount.OpenFile(args[i + 1]);
                }
            }
            if (str == null)
            {
                Console.WriteLine("未输入文本信息！");
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-m")
                {
                    dictionary = wordCount.Analyze(str, int.Parse(args[i + 1]));
                    foreach (KeyValuePair<string, int> kv in dictionary)
                    {
                        Console.WriteLine(kv.Key + "\t" + kv.Value);
                        WordCount.stringBuilder.Append(kv.Key + "\t" + kv.Value + "\n");
                    }
                }
                if (args[i] == "-n")
                {
                    if (dictionary == null)
                        dictionary = wordCount.Analyze(str, 1);
                    wordCount.Topn(dictionary, int.Parse(args[i + 1]));
                }
            }
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-o")
                {
                    wordCount.PrintToFile(args[i + 1]);
                }
            }
        }

    }

}
