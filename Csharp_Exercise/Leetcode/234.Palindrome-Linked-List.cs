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
        // Palindrome checked only in first and second half. not check in between part.
        public bool IsPalindrome() // time O(N) space O(1)
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3; // create cycle
            node3.next = node4; // create cycle
            node4.next = node5; // create cycle
            //node3.next = node1;

            // 1 2 2 1 1

            ListNode head = node1;
            if (head == null) return true;

            // slow Find the middle
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

        public bool IsPalindrome1()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(1);
            var node4 = new ListNode(4);
            var node5 = new ListNode(1);
            node1.next = node2;
            node2.next = node3; // create cycle
            node3.next = node4; // create cycle
            node4.next = node5; // create cycle
            //node3.next = node1;
            ListNode head = node1;

            List<int> IntList = new List<int>();

            while(head != null)
            {
                IntList.Add(head.val);
                head = head.next;
            }
            for(int L = 0,R = IntList.Count - 1; L < R; L++, R--)
            {
                if (IntList[L] != IntList[R])
                    return false;
            }
            return true;
        }

        public bool IsPalindrome2(ListNode head) // best case
        {

            if (head == null) return true;

            if (head.next == null) return true;

            ListNode sp = head;
            ListNode fp = head;

            int res1 = 0;

            while (fp != null && fp.next != null)
            {
                res1 = res1 * 10 + sp.val;

                sp = sp.next;

                fp = fp.next.next;
            }

            if (fp != null)
            {
                sp = sp.next;
            }

            int res2 = NumberReverse(sp);
            return res1 == res2;

        }

        int NumberReverse(ListNode head)
        {
            int res = 0;
            int it = 1;

            while (head != null)
            {
                res = head.val * it + res;
                head = head.next;
                it *= 10;
            }

            return res;
        }

        public bool IsPalindrome3(ListNode head) // worst case (time)
        {
            List<int> intList = new List<int>();
            ListNode current = head;
            while (current != null)
            {
                intList.Add(current.val);
                current = current.next;
            }
            return intList.SequenceEqual(intList.ToArray().Reverse());
        }
        public bool IsPalindrome(ListNode head) //worst case (space)
        {
            ListNode jump1 = head;
            ListNode jump2 = head;
            while (jump2 != null && jump2.next != null)
            {
                jump1 = jump1.next;
                jump2 = jump2.next.next;
            }
            jump1 = ReverseList(jump1);
            while (jump1 != null)
            {
                Console.WriteLine($"{head.val} + {jump1.val}");
                if (head.val != jump1.val) return false;
                head = head.next;
                jump1 = jump1.next;
            }
            return true;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;
            if (head.next == null)
            {
                return head;
            }
            ListNode res = ReverseList(head.next);
            // Console.WriteLine($"{res.val} -> {res.next.val} = {head.val}");
            head.next.next = head;
            head.next = null;
            return res;
        }
    }
}
