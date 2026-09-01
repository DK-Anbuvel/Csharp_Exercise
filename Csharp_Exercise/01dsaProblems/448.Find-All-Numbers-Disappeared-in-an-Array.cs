
namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {

            /*
             about this problem:-
                 to find the missing no. in the range (1,nums.length)
             approach:-
                  first sort the arrary -- it makes easy validate no. and runtime O(log n)
                  for loop (n=0 < n.length)
                      if index +1  match = skip
                      else add the index in static list and skip
                  //[4,3,2,7,8,2,3,1]
                    [1,2,2,3,3,4,7,8] // 5 6
            */

            IList<int> result = new List<int>();
            HashSet<int> temp = new HashSet<int>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++) // failed due to index missing the position of the array.
            {
                if (i + 1 != nums[i] && !temp.Contains(nums[i]))
                    result.Add(i + 1);
                else
                    temp.Add(i + 1);
            }
            return result;
        }
        public IList<int> FindDisappearedNumbers1(int[] nums) // runtime 2274 ms  Brute-Force Search
        {
            IList<int> result = new List<int>();  // time O(n^2) space O(1)

            for (int i = 1; i <= nums.Length; i++) 
            {
                if (!nums.Contains(i))
                    result.Add(i + 1);
            }
            return result;
        }
        public IList<int> FindDisappearedNumbers2(int[] nums) // time O(n)
        {
            bool[] numbersSeen = new bool[nums.Length + 1]; // store nums as index and value as bool    

            for (int i = 0; i < nums.Length; i++) // O(n)
            {
                numbersSeen[nums[i]] = true;  // set index as true.
            }

            List<int> numbersNotSeen = new();

            for (int i = 1; i < numbersSeen.Length; i++) // O(n)
            {
                if (!numbersSeen[i])
                {
                    numbersNotSeen.Add(i);
                }
            }

            return numbersNotSeen;
        }
        public IList<int> FindDisappearedNumbers3(int[] nums)
        {
            List<int> returnal = Enumerable.Range(1, nums.Length).ToList();

            foreach (int number in nums)
            {
                returnal.Remove(number);
            }
            return returnal;
        }
        public IList<int> FindDisappearedNumbers4(int[] nums)
        {
            int n = nums.Length;
            IList<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                ans.Add(i + 1);
            }
            Array.Sort(nums);
            Array.Reverse(nums);
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > ans.Count) continue;
                if (ans[nums[i] - 1] != nums[i]) continue;
                else ans.RemoveAt(nums[i] - 1);
            }
            return ans;
        }
        public IList<int> FindDisappearedNumbers5(int[] nums)
        {
            List<int> result = [];
            for (int i = 1; i <= nums.Length; i++) if (!nums.Contains(i)) result.Add(i);
            return result.ToArray();
        }
        public IList<int> FindDisappearedNumbers6(int[] nums)
        {

            HashSet<int> numbers = new HashSet<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                numbers.Remove(nums[i]);
            }

            return numbers.ToList();
        }
    }
}
