namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int RemoveDuplicates(int[] nums)
            {
                /*
                 about this problem:-
                   Here modify the nums as unique array
                   return the length of the unique array nums

                 My approach:-
                    
                  attempt 1 :-
                      Two pointers pattern (k,i)
                      
                */

                if(nums.Length ==0) return 0;

                int p = 1; // pervious pointer

                for(int c=1;c<nums.Length;c++) // 1,1, 2,2
                {
                    if( nums[c] != nums[c-1])
                    {
                        nums[p] = nums[c];
                        p++;
                    }
                }
                return p;
            }
            public int RemoveDuplicates1(int[] nums)
            { // 1 1 2 
                int k = 0;
                foreach (int n in nums.Distinct())
                {
                    nums[k] = n;
                    k++;
                }
                return k;
            }
        }
    }
}
