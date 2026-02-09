using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public bool IsPalindrome()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(2);
            var node4 = new ListNode(1);
            var node5 = new ListNode(1);
            node1.next = node2;
            node2.next = node3; // create cycle
            node3.next = node4; // create cycle
            node4.next = node5; // create cycle
            //node3.next = node1;

            // 1 2 2 1 1

            ListNode head = node1;
            if (head == null) return true;

            // Find the middle
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Reverse the second half
            ListNode prev = null, curr = slow;
            while (curr != null)
            {
                ListNode nextNode = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextNode;
            }

            // Compare both halves
            ListNode firstHalf = head, secondHalf = prev;
            while (secondHalf != null)
            {
                if (firstHalf.val != secondHalf.val)
                {
                    return false;
                }
                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }

            return true;
        }
    }
}
