namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int[] Intersection(int[] nums1, int[] nums2) // runtime 5ms  Brute-Force Search time: O(N∗M) space: O(1)
        {
            /*
              About this:-
                  need to intersect the two array, without duplicate values.
              approach:-
                    traditional way , 
                       1  staic array, take hight lenght and loop then validate and insert result array.
                       failed due to can't track result[i] index while loop.

              Input: nums1 = [1,2,2,1], nums2 = [2,2]
              Output: [2]

            */

            List<int> result = new List<int>();

            foreach (int i in nums1) //O(n)
            {
                if (nums2.Contains(i) && !result.Contains(i)) // O(m)
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }
        public int[] Intersection1(int[] nums1, int[] nums2) // runtime 0ms time: O(N+M) space : O(min(N,M))
        {

            // way 3
            int[] array = new int[1001];
            List<int> res = new List<int>();
            foreach (int n in nums1) // 
            {
                array[n]++; // used n as index 
            }
            foreach (int k in nums2)
            {
                if (array[k] > 0) // check the same with k index
                {
                    res.Add(k);
                    array[k] = 0;
                }
            }
            return res.ToArray();
        }
        public int[] Intersection2(int[] nums1, int[] nums2)  // space 46.1 MB
        {
            // Since constraints say 0 <= nums[i] <= 1000
            bool[] exists = new bool[1001];
            bool[] added = new bool[1001];
            List<int> result = new List<int>();

            // Mark numbers present in nums1
            foreach (int num in nums1)
            {
                exists[num] = true;
            }

            // Check numbers in nums2
            foreach (int num in nums2)
            {
                if (exists[num] && !added[num])
                {
                    result.Add(num);
                    added[num] = true; // Ensure uniqueness in the result
                }
            }

            return result.ToArray();
        }
        public int[] Intersection3(int[] nums1, int[] nums2)  // space 46.1 MB
        {
            // Since constraints say 0 <= nums[i] <= 1000
            bool[] exists = new bool[1001];
  
            List<int> result = new List<int>();

            // Mark numbers present in nums1
            foreach (int num in nums1)
            {
                exists[num] = true;
            }

            // Check numbers in nums2
            foreach (int num in nums2)
            {
                if (exists[num])
                {
                    result.Add(num);
                    exists[num] = false; // Ensure uniqueness in the result
                }
            }

            return result.ToArray();
        }
    }
}
