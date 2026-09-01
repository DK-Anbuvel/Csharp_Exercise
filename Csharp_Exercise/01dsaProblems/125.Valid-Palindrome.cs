using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public bool IsPalindrome125VI(string s) //Runtime: 34 ms
        {
            /*
               About the problem:-
                    validate string(letter and digits) is palindrome or not 
               My approach :-
                    Two pointers
                    For alphanumeric characters.
                       buildin methods :-
                         Char.IsLetterOrDigit
                         Char.IsLetter & Char.IsDigit
                       Manual methods :-
                           Range
                           Digits: 48 to 57 ('0' to '9')
                           Uppercase: 65 to 90 ('A' to 'Z')
                           Lowercase: 97 to 122 ('a' to 'z') 
                           Regex [^a-zA-Z0-9]
                           string "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789". 
            */
            // s = Regex.Replace(s, "[^a-zA-Z0-9]");
            s = s.ToLower();
            s = Regex.Replace(s, "[^a-z0-9]","");
            int l = 0, r = s.Length-1;
            while(l< r)
            {
                if (s[l] != s[r]) return false;
                l++;
                r--;
            }
            return true;
        }
        public bool IsPalindrome125VII(string s) //Runtime: 1 ms  
        {
            /*
               About the problem:-
                    validate string(letter and digits) is palindrome or not 
               My approach :-
                    Two pointers
                    For alphanumeric characters.
                       Manual methods :-
                           Range
                           Digits: 48 to 57 ('0' to '9')
                           Uppercase: 65 to 90 ('A' to 'Z')
                           Lowercase: 97 to 122 ('a' to 'z') 

             upper case validate like this 65 + 32 = 97
            digits,

            "A man, a plan, a canal: Panama"
            */
            int l = 0, r = s.Length - 1;

            for (; l < r; )
            {
                //if ((s[l] <= 9) || !(s[l] >= 65 && s[l] <= 90) || !(s[l] >= 97 && s[l] <= 122)) // left
                //    ++l;

                if (!char.IsLetterOrDigit(s[l]))
                {
                    l++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[r]))
                {
                    r--;
                    continue;
                }
                // for other then char how skip
                if ((s[l] == s[r])) // digit and lower char ||  uppercase + 32 = lowercase
                {
                    l++; r--;
                }
                else if( (s[l] >= 65 && s[r] >= 65))//  failed with 0P and P0
                {
                    if ((s[l] + 32 == s[r]) || (s[r] + 32 == s[l]))
                    {
                        l++; r--;
                    }else
                        return false;
                }
                else
                    return false;

            }
            return true;
        }
        public bool IsPalindrome125VIII(string s)
        {
            //string s= input.ToLower();
            short first = 0;
            short last = (short)(s.Length - 1);
            bool valid = true;



            while (first < last)
            {
                if (!checkifvalidchar(s[first])) { first++; continue; }
                if (!checkifvalidchar(s[last])) { last--; continue; }
                if (toLowerCase(s[first]) == toLowerCase(s[last]))
                {
                    first++;
                    last--;
                }
                else
                {
                    valid = false;
                    break;
                }

            }
            return valid;


        }

        public bool checkifvalidchar(char c)
        {
            //Comparision based on ascii
            int ascivalue = (int)c;
            if (ascivalue >= 97 && ascivalue <= 122 || ascivalue >= 65 && ascivalue <= 90 || ascivalue >= 48 && ascivalue <= 57)
            {
                return true;
            }
            return false;
        }

        public char toLowerCase(char c) =>

            (c is >= 'A' and <= 'Z') ? (char)(c + 32) : c;
    }


}
