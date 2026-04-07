namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int SingleNumber(int[] nums)
        {
            /*
                linear runtime complexity = O(n) -- one loop
                 use only constant extra space =O(1) -- fixed variable
               [4,1,2,1,2]
            */
            Dictionary<int, int> temClone = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (temClone[i] == i) // KeyNotFoundException
                    temClone.Remove(i);
                else
                    temClone.Add(i, i);
            }
            //if (temClone.Count > 0)
            // return temClone.FirstOrDefault(s => s.Value); //FirstOrDefault returns KeyValuePair, not int
            // else
            return 0;
        }
        public int SingleNumber1(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            /*
              first storing array element as key in dictionary dt and value as default to 1
              then it increasing +1 on secound time 
              lastly iterate the dictionary for get value == 1 and the key.
              
              time (n ^2) for two loops
              space (n)
             */
            foreach (int num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            foreach (var item in dict)
            {
                if (item.Value == 1)
                    return item.Key;
            }

            return 0;
        }

        public int SingleNumber2(int[] nums) // bit manipulation (XOR) time O(N) space O(1)
        {
            /*
              [4, 1, 2, 1, 2]
               2 ^ 2  ^ 1 = 1
           

              XOR Works only when:
                Every number appears twice
                Except one number

             */
            int result = 0;

            foreach (int num in nums)
            {
             //   result ^= num;
                result = result ^ num;
            }

            return result;
        }
        public int SingleNumber3(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                bool duplicate = false;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[i] == nums[j])
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                {
                    return nums[i];
                }
            }
            return 0;
        }
        public int SingleNumber4(int[] nums)
        {

            if (nums.Length > 1)
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (numbers != null && !numbers.Any(x => x == nums[i]))
                    {
                        numbers.Add(nums[i]);
                        var singnumList = nums.Where(x => x == nums[i]).ToList();
                        if (singnumList.Count == 1)
                        {
                            return singnumList[0];
                        }
                        continue;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            else
            {
                return nums[0];
            }

            return 0;
        }
    }
}
