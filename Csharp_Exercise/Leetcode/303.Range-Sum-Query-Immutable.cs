namespace Csharp_Exercise
{/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
    public partial class Leecodes
    {
        public class NumArray // runtime = 94 ms. Brute-Force Search
        {
            private int[] num;
            public NumArray(int[] nums)
            {
                num = nums;
            }

            public int SumRange(int left, int right)
            {
                int result = 0;
                while(left <= right)
                {
                    result += num[left];
                    left++;
                }
                return result;
            }
        }
        public class NumArray1 // Prefix sum
        {
            int[] prefix_sum;

            public NumArray1(int[] nums)
            {
                for (int i = 1; i <= nums.Length - 1; i++)
                {
                    nums[i] += nums[i - 1];
                }
                prefix_sum = nums;
            }

            public int SumRange(int left, int right)
            {
                if (left == 0)
                    return prefix_sum[right];
                return prefix_sum[right] - prefix_sum[left - 1];
            }
        }
        public class NumArray2
        {
            private int[] _nums;

            public NumArray2(int[] nums)
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    nums[i] += nums[i - 1];
                }
                _nums = nums;
            }

            public int SumRange(int left, int right)
            {
                if (left == 0)
                    return _nums[right];
                return _nums[right] - _nums[left - 1];
            }
        }

    }
}
