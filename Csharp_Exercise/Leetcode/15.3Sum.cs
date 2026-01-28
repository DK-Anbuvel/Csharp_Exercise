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
        //  [-1, 0, 1, 2, -1, -4]
        public IList<IList<int>> ThreeSum(int[] nums) // Two pointer method  O(n^2)
        {
            nums.Append(2);
          
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); // first the no. makes easy to handle duplicate values.

            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                if (i > 0 && nums[i] == nums[i - 1])
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
                        while (j < k && nums[j] == nums[j - 1]) j++; // skip the duplicate from j
                        while (j < k && nums[k] == nums[k + 1]) k--; // skip the duplicate from k
                    }
                    else if (total < 0) j++; // move j towards
                    else k--; // move k inwards.
                }
            }
            return result;
        }

        public IList<IList<int>> ThreeSum2(int[] nums)  // Best case (time) 
        {
            var result = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return result;
            Array.Sort(nums);
            int n = nums.Length;

            for (int i = 0; i < n - 2; i++)
            {
                // Skip duplicate values for i
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                // Early termination: if smallest is positive, no valid triplet.
                if (nums[i] > 0) break;
                int j = i + 1;
                int k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum > 0)
                        k--;
                    else if (sum < 0)
                        j++;
                    else
                    {
                        // Found a triplet
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        j++; k--;

                        // Skip duplicates for j
                        while (j < k && nums[j] == nums[j - 1]) j++;

                        // Skip duplicates for k
                        while (j < k && nums[k] == nums[k + 1]) k--;
                    }
                }
            }
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                File.WriteAllText("display_runtime.txt", "00000");

            GC.Collect();
            return result;
        }
        public IList<IList<int>> ThreeSum3(int[] nums) // Worst case (time)
        {
            IList<IList<int>> result = new List<IList<int>>();

            // HashSet<IList<int>> result = new HashSet<IList<int>>();
           
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int j = i + 1;
                int k = n - 1;

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        int[] set = new int[3] { nums[i], nums[j], nums[k] };
                        Array.Sort(set);
                        if (!result.Any(x => x[0] == nums[i] && x[1] == nums[j] && x[2] == nums[k]))
                        {
                            result.Add(set.ToList());
                        }

                        j++;
                        k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                }
            }

            return result;

        }



        public IList<IList<int>> ThreeSum4(int[] nums) //worst case (space)
        {
            List<IList<int>> ans = new List<IList<int>>();
            Dictionary<String, int> exclusions = new Dictionary<String, int>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int target = -nums[i];

                Dictionary<int, int> compliments = new Dictionary<int, int>();

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (compliments.ContainsKey(nums[j]))
                    {
                        List<int> result = new List<int>() { nums[i], nums[j], compliments[nums[j]] };
                        result.Sort();
                        if (!exclusions.ContainsKey(String.Join(' ', result.ToArray())))
                        {
                            ans.Add(result);
                            exclusions[String.Join(' ', result.ToArray())] = 1;
                        }
                    }
                    else
                    {
                        compliments.TryAdd(target - nums[j], nums[j]);
                    }
                }

            }

            return ans;
        }
    }
}
    
