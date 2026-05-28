namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode ReverseList()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node2.next = node1;
            node3.next = node2;
            node4.next = node3;
            node5.next = node4;


            ListNode head = node5;
            /*
              About the problem:-
                Reverse order list node

              My Approach:-

                 To reverse the list,
                  first need to go tail of the node -- O(n)
                  then --> how loop backward order to get pervious value ? so new listnode and iterate while add new listnode it follow First-in Last-Out reverse
                    make new List node --O(n)
                    or
                    store in existing then set to head --O(n)
                    or 
                    To reverse list simply insert the node in list head.
            */

            if (head == null || head.next == null) return head;

            ListNode reverseList = new(); // head node
            ListNode currentNode = reverseList; 

            while (head != null)
            {
                //if(currentNode == null) currentNode = new ListNode(head.val, null);
                //currentNode.next = new ListNode(head.val, null);    if will create same as a copy
                //currentNode = currentNode.next;
                reverseList.next = new ListNode(head.val, reverseList.next); // insert in head node

                head = head.next;
            }
            return reverseList.next;
        }
        public ListNode ReverseList2(ListNode head)
        {
            if (head == null)
                return null;

            var res = ReverseListHelper(head);
            return res.Head;
        }

        private (ListNode Tail, ListNode Head) ReverseListHelper(ListNode head)
        {
            if (head.next == null)
                return (head, head);

            var res = ReverseListHelper(head.next);
            head.next = null;
            res.Tail.next = head;

            return (head, res.Head);
        }
        public ListNode ReverseList3() //nested method with recursion.
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node2.next = node1;
            node3.next = node2;
            node4.next = node3;
            node5.next = node4;


            ListNode head = node2;
            if (head == null)
                return head;
            ListNode newHead = new(); // create new linked list.
            Reverse(head);

            ListNode Reverse(ListNode headNode) //Go down → reach last node → come back → connect nodes
            { // 5 -> 4 -> 3 -> 2 -> 1 -> null
                ListNode current = new ListNode(headNode.val);
                if (headNode.next == null)
                {
                    newHead = current;
                    return current;
                }

                ListNode prev = Reverse(headNode.next);
                prev.next = current;
                return current;
            }

            return newHead;
        }
        public ListNode ReverseList4(ListNode head)
        {
            var pointer = head;
            var list = new List<int>();
            while (pointer != null)
            {
                list.Add(pointer.val);
                pointer = pointer.next;
            }
            list.Reverse();
            var mainreverse = new ListNode();
            var reverse = mainreverse;

            if (list.Count() == 0)
            {
                return null;
            }

            for (var i = 0; i <= list.Count() - 1; i++)
            {
                while (true)
                {
                    if (reverse.next == null)
                    {
                        reverse.val = list[i];
                        if (i + 1 < list.Count())
                        {
                            reverse.next = new ListNode();
                        }
                        break;
                    }
                    reverse = reverse.next;
                }
            }

            return mainreverse;
        }
        public ListNode ReverseList(ListNode head)
        {

            if (head == null || head.next == null)
                return head;

            ListNode curr = head;
            Stack<int> temp = new Stack<int>();

            while (curr.next != null)
            {
                temp.Push(curr.val);
                curr = curr.next;
            }

            temp.Push(curr.val);

            ListNode resultHead = new ListNode(temp.Pop());
            ListNode tail = resultHead;

            while (temp.Count > 0)
            {
                if (temp.Count != 0)
                {
                    tail.next = new ListNode(temp.Pop());
                    tail = tail.next;
                }
            }

            return resultHead;
        }
        public ListNode ReverseList5(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            ListNode next = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;

        }
    }
}
