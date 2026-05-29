namespace Csharp_Exercise
{
    public partial class Leecodes
    {
       public class MyHashSet  // 12 ms
        {
            /*
              About this problem:-
                   build your own HashSet class from scratch, without using C# built-in HashSet<int> or Dictionary.

              My Approach:-
                  Use constructor for inizise for hash set;
            */
                public int[] arr; // Array value type and stack memory (fast access) sounds fine.
                                  // but in curd, 
                /*
                  insert -- need to maintain the index position
                  update -- find the position o(n) and update o(1) -- O(n)
                  remove -- problem start here, find the position, update the value 
                 */
                public MyHashSet()
                {
                    arr = new int[1000001];  // 10 ^ 6 = 1000000 + 1 bcz array index start with 0
                    arr[0] = -1; // scenario: 0 not inserted by when call by contains(0) it return true;
                }
                public void Add(int key)
                {
                    if (arr[key] != key) // arr[1000000] = 1000000 Exception: index out bound exception
                        arr[key] = key; // arr[0] = 0 Exception: failed bcz by default array stored all value as 0 
                }
                public void Remove(int key)
                {
                    if (arr[key] == key)
                        arr[key] = 0; // for remove value change as 0 instead of null ,bcz int is non-nullable value type.
                }
                public bool Contains(int key)
                {
                    if (arr[key] == key)
                        return true;
                    else
                        return false;
                }
            }
        /**
         * Your MyHashSet object will be instantiated and called as such:
         * MyHashSet obj = new MyHashSet();
         * obj.Add(key);
         * obj.Remove(key);
         * bool param_3 = obj.Contains(key);
         */

        public class MyHashSet1
        {
            //List<int> hashSet = new List<int>();
            private bool[] set = new bool[1];

            public MyHashSet1()
            {

            }

            public void Add(int key)
            {
                //if (!this.Contains(key))
                //{
                //    this.hashSet.Add(key);
                //}
                if (key >= set.Length)
                {
                    Array.Resize(ref set, key + 1);
                }

                set[key] = true;
            }

            public void Remove(int key)
            {
                //this.hashSet.Remove(key);
                if (key < set.Length)
                {
                    set[key] = false;
                }
            }

            public bool Contains(int key)
            {
                //return this.hashSet.Contains(key);
                if (key < set.Length)
                {
                    return set[key];
                }

                return false;
            }
        }
        public class MyHashSet2
        {

            private bool[] list;

            public MyHashSet2()
            {
                list = new bool[1000001];
            }

            public void Add(int key)
            {
                list[key] = true;
            }

            public void Remove(int key)
            {
                list[key] = false;
            }

            public bool Contains(int key)
            {
                return list[key];
            }
        }
        public class MyHashSet3
        {
            bool[] set;
            int setSize;
            public MyHashSet3()
            {
                setSize = 1000;
                set = new bool[setSize];
            }

            public void Add(int key)
            {
                if (key >= setSize)
                {
                    resize();
                    Add(key);
                    return;
                }
                int index = hashFn(key);
                if (set[index] && key != index)
                {
                    resize();
                    Add(key);
                    return;
                }
                else
                {
                    //Console.WriteLine($"key {key} index {index}");
                    set[index] = true;
                }
            }

            public void Remove(int key)
            {
                int index = hashFn(key);
                set[index] = false;
            }

            public bool Contains(int key)
            {
                int index = hashFn(key);

                return key < setSize && key == index && set[index];
            }

            public int hashFn(int key)
            {
                return key % setSize; //remainder
            }

            public void resize()
            {

                bool[] newSet = new bool[setSize * 2];
                for (int i = 0; i < set.Length; i++)
                {
                    newSet[i] = set[i];
                }
                setSize = setSize * 2;
                set = newSet;
            }
        }
        public class MyHashSet4
        {
            private List<int>[] buckets;

            public MyHashSet4()
            {
                buckets = new List<int>[100];
            }

            public void Add(int key)
            {
                if (Contains(key)) return;

                int hash = key % 100;

                if (buckets[hash] == null)
                {
                    buckets[hash] = new List<int>();
                }

                buckets[hash].Add(key);
            }

            public void Remove(int key)
            {
                int hash = key % 100;

                if (buckets[hash] == null) return;

                for (int i = 0; i < buckets[hash].Count; i++)
                {
                    if (buckets[hash][i] == key)
                    {
                        buckets[hash].RemoveAt(i);
                        break;
                    }
                }
            }

            public bool Contains(int key)
            {
                int hash = key % 100;

                if (buckets[hash] == null) return false;

                for (int i = 0; i < buckets[hash].Count; i++)
                {
                    if (buckets[hash][i] == key)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        public class MyHashSet5
        {
            private readonly Bucket[] buckets;
            public MyHashSet5()
            {
                buckets = new Bucket[100];
            }

            public void Add(int key)
            {
                int index = GetBucketIndex(key);
                Bucket head = buckets[index];
                if (head == null)
                {
                    buckets[index] = new Bucket(key);
                    return;
                }

                Bucket curr = head, prev = null;
                while (curr != null)
                {
                    if (curr.key == key)
                    {
                        return;
                    }
                    prev = curr;
                    curr = curr.next;
                }
                prev.next = new Bucket(key);
            }

            public void Remove(int key)
            {
                int index = GetBucketIndex(key);
                Bucket head = buckets[index];
                Bucket curr = head, prev = null;
                while (curr != null)
                {
                    if (curr.key == key)
                    {
                        // remove head
                        if (curr == head)
                        {
                            buckets[index] = head.next;
                        }
                        else
                        {
                            prev.next = curr.next;
                        }
                        return;
                    }
                    prev = curr;
                    curr = curr.next;
                }
            }

            public bool Contains(int key)
            {
                int index = GetBucketIndex(key);
                Bucket head = buckets[index];
                Bucket curr = head;
                while (curr != null)
                {
                    if (curr.key == key)
                    {
                        return true;
                    }
                    curr = curr.next;
                }
                return false;
            }

            private int GetBucketIndex(int key)
            {
                return key % buckets.Length;
            }
        }

        public class Bucket
        {
            public int key { get; set; }
            public Bucket next { get; set; }

            public Bucket(int k)
            {
                key = k;
            }
        }
        public class MyHashSet6
        {
            List<int> nums = new List<int>();

            public MyHashSet6()
            {

            }

            public void Add(int key)
            {
                int idx = 0;
                for (; idx < nums.Count; idx++)
                {
                    if (nums[idx] == key) break;
                    else if (nums[idx] > key)
                    {
                        nums.Insert(idx, key);
                        break;
                    }
                }
                if (idx == nums.Count)
                {
                    nums.Insert(idx, key);
                }
            }

            public void Remove(int key)
            {
                for (int idx = 0; idx < nums.Count; idx++)
                {
                    if (nums[idx] == key)
                    {
                        nums.RemoveAt(idx);
                        break;
                    }
                }
            }

            public bool Contains(int key)
            {
                for (int idx = 0; idx < nums.Count; idx++)
                {
                    if (nums[idx] == key)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
