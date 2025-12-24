using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public class Leetcode2 : Leetcode
    {
        public int LengthOfLongestSubstring(string s)  //3. Longest Substring Without Repeating Characters
        {
            int res = 0;
            int tem = 0;
            if (s != null)
            {
                char[] list = new char[s.Length];   //abcabcabc
                for (int i = 0; i < s.Length && res < s.Length - i; i++)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (!list.Contains(s[j]))
                        {
                            tem += 1;
                            list[j] = s[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (tem > res)
                    {
                        res = tem;
                    }
                    Array.Clear(list);
                    tem = 0;

                }
            }
            else
            {
                res = 0;
            }
            GC.Collect();
            return res;
        }
        public int LengthOfLongestSubstring_bestCase(string s)  // best case (silding window techncique)
        {

            int max = 0;


            var lastIndex = new int[128];

            for (int start = 0, end = 0; end < s.Length; end++)
            {
                char currentChar = s[end];
                start = Math.Max(start, lastIndex[currentChar]);
                max = Math.Max(max, end - start + 1);
                lastIndex[currentChar] = end + 1;
            }

            return max;
        }

    }
}
