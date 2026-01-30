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
        public bool IsPalindrome125(string s)// two pointer easy way O(N) O(1)
        {
            s = "A man, a plan, a canal: Panama";
            if(String.IsNullOrEmpty(s)) return true;
            s = s.ToLower();
            // Here 
            string Alphanumeric = "abcdefghijklmnopqrstuvwxyz1234567890";

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (!Alphanumeric.Contains(s[left]))
                {
                    left++;
                    continue;
                }
                if (!Alphanumeric.Contains(s[right]))
                {
                    right--;
                    continue;
                }

                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }
        public bool IsPalindrome125II(string s)
        {
            short i = 0, j = (short)(s.Length - 1);

            while (i < j)
            {
                while (i < j && !IsAlphaNumeric(s[i]))
                    i++;

                while (i < j && !IsAlphaNumeric(s[j]))
                    j--;

                if (ToLower(s[i]) != ToLower(s[j]))
                    return false;
                i++;
                j--;
            }

            return true;
        }

        private bool IsAlphaNumeric(char c) =>
            (c is >= 'A' and <= 'Z') || (c is >= 'a' and <= 'z') || (c is >= '0' and <= '9');

        private char ToLower(char c) =>
            (c is >= 'A' and <= 'Z') ? (char)(c + 32) : c;

        public bool IsPalindrome123III(string s) //Best case (space)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;

                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;

                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
        public bool IsPalindrome125IV(string s) //Worst case (space)
        {
            string clean = "";
            foreach (char ch in s)
            {
                if (char.IsLetterOrDigit(ch)) clean += char.ToLower(ch);
            }
            int i = 0, j = clean.Length - 1;
            while (i < j)
            {
                if (clean[i] != clean[j]) return false;
                i++;
                j--;
            }
            return true;
        }
        public bool IsPalindrome125V(string s) // Worst case (time)
        {
            string newStr = string.Empty;
            foreach (var c in s)
            {
                if (char.IsLetterOrDigit(c))
                    newStr += char.ToLower(c);
            }

            return newStr == new string(newStr.Reverse().ToArray());
        }
    }


}
