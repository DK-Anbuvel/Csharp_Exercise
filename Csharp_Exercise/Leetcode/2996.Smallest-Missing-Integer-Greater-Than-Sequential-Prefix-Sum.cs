
namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int MissingInteger(int[] nums)
        {

            /*
            About this problem:-
               Initially nums of no. , which contain prefix sum sequential like n,n+1,(n+1)+1,..
               output based on two conditions,
                first : sum of the longest sequential prefix.
                secount: that sum is less then any other element in array then
                         return greather no. + 1

             My approach:-
                attempt 1:- 
                   2 variable -> store prefix sum, max value in array
            */
            if (nums.Length == 1) return nums[0] + 1;
            // [5,1] = 2
            if (nums.Length == 2)
                if (nums[0] < nums[1] && nums[0] != nums[1] - 1) return nums[0] + 1;


            int prefixSum = nums[0], maxVal = 0;
            bool isSequential = true;

            for (int i = 1; i < nums.Length; i++)  // [3,4,5,1,12,14,13]
            {
                // check is sequential
                if ((nums[i]-1) == nums[i - 1] && isSequential) //[1,2,2,5,1,2,3,4] -> 6 
                    prefixSum  += nums[i];
                else
                {
                    isSequential = false;

                    if(maxVal==0 && prefixSum ==  nums[i])// existing only check forward no. only
                        maxVal = prefixSum;  //  but it actually exist in different position

                    if (maxVal != 0 && maxVal < nums[i]) 
                        maxVal = nums[i];
                }
            }

            return (prefixSum < maxVal) ? maxVal + 1 : prefixSum;
        }
    }
}
