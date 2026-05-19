namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int ArrayPairSum(int[] nums)// 44ms time O(NlogN) space O(1)
        {

            /*
             About this problem :-
                 Here given array need to make subarray with 2 elements 
                 and create nums.Length/2  subarrays per rows
                 then sum the minium , value of the each subarray 
                 return the maxium value

             My approach :-
                  how to create the unique subarray rows

                  While brut force see something, 
                   first sort the given array then sum the odd place no. then return.
                   it works even negative value as well.

            */

            Array.Sort(nums);
           // int[] sort = nums.OrderBy(s => s).ToArray();
            int MaxPairSum = 0;
            for (int i = 0; i < nums.Length; i += 2)
                MaxPairSum += nums[i];

            return MaxPairSum;

        }
        public int ArrayPairSum1(int[] nums)
        {
            // Array.Sort(nums);
            // int s = 0;
            // for(int i=0;i<nums.Length;i=i+2){
            //     s += nums[i];
            // }
            // return s;
            int n = nums.Length;
            int l = nums[0];
            int r = nums[0];
            foreach (int v in nums)
            {
                l = Math.Min(l, v);
                r = Math.Max(r, v);
            }
            Span<int> s = stackalloc int[r - l + 1];
            foreach (int v in nums)
            {
                s[v - l]++;
            }
            int x = l;
            int take = 1;
            int ans = 0;
            while (x <= r)
            {
                if (s[x - l] == 0)
                {
                    x++;
                }
                else
                {
                    ans += (take * x);
                    s[x - l]--;
                    take ^= 1;
                }
            }
            return ans;
        }
        // Approach 1: Sorting
        // Time O(n log n)
        // Space O(n)
        // Approach 2: Counting Sort
        // Time O(n + k) - N is the number of pairs that will be produced i.e., the size of list nums is 2N, and K is the range of possible values in nums
        // Space O(k)

        public int ArrayPairSum2(int[] nums)
        {
            // The constraint for LeetCode 561 elements is typically -10,000 to 10,000
            const int K = 10000;

            // Store the frequency of each element (using 2 * K + 1 to cover the range)
            int[] elementToCount = new int[2 * K + 1];

            foreach (int element in nums)
            {
                // Add K to element to offset negative values for array indexing
                elementToCount[element + K]++;
            }

            // Initialize sum to zero
            int maxSum = 0;
            bool isEvenIndex = true;

            for (int element = 0; element <= 2 * K; element++)
            {
                while (elementToCount[element] > 0)
                {
                    // Add the actual value (index - K) if it is at an even position
                    // because those represent the minimums in optimal pairs
                    maxSum += isEvenIndex ? (element - K) : 0;

                    // Flip the boolean to alternate between picking and skipping
                    isEvenIndex = !isEvenIndex;

                    // Decrement the frequency count
                    elementToCount[element]--;
                }
            }

            return maxSum;
        }
        public int ArrayPairSum3(int[] nums)
        {
            var map = new int[200001];
            for (var i = 0; i < nums.Length; i++)
            {
                map[nums[i] + 10000]++;
            }

            var (sum, flip) = (0, true);
            for (var i = 0; i < map.Length; i++)
            {
                while (map[i] > 0)
                {
                    if (flip)
                    {
                        sum += i - 10000;
                    }

                    flip = !flip;
                    map[i]--;
                }
            }

            return sum;
        }
    }
}
