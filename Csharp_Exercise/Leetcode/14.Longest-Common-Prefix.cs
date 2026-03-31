using System.Text;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new();
            public bool IsEndOfWord = false;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            /*
              first, open all strs , compare, store the common, return longest.
              let use trie dsa

              strs = ["flower","flow","flight"]

              first think i thought find any longest common prefix in array 
             but in actual question compare all prefix and take common prefix.

             My approach:-
               I simple take the first string, take character compare one by one. -> fail bca 

               time complexity could be 
                   outerloop strs.Lenght = n-1 times
                   innerloop sts[n] x strs.lenght -1
               O(nxn) = O(n^2)

               I don't sort this, 
             
              
            */
            TrieNode root = new TrieNode();
            int charIndex = 0;
            for(int i = 0; i < strs.Length; i++)// it only take the first char of all string array.
            {
                for(int j = charIndex; j < strs[i].Length; j++)
                {
                    if (j != charIndex) break;
                    if (!root.Children.ContainsKey(strs[i][j]))
                    {
                        root.Children[strs[i][j]] = new TrieNode();
                        root = root.Children[strs[i][j]];
                    }
                    else
                        break;
                }
            }
            return "";
        }
        public string LongestCommonPrefix3(string[] strs) //strs = ["flower", "flow", "flight"] 
                                                          //charIndex
        {
            int charIndex = 0;
            string temp = string.Empty;
            for ( i = 0; i < strs.Length; i++)
            {
                temp = strs[i];
                for(int j = 1; i < j && i != j ;j++)
                {
                    //if(charIndex)
                    if (temp[charIndex] != strs[j][charIndex])
                     return "";
                }
                charIndex++;
            }
            return temp.Substring(0, charIndex - 1);
        }
        public string LongestCommonPrefix4(string[] strs) // time O(m x n) space O(1)
         // iteration 4  and character count =200;
         // finally Two pointer approach 
         // pick one index and compare with all other string[i]
         //Comparing characters at the same index across all strings to find the common prefix length.
        {
            if (strs.Length == 1) return strs[0];
            int charIndex = 0;
            for (; charIndex <= 201; charIndex++) // max 200 times loop
            {
                int left = 0;
                int right = strs.Length - 1;
                while (left <= right) // strs/2  + 1 times loop 
                {
                    if (charIndex < strs[left].Length && charIndex < strs[right].Length) // validate range
                    {
                        if (strs[left][charIndex] != strs[right][charIndex])
                        {
                            if (charIndex == 0)
                                return "";
                            else
                                return strs[0].Substring(0, charIndex);
                        }

                        if (left == right)
                            if (strs[left - 1][charIndex] != strs[right][charIndex])
                            {
                                if (charIndex == 0)
                                    return "";
                                else
                                    return strs[0].Substring(0, charIndex);
                            }

                        left++;
                        right--;
                    } else
                        return strs[0].Substring(0, charIndex);
                }
            }
            return strs[0].Substring(0, charIndex);
        }

        public string LongestCommonPrefix1(string[] strs)
        {
            string pref = strs[0];
            int prefLen = pref.Length;
            for(int i =1;i < strs.Length; i++)
            {
                string temp = strs[i];
                while (prefLen > temp.Length || pref != temp.Substring(0, prefLen))
                {
                    prefLen--;
                }
                    if (prefLen == 0)
                        return "";
                    pref = pref.Substring(0, prefLen);
                
            }
            return pref;

        }
        public string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0) return "";
            string s = strs.OrderBy(x => x.Length).First();
            string l = "";
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                foreach (string str in strs)
                {
                    if (str[i] != c) return l;
                }
                l += c;

            }
            return l;
        }

        public string LongestCommonPrefix5(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            string prefix = strs[0]; // take first word as starting prefix

            for (int i = 1; i < strs.Length; i++)
            {
                // Reduce prefix until it matches the start of current string
                while (!strs[i].StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);

                    if (prefix == "")
                        return "";
                }
            }

            return prefix;
        }
        public string LongestCommonPrefix6(string[] strs)
        {
            var prefix = "";

            for (var i = 0; i < strs[0].Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                    {
                        return prefix;
                    }
                }

                prefix += strs[0][i]; 
            }

            return prefix;
        }
        public string LongestCommonPrefix7(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            Array.Sort(strs);

            string first = strs[0];
            string last = strs[strs.Length - 1];

            int i = 0;
            while (i < first.Length && first[i] == last[i])
            {
                i++;
            }

            return first.Substring(0, i);
        }
        public string LongestCommonPrefix8(string[] strs)
        {
            var length = strs.Min(s => s.Length);
            var prefix = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char c = strs[0][i];
                if (strs.Any(s => s[i] != c))
                {
                    break;
                }

                prefix.Append(c);
            }

            return prefix.ToString();
        }
    }
}
