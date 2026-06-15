namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode DeleteDuplicatesII() // time O(n) space O(1)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(2);
            var node4 = new ListNode(2);
            var node5 = new ListNode(3);
            var node6 = new ListNode(3);
            var node7 = new ListNode(4);
            node1.next = node2;
            node2.next = node3; 
            node3.next = node4; 
            node4.next = node5; 
            node5.next = node6; 
            node6.next = node7;

            ListNode head = node1;
            /*
             About the problem:-
                 minimum time complexity = need to check a least one's in the all node O(n).

             my Approach:-
                  Two Pointers:-
                     first pointer n[dummyNode] and second pointer n[0]


            */
            if (head == null || head.next == null) return head;

            ListNode DistinctNodes = new ListNode(0, head);

            ListNode p_node = DistinctNodes;
            ListNode c_node = DistinctNodes.next; // [d,1,2,2,2,3,3,4] 

            while (c_node != null)
            {
                if (c_node.next != null && c_node.val == c_node.next.val)
                {
                    while (c_node.next != null && c_node.val == c_node.next.val)
                    { c_node = c_node.next; }

                    p_node.next = c_node.next;// magic is here (only assign happening there) 
                }else
                    p_node = p_node.next;  // only moves when not duplicate val

                c_node = c_node.next;
            }
            return DistinctNodes.next;
        }

        public ListNode DeleteDuplicatesII1(ListNode head)
        {
            Dictionary<int, int> freq = new();
            ListNode curr = head;
            while (curr != null)
            {
                freq[curr.val] = freq.GetValueOrDefault(curr.val, 0) + 1;
                curr = curr.next;
            }

            ListNode dummy = new();
            ListNode tail = dummy;
            curr = head;
            while (curr != null)
            {
                if (freq[curr.val] == 1)
                {
                    tail.next = curr;
                    tail = tail.next;
                }
                curr = curr.next;
            }

            tail.next = null;
            return dummy.next;
        }
        public ListNode DeleteDuplicatesII2(ListNode head)
        {
            var current = head;
            Dictionary<int /*number in question*/, int /*count*/> seen = new(); // 1,2,3,4,
            Stack<int> result = new(); // 1,2,4
            while (current != null)
            {
                if (seen.TryAdd(current.val, 0))
                {

                    result.Push(current.val);

                }
                else
                {
                    seen[current.val]++;
                    if (seen[current.val] <= 1)
                        result.TryPop(out _);
                }
                current = current?.next;
            }



            ListNode resultRoot = new();
            current = resultRoot;
            var resultArray = result.ToArray();
            for (int i = resultArray.Length - 1; i >= 0; i--)
            {
                current.next = new(resultArray[i]);
                current = current.next;

            }
            return resultRoot.next;

        }
        public ListNode DeleteDuplicatesII3(ListNode head)
        {
            var seen = new HashSet<int>();
            var twice = new HashSet<int>();

            var tempHead = head;
            while (tempHead != null)
            {
                if (!seen.Contains(tempHead.val))
                {
                    seen.Add(tempHead.val);
                }
                else
                {
                    twice.Add(tempHead.val);
                }
                tempHead = tempHead.next;
            }

            var dummyHead = new ListNode(-1);
            var currentTail = dummyHead;

            tempHead = head;
            while (tempHead != null)
            {
                if (!twice.Contains(tempHead.val))
                {
                    currentTail.next = new ListNode(tempHead.val);
                    currentTail = currentTail.next;
                }
                tempHead = tempHead.next;
            }
            return dummyHead.next;
        }
    }
}
