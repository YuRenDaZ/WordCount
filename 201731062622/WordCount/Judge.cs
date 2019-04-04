//作者：杨永智
//时间：2019.4.3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class Judge
    {
        /// <summary>
        /// 判断字符串是否是一个单词
        /// </summary>
        /// <param name="AString"></param>
        /// <returns></returns>
        public static string JudgeWord(string AString)
        {
            //AString为被判断的字符串
            //用正则表达式判断字符串是否是以字母开头并且长度大于四，如果是，返回这个字符串，如果不是，返回一个空格
            Regex regexRule = new Regex(@"^[a-z].*");
            string tempStr = "";
            if (regexRule.IsMatch(AString)&&AString.Length>=4)
                tempStr = AString;
            else
                tempStr = "";
            return tempStr;

        }
    }
}
