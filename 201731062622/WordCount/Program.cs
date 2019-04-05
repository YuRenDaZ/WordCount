using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            int count = 0;
            //判断命令行是否带参数
            if (args.Length != 0)
            {
                //实现-i打开文件的功能
                  if (args[0] == "-i") AddFunction.function1(args[1]);
                  //实现命令行输出最多的n个词并且存入文件中
                  if (args[2] == "-n" && args[4] == "-o")
                    {
                        string strtemp = AddFunction.function3(args[1], int.Parse(args[3]));
                        AddFunction.function2(args[5], strtemp);
                    }
            }
                Console.Write("请输入文件路径：");
                path = Console.ReadLine();

                Console.Write("字符数：");
                Console.WriteLine(ImportFile.ImportMyFile(path).Replace("\r", "").Length);
                ImportFile.WriteFile("a.txt", "字符数：" + ImportFile.ImportMyFile(path).Replace("\r", "").Length);
                //统计单词总数
                List<string> words = new List<string>();
                words = SplitString.storestring(ImportFile.ImportMyFile(path).Replace("\r", ""), " ");
                Console.Write("单词数：");
                Console.WriteLine(words.Count);
                ImportFile.WriteFile("a.txt", "单词数：" + words.Count);
                //统计行数
                Console.Write("行数：");
                Console.WriteLine(ImportFile.FileLines(path));
                ImportFile.WriteFile("a.txt", "行数：" + ImportFile.FileLines(path));
                //统计单词出现次数
                Dictionary<string, int> worddic = new Dictionary<string, int>();
                Dictionary<string, int> sortword = new Dictionary<string, int>();
                Dictionary<string, int> temp = new Dictionary<string, int>();
                Dictionary<string, int> keysort = new Dictionary<string, int>();
                worddic = Count.CountWord(words);
                //排序
                sortword = Count.SortValue(worddic);

                foreach (KeyValuePair<string, int> a in sortword)
                {
                    Console.WriteLine(a.Key + ":" + a.Value);
                    temp.Add(a.Key, a.Value);

                    count++;
                    if (count == 10) break;
                }
                keysort = Count.SortKey(temp);
                foreach (KeyValuePair<string, int> a in keysort)
                {
                    ImportFile.WriteFile("a.txt", a.Key + ":" + a.Value);
                }
                Console.Read();
            }
        }
    }
