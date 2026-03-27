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
              first, open all strs , compar, store the common, return longest.
              let use trie dsa

              strs = ["flower","flow","flight"]
            */
            TrieNode root = new TrieNode();
            int charIndex = 0;
            for(int i = 0; i < strs.Length; i++)// it only take the first char of all string array.
            {
                for(int j= charIndex; j <strs[i].Length; j++)
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
        }
    }
}
