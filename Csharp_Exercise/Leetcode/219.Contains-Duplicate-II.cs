

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            /*
               Given an integer array nums and an integer k, return true if there are two distinct 
               indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

               nums = [1,2,3,1], k = 3 // true.
               nums = [1,2,3,1,2,3], k = 2 // false.

               first of all this question take some time to understand. Here need to take nearest
               duplicate element and take those indices minis them the result should be <= k.
            
              My approach:-

                   1) Two pointer with snake approach time O(n^2) space O(1) //Time Limit Exceeded
                   2) Hash table  time O(n) space O(n)
               
            */
            if (nums.Length < 2) return false;
            int left = 0, right = 1;
            bool isLeftToRight = true;
            while (left < nums.Length)
            {
                if (right == nums.Length) // once right reach the end, then left move one step forward.
                {
                    ++left;
                    --right;
                    isLeftToRight = false;
                }
                if (left >= nums.Length - 1) break;
                if (right == left) // once right return to left, then left move one step forward.
                {
                    ++left;
                    right += 2;
                    isLeftToRight = true;
                }
                if (right < nums.Length && isLeftToRight) // L -----> R (n.length)
                {
                    if (nums[left] == nums[right] && Math.Abs(left - right) <= k) return true;
                    else
                        right++;
                }
                else if (left < right && !isLeftToRight) // L (l - n.length) <----- R (n.length)
                {
                    if (nums[left] == nums[right] && Math.Abs(left - right) <= k) return true;
                    else
                        right--;

                }
            }
            return false;

        }
        public class StoreNums
        {
            public int index { get; set; }
            public int val { get; set; }
        }

        public bool ContainsNearbyDuplicate2(int[] nums, int k) // runtime =22ms , time O(n) space (n)
            //[1,0,1,1] K=1 // fail bcz 2 duplicate skipped then nearest duplicate not founded
            //Great time complexity! To optimize space, remove elements older than k indices to maintain a sliding window of size k.
            //Consider:Can you tweak your logic to discard old indices automatically, keeping the memory usage proportional to k instead of n?
        {
            // List<StoreNums> temp = new List<StoreNums>();
            Dictionary<int, int> temp = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!temp.ContainsKey(nums[i]))
                {
                    temp.Add(nums[i], i); // value , index  
                }
                else
                {
                    int elIndex = temp.GetValueOrDefault(nums[i]);
                    if (Math.Abs(elIndex - i) <= k) return true;
                    //so
                    temp[nums[i]]=i;
                }
            }
            return false;
        }
        public bool ContainsNearbyDuplicate1(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>(); // value, index

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    int prevIndex = map[nums[i]];
                    if (Math.Abs(prevIndex - i) <= k) return true;
                }

                map[nums[i]] = i; // here the trick, previous get exception for duplicate key, to handle this replace exiting value. 
            }

            return false;
        }
        public bool ContainsNearbyDuplicate3(int[] nums, int k)
        {
            Dictionary<int, int> dict = new(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                if (!dict.TryAdd(value, i))
                {
                    if (Math.Abs(dict[value] - i) <= k)
                    {
                        return true;
                    }
                    else
                    {
                        dict[value] = i;
                    }
                }

            }
            return false;
        }
        public bool ContainsNearbyDuplicate4(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                    return true;
                set.Add(nums[i]);
                if (set.Count > k)
                {
                    set.Remove(nums[i - k]);
                }
            }
            return false;
        }
        public bool ContainsNearbyDuplicate5(int[] nums, int k)
        {
            var left = 0;
            var right = 1;

            while (left < nums.Length - 1)
            {
                if (right - left > k || (right == nums.Length - 1 && nums[left] != nums[right]))
                {
                    left++;
                    right = left + 1;
                    continue;
                }

                if (nums[left] == nums[right])
                    return true;

                if (right < nums.Length - 1)
                    right++;
            }

            return false;
        }
        public bool ContainsNearbyDuplicate6(int[] nums, int k)
        {
            SortedSet<int> set = new SortedSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return true;
                }

                set.Add(nums[i]);
                if (set.Count > k)
                {
                    set.Remove(nums[i - k]);
                }
            }

            return false;
        }
    }
}
