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
        public string ConvertToTitle(int columnNumber) // logic failed by reminder 0 numbers
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

        public string ConvertToTitle1(int columnNumber)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // set static variable for get alphabets place value
            var sb = new StringBuilder(); // for result store 
            while (columnNumber > 0) // since greater then 0 loop continues.
            {
                columnNumber--; // to handle 26 no. perfect divider , first minis 1 then modules(%) 26 then add the 1 

                var d = columnNumber % 26;
                sb.Insert(0, chars[d]);
                columnNumber /= 26;  
            }

            return sb.ToString();
        }
        public string ConvertToTitle2(int columnNumber) //O(log26n) time,O(log26n) space.
        {
            string result = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                char c = (char)('A' + columnNumber % 26); // magic come from ASCII code. 
                result = c + result;
                columnNumber /= 26;
            }
            return result;
        }
        public string ConvertToTitle3(int columnNumber)//Converting a decimal number to a bijective base-26 system using recursion. top-down approach O(log n) time,O(log n) space.
        {
            if (columnNumber == 0) return "";
            columnNumber--;
            char c = (char)('A' + columnNumber % 26);
            return ConvertToTitle3(columnNumber / 26) + c;
        }
    }
}
