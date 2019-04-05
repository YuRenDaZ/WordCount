//作者：杨永智
//时间：2019.4.2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Count
    {
        /// <summary>
        /// 统计各个字符串出现的次数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountWord(List<string> list)
        {
            //初始化一个字典，用来统计各个字符串出现的次数
            Dictionary<string, int> WordDic = new Dictionary<string, int>();
            //建立一个哈希表，统计所有的不同的字符
            HashSet<string> hashlist = new HashSet<string>();
            foreach (string a in list)
            {
                if (a.Length==0) continue;
                hashlist.Add(a);
            }
            //遍历哈希表，将哈希表的每一个元素作为字典的key值
            foreach (string a in hashlist)
            {
                int count = 0;
                foreach(string b in list)
                {
                    //统计各个字符串出现的次数，并将count作为value值
                    if (a == b) count++;
                }
                //将key值和value值存入字典
                WordDic.Add(a, count);
            }
            return WordDic;
        }
        /// <summary>
        /// 将字典以Value排序
        /// </summary>
        /// <param name="strdic"></param>
        /// <returns></returns>
        public static Dictionary<string, int> SortValue(Dictionary<string, int> strdic)
        {
            var sortedDictionary = from keyValuepair in strdic
                                   orderby keyValuepair.Value
                                   descending
                                   select keyValuepair;
            Dictionary<string, int> res = new Dictionary<string, int>();
            foreach (KeyValuePair<string ,int> item in sortedDictionary)
            {
                res.Add(item.Key,item.Value);
            }
            return res;
        }
        /// <summary>
        /// 将字典以Key排序
        /// </summary>
        /// <param name="strdic"></param>
        /// <returns></returns>
        public static Dictionary<string,int> SortKey(Dictionary<string,int> strdic)
        {
            var sortedDictionary = from keyValuepair in strdic
                                   orderby keyValuepair.Key
                                   ascending
                                   select keyValuepair;
            Dictionary<string, int> res = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> item in sortedDictionary)
            {
                res.Add(item.Key, item.Value);
            }
            return res;
        }
    }
}
