namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode ReverseBetween()// 0ms simulation time O(N) space O(1)
        {
            /*
             About this problem:-
                  In Linear series of nodes given, I need to reverse the elements in specific range (left,right)
                  only when the condition satisfied left <= right

             My approach:-
                1st attempted : failed due if(pre_pointer.next.val == left)  case: [3,5] left =1 right =2
                    Add dummy node in head, case[1,2] l=1,r=2 , it hard to swap while standing on same node. 
                    Two pointer: f pointer for point the left
                    and s pointer for limit the point of right
                    loop s < right
                    new copy linked node, range(left,right) and 
                    merge by using left.next = reversenode and reversenode.next= s.next
                    Key Idea:
                    Reverse a sublist of a linked list by manipulating node pointers within a specific range.
             
             */
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
         
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
     

            ListNode head = node1; int left = 2, right = 4;
            if (left >= right) return head; // head = [d,1,2,3,4,5], left = 2, right = 4

            ListNode dummyHead = new ListNode(0, head);
            ListNode pre_pointer = dummyHead;
            ListNode cur_pointer = dummyHead;

            ListNode? reverseList = null;

            for(int i =0; i < right;i++ ) // l =1 right=2    
            {
                if(pre_pointer.next != null && i >= left-1)
                {
                    ListNode newNode = new ListNode(cur_pointer.next.val, null);

                    if (reverseList == null)
                           reverseList =  newNode;
                    else
                    {
                        newNode.next = reverseList;
                        reverseList = newNode;
                    }
                }
                else
                {
                    pre_pointer = pre_pointer.next;
                }
                cur_pointer = cur_pointer.next;
            }
            pre_pointer.next = reverseList; // first half + reverse list


            if (pre_pointer != null) // get tail
            {
                while (pre_pointer.next != null) pre_pointer = pre_pointer.next;
            }

            pre_pointer.next = cur_pointer.next; // reverse list + second half


            return dummyHead.next;
        }
        public ListNode ReverseBetween1(ListNode head, int left, int right)
        {
            if (head == null || left == right)
                return head;

            ListNode dummy = new ListNode(0, head);

            ListNode prev = dummy;
            for (int i = 1; i < left; i++)
            {
                prev = prev.next;
            }

            ListNode curr = prev.next;

            for (int i = 0; i < right - left; i++)
            {
                ListNode temp = curr.next;
                curr.next = temp.next;
                temp.next = prev.next;
                prev.next = temp;
            }

            return dummy.next;
        }
        public ListNode ReverseBetween2(ListNode head, int left, int right)
        {

            // The new head is always the same unless left = 1.
            ListNode newHead = head;

            ListNode beforeLeft = null;
            ListNode afterRight = null;

            ListNode leftNode = null;
            ListNode rightNode = null;

            int currentPosition = 1; // 1 indexed instead of 0
            ListNode current = head;
            ListNode prev = null;

            // Find left node and find right node on first pass
            while (rightNode == null && current != null)
            {
                if (currentPosition == left)
                {
                    leftNode = current;
                    beforeLeft = prev;
                }
                if (currentPosition == right)
                {
                    rightNode = current;
                    afterRight = current.next;
                }

                // Advance by one node
                prev = current;
                current = current.next;
                currentPosition++;
            }

            Console.WriteLine($"left: {leftNode.val}, right: {rightNode.val}");

            // Reverse the sublist
            ListNode reversedHead = ReverseSubList(leftNode, rightNode);

            // Patch up the boundary links
            //
            // If beforeLeft is null then reversedHead is the new head of the list
            if (beforeLeft == null)
            {
                newHead = reversedHead;
            }
            else // Otherwise it is beforeLeft
            {
                beforeLeft.next = reversedHead;
            }

            // We know leftNode is now the right of the sub-list
            leftNode.next = afterRight;

            return newHead;
        }

        private static ListNode ReverseSubList(ListNode leftNode, ListNode rightNode)
        {
            ListNode current = leftNode;
            ListNode prev = null;

            while (prev != rightNode)
            {
                // Store the next node, and have it point at the current node
                ListNode tempNext = current.next;
                current.next = prev;

                // Advance the current and the prev
                prev = current;
                current = tempNext;
            }

            return rightNode;
        }
        public ListNode ReverseBetween3(ListNode head, int left, int right)
        {
            if (left == right) return head;

            ListNode dummy = new(0, head);
            var (before, end) = GetSegment(dummy, left, right);

            ListNode start = before.next;
            ListNode after = end.next;
            ListNode newHead = Reverse(start, after);

            //Reconnect
            before.next = newHead;

            return dummy.next;
        }

        (ListNode, ListNode) GetSegment(ListNode dummy, int left, int right)
        {
            ListNode before = dummy;
            ListNode curr = dummy.next;
            int count = 1;

            while (curr != null && count < right)
            {
                if (count < left)
                {
                    before = curr;
                }

                count++;
                curr = curr.next;
            }
            return (before, curr);
        }

        ListNode Reverse(ListNode start, ListNode after)
        {
            ListNode curr = start;
            ListNode prev = after;

            while (curr != after)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
        ListNode successor = null;
        ListNode ReverseN(ListNode head, int n)
        {
            if (n == 1)
            {
                successor = head.next;
                return head;
            }
            ListNode last = ReverseN(head.next, n - 1);
            head.next.next = head;
            head.next = successor;
            return last;
        }
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left <= 1)
            {
                return ReverseN(head, right - left + 1);
            }
            head.next = ReverseBetween(head.next, left - 1, right - 1);
            return head;
        }
    }
}
