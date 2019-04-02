using System;
using System.Collections.Generic;
using System.Collections;

namespace doWordCount
{
    public interface Count {
        int CountChar(string path);//计算总字母个数

        int CountWord(string path);//计算文本中总单词数

        int CountLine(string path);//计算文本总行数

        Dictionary<string,int> CountF(string path);//计算文本中每个单词的频数

        Dictionary<string, int> DescSort(Dictionary<string, int> dic);//将字母按频数降序排序

        void Write(string path, string outPath);//输出在文件里
    };
}
