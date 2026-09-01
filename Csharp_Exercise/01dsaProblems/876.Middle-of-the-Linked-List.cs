namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode MiddleNode()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            //node5.next = node6;
            ListNode head = node1;

            int c = getNodeCode(head);

            return getNodeByPosition(head, c / 2);


        }
        public int getNodeCode(ListNode head)
        {
            ListNode temp = head;
            int nodeCount = 1;
            while (temp.next != null)
            {
                nodeCount++;
                temp = temp.next;

            }
            return nodeCount;
        }
        public ListNode getNodeByPosition(ListNode head, int position)
        {
            ListNode temp = head;
            while (temp.next != null && position != 0)
            {
                temp = temp.next;
                position--;
            }
            return temp;
        }
        public ListNode MiddleNode1(ListNode head)
        {
            /*
              About this problem:-
                  Here head list was given , neet return the secound part of the list.
                  hint: return the second middle node. so easy to split by using n/2.

             My Approach:- failed wrong logic, let as 1- 100 , here pointer continuously move forward with 2 node gap 98 -> 100, it not like middle.
                   attempt 1: get list node count/ split and return. time O(n)
                   attempt 2: Two pointer / 1st pointer point head / 2nd pointer maintain 2 node gap
                              edge case: [1] , [1,2]
                   attempt 3: same Two pointer / now this time try slow(1x) and fast(2x) pointer method.

            */

            if (head.next == null) return head;
            if (head.next.next == null) return head.next;

            ListNode f_p = head;
            ListNode s_p = head;

            for (int i = 0; i < 2; i++) s_p = s_p.next;

            while (s_p.next != null)
            {
                f_p = f_p.next;
                s_p = s_p.next;
            }

            return f_p.next;

        }
        public ListNode MiddleNode2(ListNode head)
        {

            ListNode fast_p = head;
            ListNode slow_p = head;

            while (fast_p != null && fast_p.next != null)
            {
                slow_p = slow_p.next;

                fast_p = fast_p.next.next;
            }

            return slow_p;

        }
    }
}
