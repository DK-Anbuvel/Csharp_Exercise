
using System;
using System.Collections;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int MissingMultiple(int[] nums, int k) // time O(N logN)  space O(N)
        {
            /*
             about this problem:-
                 return the smallest k multiple no. which not exist in nums.

             My approach:-
                attempt 1:-
                    first the sort nums ascending order
                    iterate nums.length time
                    if k exist then K=K*K
                    if k < nums[n] then return k , which means k smallest missing multiple no. in sorted arrary. 
             
                attempt 2:-
                    why not nums.Contains(multiple); ?

            Suggestions:
                 Use a hash set to store multiples for O(n) time, trading space for speed.
             */

            Array.Sort(nums); //[8,2,3,4,6] [2,3,4,6,8]
            nums.Contains(k);
            int multiple = k;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > multiple) return multiple;
                if (nums[i] == multiple) multiple += k;
            }
            return multiple;
        }

        public int MissingMultiple1(int[] nums, int k)
        {
            BitArray b = new BitArray(101);
            for (int i = 0; i < nums.Length; i++)
                b[nums[i]] = true;
            int nk = 0;
            while (true)
            {
                nk += k;
                if (nk > 100 || !b[nk]) return nk;
            }
        }
        public int MissingMultiple2(int[] nums, int k)
        {
            int[] heap = new int[4];
            int count = 0;

            int index = k;

            foreach (var n in nums)
            {
                if (n % k == 0 && n >= index)
                {
                    Insert(n);

                    while (count > 0 && heap[0] == index)
                    {
                        while (count > 0 && heap[0] == index)
                        {
                            RemoveMin();
                        }

                        index += k;
                    }
                }
            }

            return index;

            void Insert(int num)
            {
                Grow();

                int index = count++;
                heap[index] = num;

                while (index > 0)
                {
                    int parent = (index - 1) / 4;

                    if (heap[parent] < heap[index])
                        break;

                    (heap[parent], heap[index]) = (heap[index], heap[parent]);

                    index = parent;
                }
            }

            void Grow()
            {
                if (heap.Length == count)
                {
                    var new_heap = new int[heap.Length * 2];
                    Array.Copy(heap, new_heap, heap.Length);
                    heap = new_heap;
                }
            }

            void RemoveMin()
            {
                heap[0] = heap[--count];
                int index = 0;

                while (true)
                {
                    int smallest_index = index;

                    var par = index * 4;

                    int child_index_1 = par + 1;
                    int child_index_2 = par + 2;
                    int child_index_3 = par + 3;
                    int child_index_4 = par + 4;

                    if (child_index_1 < count && heap[child_index_1] < heap[smallest_index])
                        smallest_index = child_index_1;

                    if (child_index_2 < count && heap[child_index_2] < heap[smallest_index])
                        smallest_index = child_index_2;

                    if (child_index_3 < count && heap[child_index_3] < heap[smallest_index])
                        smallest_index = child_index_3;

                    if (child_index_4 < count && heap[child_index_4] < heap[smallest_index])
                        smallest_index = child_index_4;

                    if (smallest_index == index)
                        break;

                    (heap[smallest_index], heap[index]) = (heap[index], heap[smallest_index]);
                    index = smallest_index;
                }
            }
        }
        public int MissingMultiple3(int[] nums, int k)
        {
            HashSet<int> arr = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % k == 0 && !arr.Contains(nums[i]))
                    arr.Add(nums[i]);
            }

            int output = int.MinValue;

            for (int i = k; i < int.MaxValue; i += k)
            {
                if (!arr.Contains(i))
                    return i;
            }

            return -1;
        }
        public int MissingMultiple4(int[] nums, int k)
        {
            int start = 1;
            while (nums.Contains(k * start))
                ++start;

            return k * start;
        }
        public int MissingMultiple5(int[] nums, int k)
        {
            HashSet<int> seen = nums.ToHashSet();
            for (int i = k; i <= 100_000; i += k)
            {
                if (!seen.Contains(i)) return i;
            }
            return -1;
        }
    }
}
