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
                    time (n * n) // may be Time Limit Exception
                    space (n)

                2) Dictionary<nums[i],count> and one iteration
                     time (n)
                     space (n)
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
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                    candidate = num;

                //  count += (num == candidate) ? 1 : -1;
                count = (num == candidate) ? 1 : -1 + count;
            }

            return candidate;
        }
    }
}
