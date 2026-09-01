namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public void Rotate() // time O(N) space O(N)
            { //[1,2,3,4,5,6,7], k = 3  [5,6,7,1,2,3,4]   //2,3  1

                int[] nums = [1, 2, 3, 4, 5, 6, 7];
                int k = 3;

                k %= nums.Length; //nums.Length = 7  k = 10   10 % 7 = 3
                //int[] clone = new int[nums.Length];

                int[] fPart = nums[(nums.Length- k)..]; // first part
                int[] sPart = nums[..(nums.Length - k)]; // secand part

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
        }
    }
}
