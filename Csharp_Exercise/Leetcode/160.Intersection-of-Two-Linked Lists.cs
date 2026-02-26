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
       public ListNode GetIntersectionNode()
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

            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            var node8 = new ListNode(3);
            var node9 = new ListNode(4);
            var node0 = new ListNode(5);
            node6.next = node7;
            node7.next = node8; // create cycle
            node8.next = node9; // create cycle
            node9.next = node0; // create cycle

            ListNode headA = node1;
            ListNode headB = node6;

            while (headA != null)
           {
               while (headB != null)
               {
                   if (headA == headB)
                       return headA;
                   headB = headB.next;
               }
               headA = headA.next;
           }
           return null;
       }

        public ListNode GetIntersectionNode1()
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

            var node6 = new ListNode(6);
            var node7 = new ListNode(7);
            var node8 = new ListNode(3);
            var node9 = new ListNode(4);
            var node0 = new ListNode(5);
            node6.next = node7;
            node7.next = node8; // create cycle
            node8.next = node9; // create cycle
            node9.next = node0; // create cycle

            ListNode headA = node1;
            ListNode headB = node6;

            if (headA == null || headB == null) return null;
            ListNode t1 = headA;
            ListNode t2 = headB;
            while (t1 != t2)
            {
                t1 = (t1 == null) ? headB : t1.next;
                t2 = (t2 == null) ? headA : t2.next;
            }
            return t1;
        }
    }
}
