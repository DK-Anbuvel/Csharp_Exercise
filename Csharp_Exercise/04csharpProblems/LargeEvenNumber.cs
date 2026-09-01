using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Exercise
    {
        public string LargestEven(string s)
        {
            if (s == "") return "";
            string newS = s;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (newS[i] % 2 == 0)
                {
                    return newS;
                }
                else
                {
                    newS= newS.Remove(i, 1);
                }
            }
            return "";
        }
    }
}
