using System;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 A = new Class1();
            string path = Console.ReadLine();
            string str = File.ReadAllText(path);
            Console.WriteLine("asc" + ":" + A.Getasc(str));
            Console.WriteLine("line"+":"+A.Getch(str));
            Console.WriteLine("word" + ":" + A.Getword(str));
            A.Countword(str,10);
            Console.ReadLine();
        }
    }
}
