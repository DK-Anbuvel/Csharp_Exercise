using System.Runtime.InteropServices;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int ThirdMax(int[] nums)  // runtime 6ms time O(NlogN) space O(1)
        {

            /*
              About the Problem :-
                       Need to return third distinct maximum no.
             Approach:-
                   First sort desc order it required O(n log n) time.
                   then loop with 2 variable (loop index and track third no.)
                  exceeded track break and return the first value.
               get unique third max no.

              [3,2,1]

            O(N)
            Replace sorting with a single pass using three variables to track top distinct values.
            */
            Array.Sort(nums);

            int thirdMax = 3;
            for(int i = nums.Length - 1; i >= 0 && thirdMax > 0; i--)
            {
                if (i == nums.Length - 1 || nums[i] != nums[i + 1]) --thirdMax;

                if (thirdMax == 0) return nums[i];
            }
            return nums[nums.Length - 1];
        }
        public int ThirdMax1(int[] nums) //time O(N) space O(1)
        {
            long first = long.MinValue;
            long second = long.MinValue;
            long third = long.MinValue;

            foreach (int num in nums)
            {
                // skip duplicates
                if (num == first || num == second || num == third)
                    continue;

                if (num > first)
                {
                    third = second;
                    second = first;
                    first = num;
                }
                else if (num > second)
                {
                    third = second;
                    second = num;
                }
                else if (num > third)
                {
                    third = num;
                }
            }

            if (third == long.MinValue)
            {
                return (int)first;
            }

            return (int)third;
        }
        public int ThirdMax2(int[] nums)
        {
            HashSet<int> set = new();
            PriorityQueue<int, long> pq = new();

            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            foreach (int num in set)
            {
                pq.Enqueue(num, (long)num * -1); // here the magic
            }

            if (pq.Count < 3)
            {
                return pq.Dequeue();
            }

            pq.Dequeue();
            pq.Dequeue();
            return pq.Dequeue();
        }
        public int ThirdMax3(int[] nums)
        {
            int[] sortedNums = nums.Distinct().OrderByDescending(x => x).ToArray();
            if (sortedNums.Length < 3)
            {
                return nums.Max();
            };
            return sortedNums[2];
        }

    }
}
