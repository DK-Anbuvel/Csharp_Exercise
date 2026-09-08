namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public partial class arrayProblem
        {
            public int ThreeSumClosest(int[] nums, int target) // time O(n^3) space O(1)
            {
                /*
                 about the problem:-
                   Here linear arrary give, 
                   find 3 random distinct element 
                   there sum is closest to target ( +1 or -1)

                 my approach:-
                  attempt 1 :-  [-1,2,-4,1] brute-force approach 
                    to pick random index, for equal to target so, better we sort the array.
                    [-4,-1,1,2]
                    possible ways;-
                     7! / (7-3)! 3!
                     = 5 x 6 x 7 / 1 x 2 x 3
                     = 210 / 6 
                     = 35 ways.
                     3 inner loop - max 500 length then 2,07,08,500 times iterated.
                     how to find clostest one ?
                      minDiff =  minDiff > abb(sum -target)

                */
                int result = nums[0] + nums[1] + nums[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i+1; j < nums.Length; j++) //i < j < k  So each combination is checked only once
                    {
                        for (int k = j+1; k < nums.Length; k++)
                        {
                            int sum = nums[i] + nums[j] + nums[k];
                            if (Math.Abs(sum - target) < Math.Abs(result - target))
                                result = sum;

                        }
                    }
                }
                return result;
            }
            public int ThreeSumClosest1(int[] nums, int target)
            {
                Array.Sort(nums);
                int res = 214748364;
                int distance = 214748364;
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    int minSum = nums[i] + nums[i + 1] + nums[i + 2];
                    if (target < minSum)
                    {
                        if (Math.Abs(target - minSum) < Math.Abs(res - target))
                            res = minSum;
                        return res;
                    }

                    int maxSum = nums[i] + nums[nums.Length - 1] + nums[nums.Length - 2];
                    if (target > maxSum)
                    {
                        if (Math.Abs(target - maxSum) < Math.Abs(res - target))
                            res = maxSum;
                        continue;
                    }

                    int k = i + 1;
                    int j = nums.Length - 1;
                    while (k < j)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        int diff = Math.Abs(target - sum);
                        if (diff < distance)
                        {
                            distance = diff;
                            res = sum;
                        }
                        if (sum < target)
                        {
                            k++;
                            while (k < j && nums[k] == nums[k - 1]) k++;
                        }
                        else if (sum > target)
                        {
                            j--;
                            while (j > k && nums[j] == nums[j + 1]) j--;

                        }
                        else
                        {
                            return sum;
                        }
                    }
                }
                return res;
            }
            public int ThreeSumClosest2(int[] nums, int target)
            {
                int n = nums.Length;
                Array.Sort(nums);
                int left, right, sum = 0, min = 20000;
                int res = sum;
                for (int i = 0; i < n; i++)
                {
                    // sum = nums[i];
                    left = i + 1;
                    right = n - 1;
                    while (left < right)
                    {
                        sum = nums[i] + nums[left] + nums[right];
                        if (sum > target)
                        {
                            if (min > Math.Abs(sum - target))
                            {
                                res = sum;
                                min = Math.Abs(sum - target);
                            }
                            right--;
                        }
                        else if (sum == target) return sum;
                        else
                        {
                            if (min > Math.Abs(target - sum))
                            {
                                res = sum;
                                min = target - sum;
                            }
                            left++;
                        }
                    }
                }
                return res;
            }
            public int ThreeSumClosest3(int[] nums, int target)
            {

                Array.Sort(nums);
                int n = nums.Length;
                int closeSum = nums[0] + nums[1] + nums[2];

                for (int i = 0; i < n - 2; i++)
                {
                    int right = n - 1;
                    int left = i + 1;

                    while (left < right)
                    {
                        int val = nums[i] + nums[right] + nums[left];

                        if (Math.Abs(target - val) < Math.Abs(target - closeSum))
                        {
                            closeSum = val;
                        }

                        if (val > target)
                        {
                            right--;
                        }
                        else if (val < target)
                        {
                            left++;
                        }
                        else return val;

                    }
                }
                return closeSum;
            }
            public int ThreeSumClosest4(int[] nums, int target)
            {
                Array.Sort(nums);
                var closest = nums[0] + nums[1] + nums[2];

                for (int i = 0; closest != target && i < nums.Length - 2; i++)
                {
                    var curr = nums[i] + TwoSumClosest(nums, target - nums[i], i + 1);
                    if (Math.Abs(target - closest) >= Math.Abs(target - curr))
                    {
                        closest = curr;
                    }
                }

                return closest;
            }

            private int TwoSumClosest(int[] nums, int target, int low)
            {
                var high = nums.Length - 1;
                var closest = nums[high] + nums[low];

                while (low < high)
                {
                    var curr = nums[low] + nums[high];
                    if (Math.Abs(target - closest) >= Math.Abs(target - curr))
                    {
                        closest = curr;
                    }

                    switch (target.CompareTo(curr))
                    {
                        case 0:
                            return target;

                        case 1:
                            low++;
                            break;

                        default:
                            high--;
                            break;
                    }
                }
                return closest;
            }

          
        }
    }
}
