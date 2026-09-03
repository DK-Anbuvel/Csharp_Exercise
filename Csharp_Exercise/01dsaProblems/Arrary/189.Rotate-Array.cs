namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public void Rotate() // time O(N) space O(N)
            { // [5,6,7,1,2,3,4]   //2,3  1

                int[] nums = [1, 2, 3, 4, 5, 6, 7];
                int k = 3;

                k %= nums.Length; //nums.Length = 7  k = 10   10 % 7 = 3
                //int[] clone = new int[nums.Length];

                int[] fPart = nums[(nums.Length- k)..]; // first part
                int[] sPart = nums[..(nums.Length - k)]; // second part

                int[] result = [.. fPart, .. sPart];
                Array.Copy(result, nums, result.Length);
                //int currentIndex = 0;
                //for (int i = nums.Length - 1; i >= k; i--, k--, currentIndex++)
                //{
                //    clone[currentIndex] = nums[i];
                //}
                //for (int j = currentIndex + 1; j < nums.Length; currentIndex++, j++)
                //{
                //    clone[currentIndex] = nums[j];
                //}
                //nums = clone;
            }
            public void Rotate1(int[] nums, int k) //[1,2,3,4,5,6,7], k = 3 
            {
                k = k % nums.Length;
                Array.Reverse(nums, nums.Length - k, k); // [1,2,3,4,7,6,5]
                Array.Reverse(nums, 0, nums.Length - k); // [4,3,2,1,7,6,5]
                Array.Reverse(nums); // [5,6,7,6,1,2,3,4]
            }
            public void Rotate2(int[] nums, int k)
            {
                int length = nums.Length;
                k = k % length;
                Reverse(nums, 0, length);
                Reverse(nums, 0, k);
                Reverse(nums, k, length);
            }

            public void Reverse(int[] nums, int from, int to) // points for track first and last index 
            {
                for (int i = to - 1, j = from; j <= i; i--, j++)
                {
                    int t = nums[i];
                    nums[i] = nums[j];
                    nums[j] = t;
                }
            }
        }
    }
}
