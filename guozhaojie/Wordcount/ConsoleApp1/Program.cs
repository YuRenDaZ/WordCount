using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = args[0];//从cmd中读取文档路径
            Program a = new Program();
            Library b = new Library();
            if (System.IO.File.Exists(filepath))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                char[] filedata = file.ReadToEnd().ToCharArray();//将文档中的所有字符储存在字符数组中
                file.Close();
                file.Dispose();
                //调用Library类中的函数计算需要得到的各个属性
                string c = b.countchar(filedata);
                string w = "words:" + b.countword(filedata).ToString();
                Console.WriteLine("words:{0}", b.countword(filedata));
                string l = b.countline(filedata);
                string f = b.countfre(filedata);
                //调用保存数据的函数将结果保存在文档中
                a.savedata(c, w, l, f, "Wordcount");
                Console.WriteLine("以上数据已保存在文档目录下Save文件夹中的Wordcount文档中!");
            }
            else Console.WriteLine("读取失败！该文件不存在");
            Console.ReadKey();
        }

        void savedata(string c, string w, string l, string f, string name)
        {
            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory + @"Save\";
            if (!System.IO.Directory.Exists(CurDir)) System.IO.Directory.CreateDirectory(CurDir);
            String filePath = CurDir + name + ".txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false);
            file.WriteLine(c);
            file.WriteLine(w);
            file.WriteLine(l);
            file.WriteLine(f);
            file.Close();
            file.Dispose();
        }
    }
    public class Library
    {
        public string countchar(char[] filedata)//计算文档中的字符总数
        {
            string countchar = "characters:" + filedata.Length;
            Console.WriteLine(countchar);
            return countchar;
        }

        public int countword(char[] filedata)//计算文档中的单词总数
        {
            int count = 0, letter = 0;
            for (int n = 0; n < filedata.Length; n++)
            {
                if ((filedata[n] >= 65 && filedata[n] <= 90) || (filedata[n] >= 97 && filedata[n] <= 122))
                    letter++;
                else if (filedata[n] == 32)
                {
                    if (letter >= 4)//满足“连续4个字母”才能被计为一个单词
                    {
                        count++;
                        letter = 0;
                    }
                    else letter = 0;
                }
                else letter = 0;
            }
            return count;
        }

        public string countline(char[] filedata)//计算文档的总行数
        {
            int count = 0;
            for (int n = 0; n < filedata.Length; n++)
            {
                if (filedata[n] == 10) count++;
            }
            count++;//最后一行没有换行符故总行数需+1
            string countline = "lines:" + count;
            Console.WriteLine(countline);
            return countline;
        }

        public string countfre(char[] filedata)//计算文档中单词的出现频数
        {
            int letter = 0, count = 0, t, len = countword(filedata);
            string[] word = new string[len];
            for (int n = 0; n < filedata.Length; n++)
            {
                if ((filedata[n] >= 97 && filedata[n] <= 122) || (filedata[n] >= 65 && filedata[n] <= 90))
                    letter++;
                else if (filedata[n] == 32)
                {
                    if (letter >= 4)
                    {
                        string[] letter1 = new string[letter];
                        t = n;
                        for (int i = 0; i < letter; i++)
                        {
                            letter1[i] = char.ToString(filedata[t - letter]);
                            t++;
                        }

                        for (int i = 0; i < letter; i++)
                            word[count] = word[count] + letter1[i];
                        count++;
                        letter = 0;
                    }
                    else letter = 0;
                }
                else letter = 0;
            }
            for (int i = 0; i < len; i++)
                word[i] = word[i].ToLower();
            string[] word1 = new string[len];
            int[] fre = new int[len];
            for (int i = 0; i < len; i++)
                fre[i] = 0;
            t = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (word[i] == word1[j])
                    {
                        fre[j]++;
                        break;
                    }
                }
                word1[t] = word[i];
                fre[t]++;
                t++;
            }

            int a, b;//按照频数大小从大到小进行排序
            string temp1;
            int temp2;
            for (a = 0; a < len; a++)
                for (b = a + 1; b < len; b++)
                {
                    if (fre[a] < fre[b])
                    {
                        temp1 = word1[a];
                        word1[a] = word1[b];
                        word1[b] = temp1;
                        temp2 = fre[a];
                        fre[a] = fre[b];
                        fre[b] = temp2;
                    }
                }
            //取得频数最高的10个单词的字符串和频数
            int[] maxf = new int[10];
            string[] maxw = new string[10];
            for (a = 0; a < 10; a++)
            {
                maxf[a] = fre[a];
                maxw[a] = word1[a];
            }
            for (a = 0; a < 10; a++)//对于频数相等的单词按照字典顺序进行排序
                for (b = a + 1; b < 10; b++)
                {
                    if (fre[a] == fre[b] && word1[a] != null && word1[b] != null)
                    {
                        if (word1[a].CompareTo(word1[b]) > 0)
                        {
                            temp1 = word1[a];
                            word1[a] = word1[b];
                            word1[b] = temp1;
                        }
                    }
                }
            string result = null, r;
            for (int i = 0; i < 10; i++)
            {
                r = word1[i] + ":" + fre[i].ToString();
                Console.WriteLine(r);
                result = result + r + " ";
            }
            return result;
        }
    }
}