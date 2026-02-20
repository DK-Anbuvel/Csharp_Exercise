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
        public void ReverseString(char[] s)// O(N) (time) O(1) (space) Best case(time)
        {
            // simple two pointer method, just swap two pointers in loop
            if (s.Length == 1) return; // not required, just for fun.
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                (s[left], s[right]) = (s[right], s[left]);
                left++;
                right--;
            }
        }
        public void ReverseString1(char[] s) //worst case (space)
        {
            Array.Reverse(s);
        }
        public void ReverseString2(char[] s) // best case (space)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                (s[i], s[j]) = (s[j], s[i]);
            }
        }
        public void ReverseString3(char[] s) // worst case (time)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char ch = s[i];
                s[i] = s[j];
                s[j] = ch;
                i++;
                j--;
            }
        }
    }
}
