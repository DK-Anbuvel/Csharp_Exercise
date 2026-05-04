namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int[] Intersect(int[] nums1, int[] nums2) // runtime 0ms space 47.6 Hash Table/Counting
        {
              // time O(M+N) space O(1)
            int[] copy = new int[1001];
            List<int> result = new List<int>();

            foreach (int i in nums1)
                copy[i]++;

            foreach(int i in nums1)
            {
                if (copy[i] > 0)
                {
                    result.Add(i);
                    copy[i]--;
                }
            }
            return result.ToArray();

        }
        public int[] Intersect1(int[] nums1, int[] nums2) // runtime 0ms
        {

            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (var n in nums1)
            {
                counts[n] = counts.GetValueOrDefault(n, 0) + 1;
            }

            var result = new List<int>();

            foreach (var n in nums2)
            {
                if (counts.TryGetValue(n, out var c) && c > 0)
                {
                    result.Add(n);
                    counts[n]--;
                }
            }

            return result.ToArray();

        }
        public int[] Intersect2(int[] nums1, int[] nums2) // runtime 10ms
        {
            int[] cnt1 = new int[1001];
            int[] cnt2 = new int[1001];
            foreach (int i in nums1)
            {
                cnt1[i]++;
            }
            foreach (int i in nums2)
            {
                cnt2[i]++;
            }
            List<int> res = [];
            for (int i = 0; i < 1001; i++)
            {
                int cnt = Math.Min(cnt1[i], cnt2[i]);
                for (int j = 0; j < cnt; j++)
                {
                    res.Add(i);
                }
            }
            return res.ToArray();
        }
        public int[] Intersect3(int[] nums1, int[] nums2) // space 45 MB, time O(n) space O(min(N,M))
        {
            List<int> res = new List<int>();
            Array.Sort(nums1); //  O(n log n)
            Array.Sort(nums2);
            int n = nums1.Length;
            int m = nums2.Length;
            int left = 0;
            int right = 0;
            while (left < n && right < m) // limit loop
            {
                if (nums1[left] == nums2[right])
                {
                    res.Add(nums1[left]);
                    left++;
                    right++;
                }
                else if (nums1[left] < nums2[right])
                {
                    left++;
                }
                else
                {
                    right++;
                }
            }
            return res.ToArray();
        }
    }
}
