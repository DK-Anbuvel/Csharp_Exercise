using System.IO;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) // time O(n + m) space O(n + m) (new nodes created)
        {   /*
           About this problem:-
              Here array of sorted link list given, need return single sorted linked list.

           My approach:-
             
               first merge all list in single list bcz easy merge the list --> O(lists.Length)
               then
               linear sort, take node iterate thought out all nodes ---> o(n^2)

               divide and conquer comes in my mind.
           */

            ListNode mergedList = new ListNode(0, null); // create new link list.
            ListNode currentList = mergedList;

            while (list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    currentList.next = new ListNode(list1.val, null); // not need create new memory. use input node. 
                    currentList = currentList.next;
                    list1 = list1.next;
                }
                else 
                {
                    currentList.next = new ListNode(list2.val, null);
                    currentList = currentList.next;
                    list2 = list2.next;
                }
            }
            if(list1 is not null)
            {
                currentList.next = list1;
            }
            if(list2 is not null)
            {
                currentList.next = list2;
            }
            return mergedList.next;

        }
        public ListNode MergeTwoLists1(ListNode list1, ListNode list2)
        {
            ListNode result = new ListNode(0);
            ListNode dummy = result;

            while (list1 != null && list2 != null)
            {
                if (list2.val <= list1.val)
                {
                    dummy.next = list2;
                    list2 = list2.next;
                }
                else if (list1.val < list2.val)
                {
                    dummy.next = list1;
                    list1 = list1.next;
                }
                dummy = dummy.next;
            }
            dummy.next = list1 ?? list2; // good way
            return result.next;
        }
        public ListNode MergeTwoLists2(ListNode list1, ListNode list2) // time O(n+l)  space O(n)
        {
            List<int> numbers = new List<int>();// O(l1 + l2)

            while (list1 != null)
            {
                numbers.Add(list1.val);
                list1 = list1.next;
            }

            while (list2 != null)
            {
                numbers.Add(list2.val);
                list2 = list2.next;
            }

            numbers.Sort(); // as per constraint max size 100

            ListNode dummy = new ListNode(0);
            ListNode current = dummy;

            foreach (int number in numbers)
            {
                current.next = new ListNode(number);
                current = current.next;
            }

            return dummy.next;
        }
        public ListNode MergeTwoLists3(ListNode list1, ListNode list2) //Consider: Can you refactor this to splice existing nodes directly and drop space usage to O(1)?
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            while (list1 != null && list2 != null) // O( max(l1,l2))
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;  // reuse node
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;  // reuse node
                    list2 = list2.next;
                }

                current = current.next;
            }

            current.next = list1 ?? list2;

            return dummy.next;
        }

        public ListNode MergeTwoList4()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);

            var node5 = new ListNode(2);
            var node6 = new ListNode(3);
            var node7 = new ListNode(6);
            var node8 = new ListNode(8);
            var node9 = new ListNode(9);
            node1.next = node2;
            node2.next = node3; // create cycle
           // node3.next = node4; // create cycle

            node4.next = node5; // create cycle
            node6.next = node7;
            node8.next = node9; // create cycle


            ListNode list1 = node1; //1 2 6
            ListNode list2 = node4; //2 4 5

            ListNode L1Point = new ListNode(0, list1); // edge case: [2] , [1] by using dummy node take advantage on this case
            ListNode L2Point = new ListNode(0, list2);

            //while(L1Point.next != null && L2Point.next != null)
            //{
            //    if(L1Point.next.val < L2Point.next.val)
            //    {
            //        ListNode SliceNodes = L2
            //    }
            //}
            return null;

        }
    }
}
