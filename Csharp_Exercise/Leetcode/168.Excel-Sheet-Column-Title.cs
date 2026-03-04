using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public string ConvertToTitle(int columnNumber)
        { /*
            stored values in dictionary.
            Here divided the columnNumber by 26 add remainder value in result;
            till columnNumber less by 26.
            and added Last columnNumber value in result;
           */
            Dictionary<int, string> alphabets = new Dictionary<int, string>
            {
                {1,"A" },
                {2,"B" },
                {3,"C" },
                {4,"D" },
                {5,"E" },
                {6,"F" },
                {7,"G" },
                {8,"H" },
                {9,"I" },
                {10,"J" },
                {11,"K" },
                {12,"L" },
                {13,"M" },
                {14,"N" },
                {15,"O" },
                {16,"P" },
                {17,"Q" },
                {18,"R" },
                {19,"S" },
                {20,"T" },
                {21,"U" },
                {22,"V" },
                {23,"W" },
                {24,"X" },
                {25,"Y" },
                {26,"Z" }
            };

            if (columnNumber < 27) return alphabets[columnNumber]; //728 --> AAZ 
            string res = string.Empty;
            bool isDivided = false;
            
            while(columnNumber >26)
            {
                int reminder = columnNumber % 26;
                if (reminder != 0)
                {
                    if (isDivided)
                        res = alphabets[columnNumber - 1] + res;
                    else
                        res = alphabets[reminder] + res;

                      isDivided = false;
                }
                else
                {
                    res = res+"Z";// rem = 0 means 26
                    isDivided=true;
                }
                columnNumber = columnNumber / 26;
            }
            if (isDivided)
                res = alphabets[columnNumber-1] + res;
            else
                res = alphabets[columnNumber] + res;

            return res;
        }
    }
}
