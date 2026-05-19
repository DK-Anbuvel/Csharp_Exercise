namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int MajorityElement(int[] nums)
        {
            /*
        My Approach :-
         1) Here access the entire loop 10^4 size so
            2 inner loop, get each element and compare all array element
            and store the count static variable
             time (n * n) // In worst case may be Time Limit Exception
             space (n)

         2) Dictionary<nums[i],count> and one iteration
              time (n)
             space (n^2)
         3) Linq
         4) Trick answer, 
         The majority element is the element that appears more than ⌊n / 2⌋ times
         meaning it will occupy the middle position in the sorted array.
         5) Boyer-Moore Voting Algorithm,
     */
            Dictionary<int, int> temp = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (temp.ContainsKey(i))
                    temp[i]++;
                else
                    temp[i] = 1;
            }
            var a = temp.Select(i => i.Value).OrderDescending();

            return 0;
        }
        public int MajorityElement1(int[] nums)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if (temp.ContainsKey(i))
                    temp[i]++;
                else
                    temp[i] = 1;
            }

            return temp.OrderByDescending(x => x.Value)
                       .First().Key;
        }
        public int MajorityElement2(int[] nums) // time O(n log n)  space O(n)
        {
            int c = nums.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .First().Key;

            int result = (from n in nums
                          group n by n into g
                          orderby g.Count() descending
                          select g.Key)
                          .First();
            return result;
        }
        public int MajorityElement3(int[] nums)
        {
            /*
             * Boyer-Moore Voting Algorithm
               This finds the majority element (appears more than n/2 times) in an array using O(1) space.

               Core Idea
               Think of it as an elimination game — non-majority elements cancel out majority elements one-for-one, but since the majority
               appears more than half the time, it always survives.
             */
            int count = 0;
            int candidate = 0;
            foreach (int num in nums)
            {
                if (count == 0)
                    candidate = num;
                //  count += (num == candidate) ? 1 : -1;
                count = count + (num == candidate ? 1 : -1);
            }
            return candidate;
        }
        public int MajorityElement4(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
        public int MajorityElement5(int[] nums) => nums.
        GroupBy(m => m).
        MaxBy(m => m.Count()).
        Key;
    }

}
