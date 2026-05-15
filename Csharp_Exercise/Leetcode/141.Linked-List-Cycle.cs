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
        public bool HasCycle1() // Floyd's cycle finding algorithm  O(n) , O(1)
        {
            var node1 = new ListNode1(2);
            var node2 = new ListNode1(22);
            var node3 = new ListNode1(3);
            node1.next = node2;
            node2.next = node3; // create cycle
            //node3.next = node1;
            ListNode1 head = node1;

            ListNode1 rabbit = head; // fast pointer
            ListNode1 tortoise = head; // slow pointer
            while (rabbit != null && rabbit.next != null) // if cycle it loop till the end the condition satisfy and cycle not exist while condition fails and return false
            {
                tortoise = tortoise.next;
                rabbit = rabbit.next.next;

                if (tortoise == rabbit) return true;

            }
            return false;
        }
        public bool HasCycle2(ListNode head) // best case (time)
        {
            ListNode tmp = head;

            if (head == null)
                return false;
            else if (head.next == head)
                return true;

            while (head != null && tmp != null && tmp.next != null)
            {
                tmp = tmp.next.next;
                head = head.next;
                if (head == tmp)
                    return true;
            }
            return false;
        }
        public bool HasCycle3(ListNode head) // worst case (time)
        {
            if (head == null)
                return false;
            while (head.next != null)
            {
                if (head.next.val == int.MinValue)
                    return true;
                head.val = int.MinValue;
                head = head.next;
            }
            return false;
        }
        public bool HasCycle4(ListNode head)
        {
            /*
             about this problem:-
                Need to find the Cycle
             my approach:-
             
              attempt 1:-
                 here take each node store 
                 in temp then compare to all ---O(n^2)

                 it is a single linked list so only forward move only possible.

               attempt 2:-
                   store the visited on in Hashset that compare in all
            */
            HashSet<ListNode> vistedNode = new HashSet<ListNode>();// O(n)
            while (head != null)
            {
                if (vistedNode.Contains(head)) return true; // O(n)  
                vistedNode.Add(head);
                head = head.next;
              
            }
            return false;
        }
    }
}
