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
               attempt 1:- failed due to losing control over pointer.  solution dummy node in head.
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
        public ListNode SwapPairs2()
        {

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


            ListNode dummyList =  new ListNode(-1,head); // d,1,2,3,4
            ListNode currentNode = dummyList;

            while (currentNode.next != null && currentNode.next.next != null) //currentNode != null (not need, bcz i standing one step pervious node from the actual node)
            {
                // store list
                ListNode Node1 = currentNode.next;
                ListNode Node2 = currentNode.next.next;

                // swap
                Node1.next = Node2.next;
                Node2.next = Node1;

                // change the position
                currentNode.next = Node2;
                currentNode = Node1;

            }
            return dummyList.next; // head not modified.

        }
        public ListNode SwapPairs3(ListNode head)
        {
            ListNode dummyHead = new()
            {
                next = head
            };
            var curr = dummyHead;
            while (curr.next?.next is not null)
            {
                ListNode n1 = curr.next;
                ListNode n2 = n1.next;
                ListNode restOfList = n2.next;

                curr.next = n2;
                n2.next = n1;
                n1.next = restOfList;

                curr = curr.next.next;
            }

            return dummyHead.next;
        }

        public ListNode SwapPairs4(ListNode head)
        {

            if (head == null) return null;

            if (head.next == null) return head;

            ListNode dummy = new();
            dummy.next = head;

            ListNode p1 = dummy;
            ListNode p2 = head;
            ListNode p3 = head.next;
            while (p1.next != null && p2.next != null)
            {
                Console.WriteLine($"p1.val {p1.val}");
                p1.next = p3;
                p2.next = p3.next;
                p3.next = p2;
                p1 = p2;
                Console.WriteLine($"p1.val {p1.val}");
                if (p1.next != null)
                {
                    p2 = p1.next;
                    if (p2.next != null)
                    {
                        p3 = p2.next;
                    }
                }
            }

            return dummy.next;
        }
        public ListNode SwapPairs5(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            head.next.next = SwapPairs5(head.next.next);
            ListNode current = head.next;
            ListNode Save = current.next;
            current.next = head;
            head.next = Save;
            head = current;
            return head;
        }
        public ListNode SwapPairs6(ListNode head)
        {
            if (head == null || head.next == null) 
                return head;

            var left = head;
            var right = head.next;

            left.next = SwapPairs6(right.next);
            right.next = left;

            return right;
        }
    }
}
