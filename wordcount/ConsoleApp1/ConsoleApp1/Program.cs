using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public class Program
    {
        
        
        static void Main(string[] args)
        {
            //统计最多的10个单词及其词频
             Dictionary<string, int> newword = getWord();
            int size = 0;
            foreach (KeyValuePair<string, int> kvp in newword)
            {

                size++;
                if (size > 11)
                    break;
                if(size!=1)
                    {
                Console.Write( kvp.Key);
                    string outa=string.Format("{0}\r\n",kvp.Value);
                Console.WriteLine(kvp.Value);
                    File.AppendAllText(@"C:\Users\18075\Desktop\WordCount\wordcount\ConsoleApp1\ConsoleApp1\小王子词频统计.txt",kvp.Key);
                    File.AppendAllText(@"C:\Users\18075\Desktop\WordCount\wordcount\ConsoleApp1\ConsoleApp1\小王子词频统计.txt",outa);
                    
                    }
                Console.ReadKey();
                }
            using(FileStream fs = new FileStream(@"小王子英文版.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
{
    using (StreamReader sr = new StreamReader(fs))
    {//Write your code here
                 Console.WriteLine("你想要按几个切分？");
                int ine=Convert.ToInt32(Console.ReadLine());
                string strlines;
                strlines=sr.ReadToEnd();
                    char[] c = { ' ', ' ',',', '.', '?', '!', ':', ';', '\'', '\"','\t','-' ,'\n'};
                string[] s = strlines.Split(c);
                    int kkw=0;
                    int j=0;
                    for(int i=0;i<((s.Length)/ine);i=i+ine)
                        {
                        kkw++;
                        for(;j<(kkw*ine);j++)
                            {
                            

                                
                                Console.Write(s[j]+"  ");
                            }
                        
                        Console.WriteLine();
                        
}
                  
                    Console.ReadKey();
                    getwords();
                        

    }
        }


                
    }
           //输出前n多的单词
         public static   void getwords()
            {
           Dictionary<string, int> newword = getWord();
            Console.WriteLine("您好，请问您想输出前几多的单词数？");
            int size = Convert.ToInt32(Console.ReadLine());
            int count=0;
            foreach (KeyValuePair<string, int> kvp in newword)
            {

                count++;
                if (count >size+1)
                    break;
                if(count!=1)
                    {
                Console.Write( kvp.Key);
                Console.WriteLine(kvp.Value);
                Console.ReadKey();
                    }
                }
            }

            //统计词组词频数
            /*
            public static  Dictionary<string, int> getArrayCount()
            {
             for (int i = 0; i < s.Length; i++)
                {
                    if (tword.ContainsKey(s[i]))
                    {
                        
                        tword[s[i]]++;
                    }
                    else
                    {
                        if(s[i].Length>3 )
                        {    wsaw++;
                              tword[s[i]] = 1;
                        }
                               
                    }
                }




}*/

           
            
            
            
            
            
            //统计单词数
           public static  Dictionary<string, int> getWord()
            {
                string a =word();
                Dictionary<string, int> tword = new Dictionary<string, int>();
                int wsaw=0;
                char[] c = { ' ', ',', '.', '?', '!', ':', ';', '\'', '\"' };
                string[] s = a.Split(c);
                for (int i = 0; i < s.Length; i++)
                {
                    if (tword.ContainsKey(s[i]))
                    {
                        
                        tword[s[i]]++;
                    }
                    else
                    {
                        if(s[i].Length>3 )
                        {    wsaw++;
                              tword[s[i]] = 1;
                        }
                               
                    }
                }
                readlines();
                Console.WriteLine("单词的个数为"+wsaw+"个");
                return tword.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);
                 

            }
          

            //读入以及字符数
          public static  string word()
            {
            string strline;
            string www="";
            
                try{
                  FileStream afile = new FileStream("小王子英文版.txt",FileMode.Open);
                    StreamReader sw=new StreamReader(afile);
                   strline=sw.ReadToEnd();
                    while (strline!=null)
                        {
                          Console.WriteLine("字符数为："+strline.Length);
                          return strline;
                         }
                    sw.Close();
                    return www;
                    }
                catch(IOException ex)
                {
                Console.WriteLine("AN IOException has been thrown");
                Console.WriteLine(ex.ToString());
                
                    return www;
                }
            }
        /*
            static void PrintArray<T>(T [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            System.Console.WriteLine();
        }*/
      
           
            //统计行数
          public static   void readlines()
                {
         string[] Lines = File.ReadAllLines("C:\\Users\\18075\\Desktop\\WordCount\\wordcount\\ConsoleApp1\\ConsoleApp1\\小王子英文版.txt");
                int t=0;
                for(int i=0;i<Lines.Length;i++)
                {
                    if(Lines[i]=="")
                    {
                        t = t + 1;
                    }
                }
                Console.WriteLine(Lines.Length-t);

          }

            }
        } 
        
    

    
    
    
