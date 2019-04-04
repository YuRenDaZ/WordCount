//作者：杨永智
//时间：2019.4.3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount
{
    
    public class ImportFile
    {
        //path为被读取文件的地址，返回一个从文件中读取出来的字符串
        /// <summary>
        /// 读取path下的文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ImportMyFile(string path)
        {
            string tempStr = File.ReadAllText(path);
            return tempStr;
        }
        /// <summary>
        /// 统计path文件下的行数
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int FileLines(string path)
        {
            string[] tempStr = File.ReadAllLines(path);
            return tempStr.Length;
        }
        /// <summary>
        /// 写入字符串到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="stringtext"></param>
        public static void WriteFile(string path,string stringtext)
        {
            FileStream fs = new FileStream(path,FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(stringtext);
            sw.Close();
           
        }
        
    }
}
