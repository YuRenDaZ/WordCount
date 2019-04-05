using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface Interface1
    {
        int Getch{ get; set;}
        int Getasc{ get; set; }
        int Getword { get; set; }
        Dictionary<string, int> Countword { get; set; }
    }
}
