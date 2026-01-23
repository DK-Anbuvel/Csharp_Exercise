using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        /*
         * In Transition method, we can use 3 nested loop but it leads O(n^3) time complexity.
         * so, try to do with O(n^2) complexity.
         */
        public IList<IList<int>> ThreeSum(int[] nums) // Two pointer method
        {
            IList<IList<int>>result = new List<IList<int>>();
            Array.Sort(nums); // first the no. makes easy to handle duplicate values.
            int k = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                if (i >0 && nums[i] == nums[i-1])
                {
                    continue; // skip the duplicate from i
                }
                while (j < k)
                {
                    int total = nums[i] + nums[j] + nums[k];
                    if (total == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        j++;
                        k--;
                        while (j<k && nums[j] == nums[j - 1]) j++; // skip the duplicate from j
                        while (j < k && nums[k] == nums[k + 1]) k--; // skip the duplicate from k
                    }
                    else if (total < 0) j++; // move j towards
                    else k--; // move k inwards.
                }
            }
            return result;
        }
    }
}
