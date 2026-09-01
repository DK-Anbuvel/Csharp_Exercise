namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<IList<int>> Generate(int numRows) //time O(N^2) space O(N^2) Dynamic Programming
        {
            IList<IList<int>> res = new List<IList<int>>(); // top-down approach
            
            for(i=0; i< numRows; i++)
            // why i not get syntax error (int i) , it declare some where in the class
            // loop runs = numRows times + numRow * numRow 
            {
                List<int> temp = new List<int> ();
                if (res.Count >= 1)
                {
                    temp.Add(1);

                    for (int j = 0; j+1 < res[i-1].Count; j++)
                    {
                        temp.Add(res[i-1][j] + res[i-1][j+1]);
                    }
                    temp.Add(1);
                }
                else
                {
                    temp.Add(1);
                }
                res.Add(temp);
            }
            return res;
        }
        public IList<IList<int>> Generate3(int numRows)
        {

            IList<IList<int>> result = new List<IList<int>>();
          //  if(numRows==1) return result.Add(new List<int> {1});

            for (int i = 0; i < numRows; i++) // to limit the arrary range
            {
                List<int> temp = new List<int>();
                temp.Add(1);
                if (result.Count > 0)
                {
                    for (int j = 0; j + 1 < result[i - 1].Count; j++)
                    {
                        int sum = result[i - 1][j] + result[i - 1][j + 1];
                        temp.Add(sum);
                    }
                    temp.Add(1);
                }
                result.Add(temp);
            }
            return result;
        }
        public IList<IList<int>> Generate1(int numRows)
        {
            var result = new List<IList<int>>();
            if (numRows <= 0) return result;
            for (int i = 0; i < numRows; i++)
            {
                List<int> currRow = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        currRow.Add(1);
                    }
                    else
                    {
                        int leftAbove = result[i - 1][j - 1];
                        int rightAbove = result[i - 1][j];
                        currRow.Add(leftAbove + rightAbove);
                    }
                }
                result.Add(currRow);
            }
            return result;
        }
        public IList<IList<int>> Generate2(int numRows)
        {
            List<IList<int>> triangle = new List<IList<int>>();
            if (numRows == 0) return triangle;

            triangle.Add(new List<int>() { 1 });

            for (int i = 1; i < numRows; i++)
            {
                List<int> prevRow = (List<int>)triangle[i - 1];
                List<int> newRow = new List<int> { 1 };

                for (int j = 1; j < prevRow.Count; j++)
                {
                    newRow.Add(prevRow[j - 1] + prevRow[j]);
                }

                newRow.Add(1);
                triangle.Add(newRow);
            }
            return triangle;
        }

    }
}
