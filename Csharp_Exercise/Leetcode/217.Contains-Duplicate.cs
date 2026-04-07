namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool ContainsDuplicate(int[] nums) // runtime 55ms time O(NlogN) space O(N)
        {

            /*
              My Approach:-
                1) LINQ
                2) Two pointer pattern -- sort and validate the adjacent indices
                3) 2 Inner Loop -- get 1 index and compare with all other elements
                4) HashSet -- validate and store array elements 
            */
            int a = nums.GroupBy(s => s)
                    .OrderByDescending(x => x.Count())
                    .Select(x => x.Count())
                    .First();
            return a > 1 ? true : false;
        }
        public bool ContainsDuplicate2(int[] nums) // Runtime: 102ms time O(NlogN) space O(1)
        {
            Array.Sort(nums); // QuickSort/IntroSort  time O(n log n)
            int left = 0, right = 1;
            while(left < right) // O(N) time // while(right < nums.Length)
            {
                if (right < nums.Length)
                    break;
                if (nums[left] == nums[right])
                    return true;

                left++;
                right++;
            }
            return false;  // total time = O(n log n) + O(n) = O(n log n)
        }
        public bool ContainsDuplicate3(int[] nums) //  Runtime: 12ms time O(N) space O(N)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!set.Add(num)) // false if it already present in hashset
                    return true;
            }

            return false;
        }
        public bool ContainsDuplicate4(int[] nums)
        {
            int n = nums.Length;
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && nums[j - 1] >= nums[j]; j--)
                {
                    if (nums[j] == nums[j - 1])
                    {
                        return true;
                    }
                    (nums[j], nums[j - 1]) = (nums[j - 1], nums[j]);
                }

            }
            return false;
        }
        public bool ContainsDuplicate5(int[] nums)
        {
            List<int> ls_nums = new List<int>();

            foreach (var num in nums)
            {
                if (ls_nums.Contains(num))
                {
                    return true;
                }
                else { ls_nums.Add(num); }

            }
            return false;
        }
    }
}
