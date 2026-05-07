namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            /*
            My apporach :-
                   Here need to find max consecutive 1's 
                   by using while loop with one variable we find the anwser.

                   time : O(n) space : O(1)
            */
            int result = 0;
            int temp = 0;
            foreach (int i in nums)
            {

                if (i == 1)
                {
                    temp++;
                }
                else
                {
                    result = Math.Max(temp, result);
                    temp = 0;
                }
            }
            return Math.Max(temp, result);
        }
        public int FindMaxConsecutiveOnes1(int[] nums)
        {
            int highest = 0;
            int current = 0;
            foreach (int i in nums)
            {
                if (i == 1)
                {
                    current++;
                    if (current > highest)
                    {
                        highest = current;
                    }
                }
                else current = 0;
            }
            return highest;
        }
        public int FindMaxConsecutiveOnes2(int[] nums)
        {
            var sum = 0;
            var curr = 0;
            var max = 0;
            for (var i = 0; i < nums.Count(); i++)
            {
                curr = nums[i];
                sum = sum * curr + curr;
                max = Math.Max(sum, max);
            }
            return max;
        }
    }
}
