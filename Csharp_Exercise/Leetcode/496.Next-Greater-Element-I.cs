namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            /*
              About this Problem:-
                  it's takes Time to understand, two arrays there, nums1[i] <= nums2[i+1] other wise -1

             My approach:-

              1st attempt :- failed due to understanding gap [1,3,5,2,4] [6,5,4,3,2,1,7] --[7,7,7,7,7]
                  Here need to find same value position in the given 2 array --> O(n^2)
                  and compare the first and secound array index + 1.  
              
              2nd attempt:- 
                    3 nested loop --> O(n + M^2) 

            */
            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = -1;
                for (int j = 0; j + 1 < nums2.Length; j++)
                {

                    if (nums1[i] == nums2[j])
                    {

                        if (nums1[i] <= nums2[j + 1])
                            result[i] = nums2[j + 1];
                    }
                }
            }
            return result;
        }
        public int[] NextGreaterElement1(int[] nums1, int[] nums2) // 6ms
        { // Brute -force search  time O(n + M^2)  space O(1) 
            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = -1;
                for (int j = 0; j + 1 < nums2.Length; j++)
                {

                    if (nums1[i] == nums2[j])
                    {
                        for (int k = j + 1; k < nums2.Length; k++)
                        {
                            if (nums1[i] <= nums2[k])
                            {
                                result[i] = nums2[k];
                                break;
                            }

                        }

                    }
                }
            }
            return result;
        
        }
        public int[] NextGreaterElement3(int[] nums1, int[] nums2) // monolith incerese stack 
        {
            int n = nums1.Length;
            int m = nums2.Length;
            // var dict = new Dictionary<int,int>();
            // var stack = new Stack<int>();
            // dict.Add(nums2[m-1],-1);
            // for(int i=m-1;i>0;i--){
            //     if(nums2[i]>nums2[i-1]){
            //         dict.Add(nums2[i-1],nums2[i]);
            //         stack.Push(nums2[i]);
            //     }else{
            //         while(stack.Count>0 && stack.Peek()<=nums2[i-1]) stack.Pop();
            //         dict.Add(nums2[i-1],stack.Count>0?stack.Peek():-1);
            //     }
            // }
            // for(int i=0;i<n;i++){
            //     nums1[i]=dict[nums1[i]];
            // }
            // return nums1;

            int[] dict = new int[10001];//Dictionary to store the next greater no.
            int[] stack = new int[m];//Stack with index k to sort and store 
            int k = -1;
            for (int i = m - 1; i >= 0; i--)
            {
                while (k >= 0 && stack[k] <= nums2[i])
                {
                    k--;
                }
                if (k == -1)
                    dict[nums2[i]] = -1;
                else
                    dict[nums2[i]] = stack[k]; // see index and value
                stack[++k] = nums2[i];
            }
            for (int i = 0; i < n; i++)
            {
                nums1[i] = dict[nums1[i]];
            }
            return nums1;

            // int n1 = nums1.Length, n2 = nums2.Length;
            // int[] idx = new int[10001];
            // int[] maxs = new int[n2];
            // int k = -1;
            // for (int i = n2 - 1; i >= 0; i--) {
            //     while (k >= 0 && maxs[k] <= nums2[i])
            //         k--;
            //     if (k == -1)
            //         idx[nums2[i]] = -1;
            //     else
            //         idx[nums2[i]] = maxs[k];
            //     maxs[++k] = nums2[i];
            // }
            // for (int i = 0; i < n1; i++)
            //     nums1[i] = idx[nums1[i]];
            // return nums1;
        }
        public int[] NextGreaterElement4(int[] nums1, int[] nums2)
        {
            var map = new Dictionary<int, int>(nums2.Length);
            var stack = new Stack<int>();

            foreach (int num in nums2)
            {
                while (stack.Count > 0 && stack.Peek() < num) // return top and without remove
                {
                    map[stack.Pop()] = num; // return top and  remove
                }
                stack.Push(num); 
            } 

            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!map.TryGetValue(nums1[i], out res[i]))
                {
                    res[i] = -1;
                }
            }

            return res;
        }
        public int[] NextGreaterElement5(int[] nums1, int[] nums2)
        {
            var NGE = new Dictionary<int, int>();
            var st = new Stack<int>();

            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && st.Peek() < nums2[i])
                {
                    st.Pop();
                }

                if (st.Count == 0)
                {
                    NGE[nums2[i]] = -1;
                }
                else
                {
                    NGE[nums2[i]] = st.Peek();
                }

                st.Push(nums2[i]);
            }

            var ans = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                ans[i] = NGE[nums1[i]];
            }

            return ans;
        }
        public int[] NextGreaterElement6(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new();
            for (int i = 0; i < nums2.Length; i++) map[nums2[i]] = i;
            int[] next = getNextGreater(nums2), ans = new int[nums1.Length];
            Array.Fill(ans, -1);
            for (int i = 0; i < nums1.Length; i++)
            {
                if (next[map[nums1[i]]] != nums2.Length) ans[i] = nums2[next[map[nums1[i]]]];
            }
            return ans;

            int[] getNextGreater(int[] nums)
            {
                int[] next = new int[nums.Length];
                Stack<int> st = new();
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    while (st.Count > 0 && nums[st.Peek()] <= nums[i]) st.Pop();
                    next[i] = st.Count == 0 ? nums.Length : st.Peek();
                    st.Push(i);
                }
                return next;
            }
        }
        public int[] NextGreaterElement7(int[] nums1, int[] nums2)
        {
            int[] res = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = Finder(nums1[i], nums2);
            }

            return res;
        }
        private int Finder(int a, int[] nums2)
        {
            for (int i = 0; i < nums2.Length; i++)
            {
                if (nums2[i] == a)
                {
                    for (int j = i + 1; j < nums2.Length; j++)
                    {
                        if (nums2[j] > a)
                        {
                            return nums2[j];
                        }
                    }
                }
            }

            return -1;
        }
    }
}
