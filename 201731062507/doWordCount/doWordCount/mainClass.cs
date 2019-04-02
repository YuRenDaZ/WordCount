using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace doWordCount
{
    class MainClass
    {
        public static void Main()
        {
            DoCount doCount = new DoCount();
            string path = "input.txt";
            string outpath=null;
            int countword=doCount.CountWord(path);
            int countchar = doCount.CountChar(path);
            int countline=doCount.CountLine(path);
            Dictionary<string, int> a = doCount.DescSort(doCount.CountF(path));
            doCount.Write(path, outpath);
                    
        }
    }
}
