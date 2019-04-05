using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class AddFunction
    {
        public static string function1(string path)
        {
            string a = "";
            a = ImportFile.ImportMyFile(path);
            return a;
        }
        public static void function2(string path ,string strtemp)
        {
                ImportFile.WriteFile(path, strtemp);
        }
        public static string function3(string path, int num)
        {
            string allStr = "";
            int count = 0;
                Dictionary<string, int> wordDic = new Dictionary<string, int>();
                Dictionary<string, int> sortDic = new Dictionary<string, int>();
                wordDic = Count.CountWord(SplitString.storestring(ImportFile.ImportMyFile(path), " "));
                sortDic = Count.SortValue(wordDic);
                foreach(KeyValuePair<string,int> temp in sortDic)
                {
                    Console.WriteLine(temp.Key + ":" + temp.Value);
                    allStr = allStr + temp.Key + " : " + temp.Value + "\n";
                    count++;
                    if (count == num) break;
                }
            return allStr;
        }
    }
}
