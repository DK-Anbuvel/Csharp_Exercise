namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<int> GetRow(int rowIndex) // time 2 inner loop O(n^2) space O(N)
        {

            /*
             dynamic programming(top-down/Memorization)

             My approach 1:-
                create two array one for previous array and other for current array
                initially set every row first index as 1
                check above row, set two pointers , 
                    sum the pointer set value to current row, 
                    then move the pointer 
                    same cycle up to 2 pointers have index
                    else set default 1 on the row index
                once reach the n th row return the current array.
            simple...

            Can you calculate the row values directly using math formulas to skip the inner loop?
            */
            int[] nRowArray = new int[rowIndex+1]; // 4
            for (int i = 1; i <= rowIndex+1; i++)
            {
                int left = 0, right = 0;
                for (int l = 0; l < i; l++)
                {
                    if (l == 0 || l == i-1) // first and last index set as 1 and validate the array length.
                        nRowArray[l] = 1;
                    else
                    {
                        left = left == 0 ? nRowArray[l-1] : left;// after 1 time, to move the index
                        right = nRowArray[l];
                        nRowArray[l] = left + right;
                    }
                    left = right;
                    right = 0;
                }
            }
            return nRowArray;
        }
        public IList<int> GetRow1(int rowIndex)
        {
            IList<int> list = new List<int>();
            for (int i = 0; i <= rowIndex; i++)
            {
                list.Add(1);
                for (int j = i - 1; j > 0; j--)
                {
                    list[j] = list[j] + list[j - 1];
                }
            }
            return list;
        }
        public IList<int> GetRow2(int rowIndex)
        {
            var res = new List<int>();

            for (var i = 0; i <= rowIndex; i++)
            {
                if (i == 0)
                {
                    res.Add(1);
                }
                else if (i == 1)
                {
                    res.Add(1);
                }
                else
                {
                    var temp = new List<int>();
                    Console.Write(res.Count);
                    for (var j = 0; j <= res.Count; j++)
                    {
                        if (j == 0)
                        {
                            temp.Add(res[j]);
                        }
                        else if (j == res.Count)
                        {
                            temp.Add(res[j - 1]);
                        }
                        else
                        {
                            temp.Add(res[j] + res[j - 1]);
                        }
                    }
                    res = temp;
                }
            }
            return res;
        }
        public IList<int> GetRow3(int rowIndex)
        {
            List<int> row = new List<int>() { 1 };

            for (int k = 1; k <= rowIndex; k++)
            {
                row.Add((int)((row[row.Count - 1] * (long)(rowIndex - k + 1)) / k));
            }

            return row;
        }
    }
}
