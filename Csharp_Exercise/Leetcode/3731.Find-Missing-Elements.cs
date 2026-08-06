namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<int> FindMissingElements(int[] nums) // time O(n log n + m) space O(1)
        {

            /*
             About this Problem:-
                Here given list of n unique no. in array, need to find mini and max no. then return the missing no. in the range.

             My Apporach:-

                attempt 1:-
                Dictionary<key,value>(101) for find the missing no. and find max and min value => O(n) O(n)
                IList<int> result making => O(n)

                attempt 2:-
                 arrary.sort() and iterate for find missing no. => O(1) O(n)

                attempt 3:-

            */

            Array.Sort(nums); //[6,7,10]
            List<int> missing = new List<int>();

            for (int i = 0; i < nums.Length - 1; i++) //O( nlog n)
            {

                while (nums[i] != (nums[i + 1] - 1)) // (O(M)
                { // to check current and next element are equal using minus 1
                    missing.Add(nums[i] + 1);
                    nums[i]++;
                }
            }
            return missing;
        }
        public IList<int> FindMissingElements1(int[] nums) // O(N + M) linear time complexity 
        {
            List<int> res = new List<int>();
            int n = nums.Length;
            bool[] present = new bool[101];
            int min = 101;
            int max = 0;
            foreach (int num in nums)
            {
                present[num] = true;
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            for (int i = min; i < max; i++)
            {
                if (!present[i])
                {
                    res.Add(i);
                }
            }

            return res;
        }
        public IList<int> FindMissingElements2(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            IList<int> lis = new List<int>();
            int min = 101, max = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                hs.Add(nums[i]);
                if (nums[i] < min)
                    min = nums[i];
                if (nums[i] > max)
                    max = nums[i];
            }

            for (int i = min; i < max; i++)
            {
                if (!hs.Contains(i))
                {
                    lis.Add(i);
                }
            }
            return lis;

        }
        public IList<int> FindMissingElements3(int[] nums)
        {
            var st = new HashSet<int>(nums);
            int mn = nums.Min();
            int mx = nums.Max();

            var ans = new List<int>();
            for (int i = mn + 1; i < mx; i++)
            {
                if (!st.Contains(i))
                {
                    ans.Add(i);
                }
            }
            return ans;
        }
    }
}
