//作者：杨永智
//时间：2019.4.3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class SplitString
    {
        /// <summary>
        /// 以t为分割符分割字符串
        /// </summary>
        /// <param name="allStr"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<string> storestring(string allStr,string t)
        {
            List<string> list = new List<string>();
            string[] a = allStr.Split(t.ToCharArray());
            //遍历字符串数组，每读取到一个字符串就将其存入到列表中，并同时存入一个空格
            foreach (string m in a)
            {
                list.Add(m);
            }
            return list;
        }
    }
}
