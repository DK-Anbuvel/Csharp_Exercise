namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<string> SummaryRanges(int[] nums) // runtime 1ms Two pointer time O(n) space O(1)
        {
            /*
              About this problem:-
                  Here the array of sorted inters give, 
                  we need to validate and split the array based on condition.
              My Approach:-
                  1) 3 pointers 
                        pointers are left,right and SubIndex (to store sub array start index)

              [0,1,2,4,5,7]
             */
            int left = 0, right = 1;
            IList<string> result = new List<string>();
            while(left < nums.Length)
            {
                if (right < nums.Length)
                {
                    if (nums[right] - nums[right - 1] != 1)
                    {
                        if (right != left && right - left != 1)
                        {
                            result.Add($"{nums[left]}->{nums[right - 1]}");
                        }
                        else
                        {
                            result.Add($"{nums[left]}");
                        }
                        left = right;
                    }
                }
                else
                {
                    if(left == nums.Length-1)
                        result.Add($"{nums[left]}");
                    else
                        result.Add($"{nums[left]}->{nums[nums.Length - 1]}");
                    break;
                }
                    right++;
            }
            return result;
        }
        public IList<string> SummaryRanges1(int[] nums) // 3 pointer 
        {
            int left = 0, right = 1, SubIndex = 0;
            IList<string> result = new List<string>();
            while (left < nums.Length)
            {
                if (left == nums.Length - 1 && SubIndex == left)
                    result.Add($"{nums[left]}");
                else if (nums[right] - nums[left] != 1)
                {
                    if (SubIndex != left)
                    {
                        result.Add($"{nums[SubIndex]}->{nums[left]}");
                    }
                    else
                    {
                        result.Add($"{nums[left]}");
                    }
                    SubIndex = right;
                }
                right++;
                left++;
            }
            return result;
        }

        public IList<string> SummaryRanges2(int[] nums)
        {
            IList<string> result = new List<string>();

            if (nums.Length == 0)
            {
                return result;
            }

            int start = nums[0];

            for (int i = 1; i <= nums.Length; i++)
            {
                if (i == nums.Length || nums[i] != nums[i - 1] + 1)
                {
                    if (start == nums[i - 1])
                    {
                        result.Add(start.ToString());
                    }
                    else
                    {
                        result.Add(start + "->" + nums[i - 1]);
                    }

                    if (i < nums.Length)
                    {
                        start = nums[i];
                    }
                }
            }
            return result;
        }
        public IList<string> SummaryRanges3(int[] nums)
        {
            var result = new List<string>();
            if (nums.Length == 0) return result;

            int startEl = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if ((long)nums[i] - nums[i - 1] > 1)
                {
                    result.Add(FormatRange(startEl, nums[i - 1]));
                    startEl = nums[i];
                }
            }

            result.Add(FormatRange(startEl, nums[nums.Length - 1]));

            return result;
        }

        private string FormatRange(int start, int end)
        {
            return start == end ? $"{start}" : $"{start}->{end}";
        }
        public IList<string> SummaryRanges4(int[] nums)
        {
            var result = new List<string>();
            var tempResult = new List<string>();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (!nums.Contains(num - 1) || i == 0)
                {
                    if (tempResult.Count != 0)
                    {
                        result[^1] += "->" + tempResult[^1];
                    }
                    result.Add(num.ToString());
                    tempResult.Clear();

                }
                else
                {
                    tempResult.Add(num.ToString());
                    if (i == nums.Length - 1)
                    {
                        result[^1] += "->" + tempResult[^1];
                    }
                }
            }

            return result;
        }
        public IList<string> SummaryRanges5(int[] nums)
        {
            if (nums.Length == 0)
                return new List<string>();
            List<(int s, int e)> result = new() { (nums[0], nums[0]) };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= result[result.Count - 1].e + 1)
                {
                    var updTuple = result[result.Count - 1];
                    updTuple.e = nums[i];
                    result[result.Count - 1] = updTuple;
                    continue;
                }
                result.Add((nums[i], nums[i]));
            }
            return result.Select(a => a.s == a.e ? $"{a.s}" : $"{a.s}->{a.e}").ToList();
        }
        public IList<string> SummaryRanges6(int[] nums)
        {
            var result = new List<string>();
            if (nums.Length == 0) return result;

            int start = 0;
            for (int i = 1; i <= nums.Length; i++)
            {
                if (i == nums.Length || nums[i] > nums[i - 1] + 1)
                {
                    if (start == i - 1)
                        result.Add(nums[start].ToString());
                    else
                        result.Add($"{nums[start]}->{nums[i - 1]}");
                    start = i;
                }
            }
            return result;
        }
    }
}
