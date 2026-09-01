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

        public ListNode GetIntersectionNode1() // O(m+N) 
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

        public ListNode GetIntersectionNode2() //time O(m+n) space O(1)
        {
            /*
              about this problem:-
                  first i was confused, when i saw interval/ skipA/skipB after give some time and then only 
            understand these are just for building the structure linkedlist.
                  
             In this case: listA = [4, 1, 8, 4, 5] listB = [5, 6, 1, 8, 4, 5]
               its return 8 not 1 
                  Because intersection is NOT based on value, it is based on node reference (memory address).

              My Approach:-

                attempt 1:-  first store listA address in hashset but lookup ( o(1) ) then compare the address --> time O(a) + o(1) space o(a)

                attempt 2:- 
                         Here i need to compare the address each node to another list of node until condition valid.
                         Let say 1st list as 10 nodes and 2nd list as 5 nodes,
                              Here 1st list 5 nodes definitely not contain intersection bcz we compare address only, here when first 5 nodes contains also
                         last 5 nodes address. wherefore 1st node contain remining 9 nodes address, if i compare 1st node with 2nd list 1st node, it definetly
                         mismatch. here the trick.
             
                         first both list length./get difference / then move the pointer (difference times) on bigger one/ now two pointer compare each node.  
                     
                        
             */

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

            int listA = getLinkListLength(headA);
            int listB = getLinkListLength(headB);

            while(listA < listB)
            {
                listB--;
                headB = headB.next;
            }

            while(listA > listB)
            {
                listA--;
                headA = headA.next;
            }
            while(headA != null && headB!= null)
            {
                if (headA == headB) return headA;
                headA = headA.next;
                headB = headB.next;
            }
            return null;
        }
        
        public int getLinkListLength(ListNode node)
        {
            int count = 0;
            while(node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }
        public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();
            ListNode currA = headA;
            while (currA != null)
            {
                set.Add(currA);
                currA = currA.next;
            }
            ListNode currB = headB;
            while (currB != null)
            {
                if (set.Contains(currB))
                {
                    return currB;
                }
                currB = currB.next;
            }
            return null;
        }
        public ListNode GetIntersectionNode4(ListNode headA, ListNode headB)
        {
            Dictionary<ListNode, int> dic = new Dictionary<ListNode, int>();
            ListNode temp = headA;
            while (temp != null)
            {
                dic[temp] = 1;
                temp = temp.next;
            }
            temp = headB;

            while (temp != null)
            {
                if (!dic.ContainsKey(temp))
                {
                    dic[temp] = 0;
                }
                dic[temp]++;
                if (dic[temp] == 2)
                {
                    return temp;
                }
                temp = temp.next;

            }

            return null;
        }
        public ListNode GetIntersectionNode5(ListNode headA, ListNode headB)
        {
            var map = new HashSet<ListNode>(Enumerate(headA));
            return Enumerate(headB).FirstOrDefault(map.Contains);

            IEnumerable<ListNode> Enumerate(ListNode a)
            {
                while (a is not null)
                {
                    yield return a;
                    a = a.next;
                }
            }
        }
    }
}
