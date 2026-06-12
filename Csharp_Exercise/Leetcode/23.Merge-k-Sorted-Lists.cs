namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            /*
               About this problem:-
                  Here array of sorted link list given, need return single sorted linked list.

               My approach:-

               attempt 1:- failed
                   first merge all list in single list bcz easy merge the list --> O(lists.Length)
                   then
                   linear sort, take node iterate throughout all nodes ---> o(n^2)
                   Here the problem, In two loop, how inter loop once complete 1 loop, how again start from 0th index ?
                
               attempt 2:- divided and conquer /Heap (Priority Queue)
            */

            if (lists.Length < 1) return null;
            if (lists.Length == 1) return lists[0];

            ListNode SingleSortedList = lists[0];
            ListNode MergeList = SingleSortedList;
            ListNode OuterIterateList = SingleSortedList;
         //   ListNode OuterIterateList = SingleSortedList;

            int listCode = lists.Length;
            for(int i = 1; i < listCode - 1; i++)
            {
                MergeList.next = lists[i];
                MergeList = MergeList.next;
            }

            //while(IterateList != null)
            //{
            //    int currentVal = IterateList.val;

            //}
            return lists[0];

        }
        public ListNode MergeKLists1(ListNode[] lists) // 3 ms time O(N log K) space O(logK)
        {

            if (lists == null || lists.Length == 0)
                return null;

            return mergeListHelper(lists, 0, lists.Length - 1); // this method for control the recursion.

        }
        private ListNode mergeListHelper(ListNode[] lists, int start,int end) // 
        {
            if (start == end) // purpose only one list exist. ---> odd count
                return lists[start];

            if(start+1 == end) // only 2 lists exist    ---> even count
                return merge2Lists(lists[start], lists[end]);

            int mid = start + (end - start) / 2; // 0 + (2-0) / 2 = 1
            ListNode left = mergeListHelper(lists, start, mid); // recursion for left side until 
            ListNode right = mergeListHelper(lists, mid+1,end);
            return merge2Lists(left, right);
        }
        private ListNode merge2Lists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;

            while(l1 != null && l2 != null) // loop list until in same size
            {
                if(l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            current.next = (l1 != null) ? l1 : l2; // add remaining sorted list

            return dummy.next; // return current head node
        }
        public ListNode MergeKLists2(ListNode[] lists)
        {
            if (lists.Length == 0) { return null; }
            if (lists.Length == 1) { return lists[0]; }

            var sp = lists;

            ListNode p1, p11;
            ListNode p2;
            ListNode p;
            int mid = (lists.Length - 1) / 2;
            int n = lists.Length;
            while (n > 1)
            {
                for (int i = 0, j = n - 1; i <= mid && i < j; i++, j--)
                {
                    if (sp[j] == null) { continue; }
                    if (sp[i] == null)
                    {
                        sp[i] = sp[j];
                        continue;
                    }

                    if (sp[i].val > sp[j].val)// first list .value > second list .value
                    {
                        p = sp[i];
                        sp[i] = sp[j];
                        sp[j] = p;
                    }
                    p1 = sp[i];
                    p2 = sp[j];
                    p11 = sp[i];
                    while (true)
                    {
                        if (p1 == null)
                        {
                            p11.next = p2;
                            break;
                        }
                        else if (p2 == null)
                        {
                            break;
                        }
                        else
                        {
                            if (p1.val > p2.val)
                            {
                                p = p2;
                                p2 = p2.next;
                                p.next = p11.next;
                                p11.next = p;
                            }
                            else
                            {
                                p = p1;
                                p1 = p1.next;
                            }
                            p11 = p;
                        }
                    }
                }
                n = mid + 1;
                mid = (n - 1) / 2;
            }
            return sp[0];
        }

        public ListNode MergeKLists3(ListNode[] lists)
        {
            if (lists == null || lists.Count() == 0) return null;

            PriorityQueue<ListNode, ListNode> pq = new PriorityQueue<ListNode, ListNode>(Comparer<ListNode>.Create((a, b) => a.val - b.val));

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                    pq.Enqueue(lists[i], lists[i]);
            }

            ListNode dummy = new ListNode();//  pq.Dequeue();
            ListNode cur = dummy;

            while (pq.Count > 0)
            {
                ListNode n = pq.Dequeue();
                cur.next = n;
                cur = n;
                if (n.next != null)
                {
                    pq.Enqueue(n.next, n.next);
                }
            }

            return dummy.next;

        }
        public ListNode MergeKLists4(ListNode[] lists)
        {
            ListNode dummy = new();
            ListNode tail = dummy;
            while (true)
            {
                int mins = int.MaxValue;
                int currPos = -1;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        if (lists[i].val <= mins)
                        {
                            mins = lists[i].val;
                            currPos = i;
                        }
                    }
                }
                if (currPos == -1)
                    break;
                tail.next = lists[currPos];
                tail = tail.next;
                lists[currPos] = lists[currPos].next;
            }
            return dummy.next;
        }
    }
}
