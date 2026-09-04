namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int ThreeSumClosest(int[] nums, int target)
            {

                /*
                 about the problem:-
                   Here linear arrary give, 
                   find 3 random distinct element 
                   there sum is closest to target ( +1 or -1)

                 my approach:-
                  attempt 1 :-  [-1,2,-4,1]
                    to pick random index, for equal to target so, better we sort the array.
                    [-4,-1,1,2]
                    possible ways;-
                     7! / (7-3)! 3!
                     = 5 x 6 x 7 / 1 x 2 x 3
                     = 210 / 6 
                     = 35 ways.
                     3 inner loop - max 500 length then 2,07,08,500 times iterated.
                     how to find clostest one ?
                      minDiff =  minDiff > abb(sum -target)


                */
                int result = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i == j) continue;
                        for (int k = 0; k < nums.Length; k++)
                        {
                            if (i == j || j == k || i == k) continue;

                            int sum = nums[i] + nums[j] + nums[k];
                            int minDiff = Math.Abs(sum - target);
                            if (result > minDiff)
                                result = minDiff;

                        }
                    }
                }
                return result;
            }
        }
    }
}
