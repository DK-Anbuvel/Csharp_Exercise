namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode SwapPairs()
        {

            /*
             About this problem:-
                Linked list dt problem, swap adjcent whole nodes not node values.
             My Approach:-
               attempt 1:-
                  Two pointer pattern, swap the node and point first pointer = secound pointer , secound pointer = current.next -> O(n) O(1)
                attempt 2:-
                   Recursion pattern,
            */
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            ListNode head = node1;

            if (head is null || head.next is null) return head;

            ListNode f_node = head;
            ListNode s_node = head.next; // pervious pointer

            while (s_node != null && s_node.next != null)
            {
                // store list
                ListNode tempList = s_node.next; 
                s_node.next = null;

                // swap
                ListNode tempNode = s_node; 
                s_node = f_node;
                f_node = tempNode;

                // merge
                f_node.next = tempList;

                // correct the position
                f_node = tempList;
                s_node = tempList != null ? tempList.next : null;// either val or null
            }
            return head; // head not modified.

        }
        public ListNode SwapPairs1()
        {

            /*
             About this problem:-
                Linked list dt problem, swap adjcent whole nodes not node values.
             My Approach:-
               attempt 1:-
                  Two pointer pattern, swap the node and point first pointer = secound pointer , secound pointer = current.next -> O(n) O(1)
                attempt 2:-
                   Recursion pattern,
            */
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            ListNode head = node1;

            if (head is null || head.next is null) return head;

            ListNode currentNode = head;

            while (currentNode != null && currentNode.next != null)
            {
                // store list
                ListNode tempList = currentNode.next.next;
                currentNode.next.next = null;

                // slip two
                ListNode tempNode2 = currentNode.next;
                currentNode.next = null;
                ListNode tempNode1 = currentNode;

                // swap
                currentNode = tempNode2;
                currentNode.next = tempNode1;

                // merge
                currentNode.next.next = tempList;

                // correct the position
                currentNode = currentNode.next.next;
            }
            return head; // head not modified.

        }
    }
}
