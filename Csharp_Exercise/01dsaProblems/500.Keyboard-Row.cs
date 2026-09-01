namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public string[] FindWords(string[] words) // 11ms  time O(n*M) space O(1)
        {
            /*
             about this problem :-
                  Here array for string given, i need to find the word build from
                  the same row character, if yes store else skip.

             My apporach :-

                     remember need to treat as case in-sensitive 
                     change case to lower - o(1)
                     get word from arrary -- O(n)
                     compare with the static variables

                     Here i can also use ASIC code.
                     so i can minius  the O(1)  -- problem is 91 to 96  solved by A + 32 = a

                     how to track weather the word contain one specific row.
                      i need to track at the same time compare character.
                      solve with list char array and int tem variable for track.

                    how to trak all character in row only, while validating 2 loop
            */

            List<string> resultWord = new List<string>();  // no dynamic List not required, we can set as fixed size as words.Lenght

           // string[] resultWord = new string[words.Length];

            List<char[]> rows = new List<char[]>();
            rows.Add(['q','w','e','r','t','y','u','i','o','p']);
            rows.Add(['a','s','d','f','g','h','j','k','l']);
            rows.Add(['z','x','c','v','b','n','m']);

            foreach (string item in words) // H + 32 = 
            {
                int getRow = 0;
                if (rows[1].Contains(item[0]) || rows[1].Contains((char)(item[0] + 32))) getRow = 1;
                else if (rows[2].Contains(item[0]) || rows[2].Contains((char)(item[0] + 32))) getRow = 2;

                bool isValid = true;

                for (int i = 0; i < item.Length; i++)
                {

                   // if (!rows[getRow].Contains(item[i]) || !rows[getRow].Contains((char)(item[i] - 32)))
                    if (!rows[getRow].Contains(item[i]) && !rows[getRow].Contains(char.ToLower(item[i])))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) resultWord.Add(item);
            }
            return resultWord.ToArray();
        }
        public string[] FindWords1(string[] words)
        {
            HashSet<char> firstRow = new HashSet<char>("qwertyuiopQWERTYUIOP");

            HashSet<char> secondRow = new HashSet<char>("asdfghjklASDFGHJKL");

            HashSet<char> thirdRow = new HashSet<char>("zxcvbnmZXCVBNM");

            var list = new List<string>();

            foreach (string word in words)
            {
                HashSet<char> chars = new HashSet<char>(word);
                if (chars.IsSubsetOf(firstRow) || chars.IsSubsetOf(secondRow) || chars.IsSubsetOf(thirdRow))
                {
                    list.Add(word);
                }


            }
            return list.ToArray();
        }
        public bool isFromOneRowWord(string str)
        {
            char[] firstrow = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
            char[] seconrow = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L' };
            char[] thridrow = { 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

            char[] stringtocheck = str.ToCharArray();

            bool firstflag = false, secondflag = false, thirdflag = false;
            foreach (var item in stringtocheck)
            {
                if (firstrow.Contains(item))
                {
                    firstflag = true;
                }
                else if (seconrow.Contains(item))
                {
                    secondflag = true;
                }
                else if (thridrow.Contains(item))
                {
                    thirdflag = true;
                }
            }

            if (firstflag == true && secondflag == false && thirdflag == false)
            {
                return true;
            }

            if (firstflag == false && secondflag == true && thirdflag == false)
            {
                return true;
            }
            if (firstflag == false && secondflag == false && thirdflag == true)
            {
                return true;
            }
            return false;

        }
        public string[] FindWords3(string[] words)
        {



            List<string> ans = new();
            foreach (var item in words)
            {

                if (isFromOneRowWord(item))
                {
                    ans.Add(item);
                }

            }
            return ans.ToArray();
        }
        public string[] FindWords4(string[] words)
        {
            string[] ret = new string[words.Length];
            int ret_size = 0;
            Dictionary<char, short> mapping = new Dictionary<char, short>()
        {
            {'a', 2},
            {'A', 2},
            {'b', 3},
            {'B', 3},
            {'c', 3},
            {'C', 3},
            {'d', 2},
            {'D', 2},
            {'e', 1},
            {'E', 1},
            {'f', 2},
            {'F', 2},
            {'g', 2},
            {'G', 2},
            {'h', 2},
            {'H', 2},
            {'i', 1},
            {'I', 1},
            {'j', 2},
            {'J', 2},
            {'k', 2},
            {'K', 2},
            {'l', 2},
            {'L', 2},
            {'m', 3},
            {'M', 3},
            {'n', 3},
            {'N', 3},
            {'o', 1},
            {'O', 1},
            {'p', 1},
            {'P', 1},
            {'q', 1},
            {'Q', 1},
            {'r', 1},
            {'R', 1},
            {'s', 2},
            {'S', 2},
            {'t', 1},
            {'T', 1},
            {'u', 1},
            {'U', 1},
            {'v', 3},
            {'V', 3},
            {'w', 1},
            {'W', 1},
            {'x', 3},
            {'X', 3},
            {'y', 1},
            {'Y', 1},
            {'z', 3},
            {'Z', 3},
        };

            for (int i = 0; i < words.Length; i++)
            {
                bool ok = true;
                for (int j = 1; j < words[i].Length; j++)
                {
                    if (mapping[words[i][j]] != mapping[words[i][0]])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    ret[ret_size++] = words[i];
                }
            }

            Array.Resize(ref ret, ret_size);// to remove empty space.
            return ret;
        }
    }
}
