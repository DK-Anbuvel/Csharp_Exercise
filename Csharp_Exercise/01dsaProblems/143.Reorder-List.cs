namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public void ReorderList() // time O(n) space O(1)
        {
            /*
            About this Problem:-
               Single linked list , need to reorder and return the head

            My Approach:-

                attempt 1:-
                  store the linklist in array ---> O(n) extra memory
                  Two pointer iterated    --> O(n/2) -> O(nLogn) time
                  create new reordered list --> O(n) extra memory 
             
                attempt 2:-
                   Formate : L0 - Ln - L1 - Ln-1
                   find the middle node --> slow & fast pointer method
                   Reverse the second half --> 
                   iterate the two pointers
                   Reorder in existing head
            */

            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);

            node1.next = node2;
            node2.next = node3;
            //node3.next = node4;
           // node4.next = node5;
            //node5.next = node6;


            ListNode head = node1;

            // base validation ( more then > 2 nodes)
            if (head.next == null || head.next.next == null) 
                return;

            // Middle point 
            ListNode slow_p = head;
            ListNode fast_p = head;

            while(fast_p != null && fast_p.next != null) // O(logn)
            {
                slow_p= slow_p.next;
                fast_p = fast_p.next.next;
            }

            // Reverse the second half
            ListNode reverseList = null;
            ListNode curr = slow_p;
            ListNode next= null;

            while(curr != null)  // O(logn)
            {
                next = curr.next;
                curr.next = reverseList;
                reverseList = curr;
                curr = next;
            }

            // Reorder the List
            ListNode OrderList = head;
            ListNode p1_temp = null; // 1 2 3   1   2 3  /  1 3 2 
            ListNode p2_temp = null; // 1 2 3 4 5 6   1 2 3  6 5 4  /  1 6 2 5 3 4  

            while (OrderList.next != reverseList && OrderList != reverseList) // odd and even  // O(logn)
            {

                p1_temp = OrderList.next;
                p2_temp = reverseList.next;

                OrderList.next = reverseList;
                OrderList.next.next = p1_temp;

                OrderList = OrderList.next.next;
                reverseList = p2_temp; 
            }

        }

        public void ReorderList1(ListNode head)
        {
            var st = new Stack<ListNode>();
            var curr = head;
            while (curr != null)
            {
                st.Push(curr);
                curr = curr.next;
            }

            curr = head;
            if (curr.next == null)
            {
                return;
            }
            var next = head.next;

            while (curr != null && next != null && st.Count > 0 && !(curr == st.Peek() || next == st.Peek()))
            {
                var tos = st.Pop();
                curr.next = tos;
                tos.next = next;
                curr = next;
                next = next.next;
            }
            if (curr == st.Peek())
            {
                curr.next = null;
            }
            if (next == st.Peek())
            {
                next.next = null;
            }
            return;
        }
        public void ReorderList2(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return;
            }
            LinkedList<ListNode> deque = new LinkedList<ListNode>();
            ListNode current = head;
            while (current != null)
            {
                deque.AddLast(current);
                current = current.next;
            }
            ListNode dummy = new ListNode(-1);
            while (deque.Count > 1)
            {
                dummy.next = deque.First.Value;
                deque.RemoveFirst();
                dummy = dummy.next;
                dummy.next = deque.Last.Value;
                deque.RemoveLast();
                dummy = dummy.next;
            }
            if (deque.Count == 1)
            {
                dummy.next = deque.First.Value;
                dummy = dummy.next;
            }
            dummy.next = null;
        }
        public void ReorderList3(ListNode head)
        {
            ListNode splitListHead = SplitHalf(head);
            //PrintList(head);

            //PrintList(splitListHead);
            ListNode reversedHalfHead = Reverse(splitListHead);
            //PrintList(reversedHalfHead);
            MergeAlternates(head, reversedHalfHead);
        }

        private void PrintList(ListNode node)
        {
            Console.WriteLine("Printing list-----------");
            ListNode current = node;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }


        private void MergeAlternates(ListNode head, ListNode reversedHalfHead)
        {
            ListNode current = head;
            while (current != null && reversedHalfHead != null)
            {
                ListNode next = current.next;
                current.next = reversedHalfHead;

                ListNode reversedHalfHeadNext = reversedHalfHead.next;
                reversedHalfHead.next = next;
                reversedHalfHead = reversedHalfHeadNext;
                current = next;
            }

        }
        private ListNode Reverse(ListNode head)
        {
            ListNode next = null, prev = null, current = head;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
        private ListNode SplitHalf(ListNode head)
        {
            int count = 0;
            ListNode current = head, prev = null;
            while (current != null)
            {
                count++;
                current = current.next;
            }

            current = head;
            int currentCount = 0;
            while (currentCount <= (count / 2))
            {
                prev = current;
                current = current.next;
                currentCount++;
            }

            prev.next = null;
            ListNode newHead = current;
            return newHead;
        }
    }
}
