using Csharp_Exercise;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
        public class ListNode1
        {
            public int val;
            public ListNode1 next;
            public ListNode1(int x)
            {
                val = x;
                next = null;
            }
        }
        public bool HasCycle() // single linked list HashSet used to store unique value in shorted manner.
        {
            var node1 = new ListNode1(2);
            var node2 = new ListNode1(22);
            node1.next = node2;
            node2.next = node1; // create cycle
            ListNode1 head = node1;
            HashSet<ListNode1> vistedNode = new HashSet<ListNode1>(); 
           // ListNode currentNode = head;
            while(head != null)
            {
                if (vistedNode.Contains(head)) return true;
                vistedNode.Add(head);
                
                head = head.next;
            }
            return false;
        }
    }
}
