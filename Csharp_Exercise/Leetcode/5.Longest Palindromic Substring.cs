using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public string LongestPalindrome(string s)
        {
            s = "babad";

            if (string.IsNullOrEmpty(s) || s.Length < 1) return "";
            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandFromCenter(s, i, i);     // Odd length palindrome s.length/2 
                int len2 = ExpandFromCenter(s, i, i + 1); // Even length palindrome s.length/2
                int len = Math.Max(len1, len2);

                if (len > end - start)   // 4-1 = 3
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            string ss = s.Substring(start, end - start + 1);

            return s.Substring(start, end - start + 1);
        }

        private int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
        public string LongestPalindrome1(string s)  // best case // two pointers
        {
            s = "babad";

            if (string.IsNullOrEmpty(s)) return "";

            int start = 0; int maxLen = 1;

            for (int i = 0; i < s.Length; i++)
            {
                ExpandArountCenter(s,i,i,ref start,ref maxLen); //expand the center
                ExpandArountCenter(s,i,i+1,ref start,ref maxLen);
            }
            return s.Substring(start, maxLen);
        }
        private void ExpandArountCenter(string s,int left, int right, ref int start, ref int maxlen)
        {
            while(left >=0 && right < s.Length && s[left] == s[right])
            {
                int currentLen = right - left + 1;
                if(currentLen > maxlen)
                {
                    start = left;
                    maxlen = currentLen;

                }
                left--;
                right++;
            }
        }
        public string LongestPalindrome3(string s)  // second best case
        {
            for (int len = s.Length; len > 1; len--) // minimized the length of the string
            {
                for (int i = 0; i + len <= s.Length; i++)
                {
                    var sub = s.AsSpan(i, len);
                    if (IsPalindrome(sub))
                    {
                        return sub.ToString();
                    }
                }
            }
            return s.Substring(0, 1);
        }

        private static bool IsPalindrome(ReadOnlySpan<char> s)
        {
            for (int l = 0, r = s.Length - 1; l < r; l++, r--)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
            }
            return true;
        }
        public string LongestPalindrome4(string s)  // worst case in mememory complexity
        {
            if (s.Length == 1) return s;
            if (s.Length == 2 && s[0] == s[1]) return s;

            var plIdx = 0;
            var plWin = 1;
            for (int idx = 0; idx < s.Length; idx++)
            {
                for (int wdx = 2; idx + wdx <= s.Length; wdx++)
                {
                    var ss = s[idx..(idx + wdx)];// equals to s.Substring(idx, wdx); 
                    if (IsPalindrome(ss) && wdx > plWin)
                    {
                        plIdx = idx;
                        plWin = wdx;
                    }
                }
            }

            return s[plIdx..(plIdx + plWin)];
        }

        private bool IsPalindrome(string s)
        {
            var idx = 0;
            var rdx = s.Length - 1;
            var isPalindrome = true;
            while (isPalindrome && idx < rdx)
            {
                if (s[idx] == s[rdx])
                {
                    idx += 1;
                    rdx -= 1;
                }
                else
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
        }
    }
}
