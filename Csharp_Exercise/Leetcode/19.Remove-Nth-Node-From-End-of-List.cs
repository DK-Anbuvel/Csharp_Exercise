namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            /*
             about this problem:-
                 need to nth node of the given list 

             my approach:-

               attempt 1: failed due to understating nth node from the end of the list.
                  literate the list node in nth time and then companies the n+1th node.
               attempt 2:
                    two pointer(a,b) , here a travel in 1 by 1 and b travel n by n until reach the null.
                    if reached null remove a + 1 element.
             Edge case:-
                 
                case 1 : [1,2] n=1
                    here need output [1] about approach when b can't maintain n size
                    so used dummy node in forent of head.

            */
            ListNode currentNode = head;
            while (currentNode.next != null && n > 0)
            {

                if (n == 1)
                {
                    if (currentNode.next.next != null)
                        currentNode.next = currentNode.next.next;
                    else
                        currentNode.next = null;

                    return head;
                }

                currentNode = currentNode.next;
                n--;
            }
            return null;
        }

        public ListNode RemoveNthFromEnd1(ListNode head, int n) //0 ms Two pointers  time O(n) space O(1)
        {   //head = [d,1,2,3,4,5], n = 2
            //head = [d,1,2,3,4], n = 2
            //head = [d,1], n = 1
            //head = [d,1,2], n = 1
            //head = [d,1,2,4,5], n = 2


            ListNode dummyNode = new ListNode(0, head);
            ListNode previousNode = dummyNode;
            ListNode currentNode = dummyNode;

            for (int j = 0; j < n && currentNode.next != null; j++) // to set initial gap
            {
                currentNode = currentNode.next;
            }

            while (previousNode != null)
            {             
                if (currentNode.next == null)
                {
                    if (previousNode.next.next != null)
                        previousNode.next = previousNode.next.next;
                    else
                        previousNode.next = null;

                    return dummyNode.next;
                }
                previousNode = previousNode.next;
                currentNode = currentNode.next;
            }

            return dummyNode.next;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            int length = 0;
            ListNode dummy = new(0, head);
            ListNode prev = dummy;

            while (head is not null)
            {
                length++;
                head = head.next;
            }

            int position = 1;
            head = dummy.next;
            while (position < length - n + 1)
            {
                prev = head;
                head = head.next;
                position++;
            }

            prev.next = head.next;
            return dummy.next;
        }
        public ListNode RemoveNthFromEnd3(ListNode head, int n)
        {
            ListNode dummy = new(0, head);
            ListNode first = dummy, second = dummy;

            // Move first pointer n+1 steps ahead to maintain a gap of n between first and second
            for (int i = 0; i < n + 1; i++)
            {
                if (first == null)
                    return head; // n is larger than the length of the list, no removal

                first = first.next!;
            }

            // Move both pointers until first reaches the end
            while (first != null)
            {
                first = first.next;
                second = second.next!;
            }

            // second is now at the node before the one we want to remove
            second.next = second.next!.next;
            return dummy.next;
        }
        public ListNode RemoveNthFromEnd4(ListNode head, int n)
        {
            ListNode slow = head;
            ListNode fast = head;
            int counter = 0;

            while (fast.next != null)
            {
                fast = fast.next;
                counter++;
                if (counter >= n + 1)
                {
                    slow = slow.next;
                }
            }
            if (slow == head && counter < n)
            {
                return head.next;
            }
            if (slow.next != null)
            {
                slow.next = slow.next.next;
            }
            else
            {
                slow = null;
            }
            return head;
        }
        public ListNode RemoveNthFromEnd5(ListNode head, int n)
        {

            Stack<ListNode> stack = new();
            ListNode curr = head;
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.next;
            }
            ;
            int counter = 1;
            int slen = stack.Count;
            if (n > slen)
            {
                return null;
            }
            if (n == slen)
                return head.next;

            ListNode tempnode = null;
            while (stack.Count > 0)
            {
                Console.WriteLine($"{counter}");
                var loopNode = stack.Pop();
                if (counter == n - 1)
                {
                    tempnode = loopNode;
                }
                if (counter == n + 1)
                {
                    loopNode.next = tempnode;
                }
                if (counter == slen)
                {
                    head = loopNode;
                }
                counter++;
            }
            return head;
        }
    }
}
