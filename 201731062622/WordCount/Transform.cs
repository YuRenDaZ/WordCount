//作者：杨永智
//时间：2019.4.3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
   public class Transform
    {
        /// <summary>
        /// 将所有字符串都转化成小写形式
        /// </summary>
        /// <param name="allStr"></param>
        /// <returns></returns>
        public static string TransForm(string allStr)
        {
            return allStr.ToLower();
        }
    }
}
