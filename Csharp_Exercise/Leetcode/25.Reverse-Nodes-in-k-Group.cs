namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode ReverseKGroup()// time O(nxk) space O(K) 
        {
            /*
            About this problem:-
              Give the list, I check each node , if multiple by k ,then only reverse this part

            My approach:-

            attempt 1: Two pointer pattern --> O(N) O(1) failed due to maintain the position.
                Both fPointer & sPointer -> secound pointer each time until sPointer.value % k ==0
                then call reverse function input as fPointer.
                Once it return, then set fPointer and sPointer 
                continue until sPointer == null.
                head = reverse(fPointer); // it return the head of reverse list
                     // need to tail and join the temp !

            attempt 2:- logic failed
                 same attempt 1 logic but store return in new link list --> O(n) O(n)

            attempt 3:- understanding failed - split not based on K multiple if (sPointer.val % k == 0) [1,2,2,2,3,4,5] , K is no. of group 
                 same as attempt 1 and 2 -> split,reverse (get tail),merge

            Suggested complexity:O(N)
            Suggestions: Reverse pointers in-place to achieve O(1) space and avoid creating new nodes.
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

            // head = [1,2,3,4,5], k = 2

            ListNode head = node1;
            int k = 2;

            if (head.next == null) return head;
            int groupCount = 0;
            ListNode fPointer = head;
            ListNode sPointer = head;
            ListNode reverseList= new(0);
            ListNode currentReverseList = reverseList;
            while (sPointer != null)
            {
                ++groupCount;

                if (k == groupCount)
                {
                    currentReverseList.next = ReverseKGroup_Reverse(fPointer, sPointer);

                    while (currentReverseList.next != null)
                        currentReverseList = currentReverseList.next;

                    fPointer = sPointer.next;
                    groupCount = 0;
                }
                sPointer = sPointer.next;
               
            }
            if (groupCount >0)
                currentReverseList.next = fPointer;

            return reverseList.next;
            
        }
       
        private ListNode ReverseKGroup_Reverse(ListNode head, ListNode tail)
        {
            ListNode reverseList = null;

            while (head != null)
            {
                reverseList = new ListNode(head.val, reverseList);

                if (head == tail)
                    break;

                head = head.next;
            }

            return reverseList;
        }
        public ListNode ReverseKGroup1(ListNode head, int k)
        {
            // Edgecase: What if the give linked list is empty.
            // Edgcase: What if the grouping count is 1.
            if (head == null || k == 1)
                return head;

            // Edgcase: It is gaurenteed that k < length of linked list.

            ListNode current = head;
            ListNode nextNode = null;
            ListNode prevNode = null;

            while (current != null)
            {
                ListNode kthNode = GetKthNode(current, k);

                if (kthNode == null)
                {
                    // Only when we have done grouping, patch the remaining elements.
                    if (prevNode != null)
                        prevNode.next = current;
                    break;
                }

                // Preserve the next node.
                nextNode = kthNode.next;
                // Break the link to make it elible for reversal.
                kthNode.next = null;

                // Kth node will become head node.
                // current will become tail node.
                ReverseLinkedList(current);

                // Handling special case for first group to update the head!
                if (current == head)
                {
                    head = kthNode;
                }
                else
                {
                    // For successive group, tail node of previous group to current head node.
                    prevNode.next = kthNode;
                }

                // Preserve the tail node of previous group for linking.
                prevNode = current;

                // Move to the starting point of next group.
                current = nextNode;
            }

            return head;
        }

        private static ListNode GetKthNode(ListNode current, int k)
        {
            k--;

            while (current != null && k > 0)
            {
                current = current.next;
                k--;
            }

            return current;
        }

        private static void ReverseLinkedList(ListNode groupHead)
        {
            ListNode prev = null;

            while (groupHead != null)
            {
                ListNode nextNode = groupHead.next;
                groupHead.next = prev;

                prev = groupHead;
                groupHead = nextNode;
            }
        }
        public ListNode ReverseKGroup2(ListNode head, int k)
        {

            if (k == 1 || k == 0)
                return head;

            var totalNodes = CountNodes(head);
            var possibleCombination = Math.Floor(Convert.ToDouble(totalNodes / k));
            double tempCount = possibleCombination;

            ListNode finalListNode = null;
            ListNode iteratorNode = null;
            ListNode tempNode = null;
            ListNode prevNode = head;
            while (tempCount > 0)
            {
                head = ReverseListNode(head, k, ref prevNode, ref tempNode);
                for (int i = 0; i < k; i++)
                {
                    if (finalListNode == null)
                    {
                        iteratorNode = finalListNode = tempNode;
                        //PrintLinkedList(finalListNode);
                    }
                    else
                    {
                        iteratorNode.next = tempNode;

                        iteratorNode = iteratorNode.next;
                        //PrintLinkedList(finalListNode);
                    }

                    tempNode = tempNode.next;
                }


                tempCount--;
            }

            return finalListNode;
        }

        public int CountNodes(ListNode head)
        {
            int iCount = 0;
            while (head != null)
            {
                iCount++;
                head = head.next;
            }

            return iCount;
        }

        public ListNode ReverseListNode(ListNode listNode, int iCount, ref ListNode prevNode, ref ListNode headNode)
        {
            iCount = iCount - 1;
            ListNode next = listNode.next;

            var prev = prevNode;

            while (iCount > 0)
            {
                listNode.next = next.next;
                next.next = prev;
                prev = next;
                next = listNode.next;
                //listNode=prev.next;      
                iCount--;
            }

            //PrintLinkedList(prev);

            prevNode = next;
            headNode = prev;

            return next;
        }
        public ListNode ReverseKGroup3(ListNode head, int k)
        {
            if (head == null || k <= 1)
            {
                return head;
            }

            var dummy = new ListNode(0, head);
            var groupPrevious = dummy;

            while (true)
            {
                var kth = groupPrevious;
                for (var index = 0; index < k && kth != null; index++)
                {
                    kth = kth.next;
                }

                if (kth == null)
                {
                    break;
                }

                var groupNext = kth.next;
                var previous = groupNext;
                var current = groupPrevious.next;

                while (current != groupNext)
                {
                    var next = current.next;
                    current.next = previous;
                    previous = current;
                    current = next;
                }

                var groupFirst = groupPrevious.next;
                groupPrevious.next = kth;
                groupPrevious = groupFirst;
            }

            return dummy.next;
        }
        public ListNode ReverseKGroup4(ListNode head, int k)
        {
            int klike = k;
            Stack<ListNode> stack = new Stack<ListNode>();

            ListNode dummy = new ListNode();
            ListNode current = dummy;


            while (head != null)
            {
                if (klike-- > 0)
                {
                    stack.Push(head);
                    head = head.next;
                }
                else
                {
                    klike = k;
                    while (stack.Count > 0)
                    {
                        current.next = stack.Pop();
                        current = current.next;
                    }
                }
            }
            if (klike == 0)
            {
                while (stack.Count > 0)
                {
                    current.next = stack.Pop();
                    current = current.next;
                }
                current.next = null;
                return dummy.next;
            }
            ListNode dummytail = null;
            ListNode tail = null;
            while (stack.Count > 0)
            {
                if (tail == null)
                {
                    tail = stack.Pop();
                    dummytail = tail;
                }
                else
                {
                    dummytail = stack.Pop();
                    dummytail.next = tail;
                    tail = dummytail;
                }
            }

            current.next = dummytail;

            return dummy.next;
        }
        public ListNode ReverseKGroup5(ListNode head, int k)
        {
            ListNode resultHead = null;
            ListNode resultTail = null;

            while (true)
            {
                var (subHead, subTail, len) = Take(ref head, k);
                if (len == 0) { break; }
                if (len == k && k > 1) { Reverse(ref subHead, ref subTail); }
                if (resultHead == null)
                {
                    resultHead = subHead;
                }
                else
                {
                    resultTail.next = subHead;
                }
                resultTail = subTail;
                subTail.next = null;
            }
            return resultHead;
        }

        private static List<ListNode> temp = new();
        private static void Reverse(ref ListNode head, ref ListNode tail)
        {
            var p = head;
            while (p != tail)
            {
                temp.Add(p);
                p = p.next;
            }
            p = head = tail;
            tail = temp[0];
            for (int i = temp.Count - 1; i >= 0; --i)
            {
                p.next = temp[i];
                p = p.next;
            }
            p.next = head;
            temp.Clear();
        }

        private static (ListNode head, ListNode tail, int len) Take(ref ListNode head, int k)
        {
            if (head == null) { return (null, null, 0); }

            var p = head;
            var tail = head;
            var len = 0;
            for (int i = 0; i < k && p != null; ++i)
            {
                tail = p;
                p = p.next;
                len += 1;
            }
            var result = (head, tail, len);
            head = tail.next;
            return result;
        }

    }
}
