using System.Collections.Generic;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode DetectCycle(ListNode head) // 283 ms time o(n^2) space o(n)
        {

            /*
              About this problem:-
                given linked list , return cycle start head node.

              My approach:- [3,2,0,-4,2]

                  Failed: [3,2,2,0,-4] dictionary key stores unique value
                     Here while iterate and store the node value in dictionary 
                     till find the match node finded or become null.
            */
            if (head == null) return null;

            List<ListNode> track = new List<ListNode>(); //o(n)
            ListNode currentNode = head;
            while (currentNode != null) //o(n)
            {

                if (track.Contains(currentNode)) // o(n)
                    return currentNode;

                track.Add(currentNode);
                currentNode = currentNode.next;
            }

            return null;
        }
        public ListNode DetectCycle1()
        {
            /* Floyd's Cycle Detection (Tortoise and Hare):
              - start 2 pointers
                    fast moves 2 nodes at a time
                    slow moves 1 node at a time
              - wait for them to meet
              - As soon as they meet
                    Move fast pointer to head
                    Move both pointers at same speed
              - wait for them to meet again
              - They will meet at the starting of loop.
             */
            var node1 = new ListNode(3);
            var node2 = new ListNode(2);
            var node3 = new ListNode(0);
            var node4 = new ListNode(-4);
            var node5 = new ListNode(2);

            node1.next = node2;
            node2.next = node3; 
            node3.next = node4; 
            node4.next = node5; 
            node5.next = node3; 
            

            ListNode head = node1;

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                {
                    slow = head;
                    while (slow != fast)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    return slow;
                }
            }
            return null;
        }
        public ListNode DetectCycle2(ListNode head)
        {
            Dictionary<ListNode, bool> dt = new Dictionary<ListNode, bool>();

            ListNode temp = head;

            while (temp != null)
            {
                if (dt.ContainsKey(temp) && dt[temp] == true)
                {
                    return temp;
                }

                dt.Add(temp, true);
                temp = temp.next;
            }

            return null;
        }
        public ListNode DetectCycle3()
        {
            var node1 = new ListNode(3);
            var node2 = new ListNode(2);
            var node3 = new ListNode(0);
            var node4 = new ListNode(-4);
            var node5 = new ListNode(2);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node3;


            ListNode head = node1;
            ListNode b = head;
            while (b != null)
            {
                if (b.val == 100001)
                    return b;
                else
                    b.val = 100001;

                b = b.next;
            }
            return null;
        }
    }
}
