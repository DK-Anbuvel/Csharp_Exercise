using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Exercise
    {
        /*
         * Q2. Word Squares II
             You are given a string array words, consisting of distinct 4-letter strings, each containing lowercase English letters.
             
             A word square consists of 4 distinct words: top, left, right and bottom, arranged as follows:
             
             top forms the top row.
             bottom forms the bottom row.
             left forms the left column (top to bottom).
             right forms the right column (top to bottom).
             It must satisfy:
             
             top[0] == left[0], top[3] == right[0]
             bottom[0] == left[3], bottom[3] == right[3]
             Return all valid distinct word squares, sorted in ascending lexicographic order by the 4-tuple (top, left, right, bottom)​​​​​​​
           Input: words = ["able","area","echo","also"]
           Input: words = ["code","cafe","eden","edge"]

          first 1 : if string array contains 4 static words then how many pattern we can make there ?
                  4! = 24
         */
        public List<List<string>> WordSquares(string[] words)
        {
            List<List<string>> result = GeneratePermutation(words.ToList(), words.Length);
            return result;
        }
        private static List<List<string>>GeneratePermutation(List<string> list,int length)
        {
            int a = 2;
            var result = new List<List<string>>();
            if (length == 1)
            {
                result.Add(new List<string>(list));
                return result;
            }
            for (int i = 0; i < length; i++)
            {
                List<string> remainList = new List<string>(list);
                remainList.RemoveAt(i);

                List<List<string>> remainPermutation = GeneratePermutation(remainList, length - 1);

                foreach (var word in remainPermutation)
                {
                    word.Insert(0, list[i]);
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
