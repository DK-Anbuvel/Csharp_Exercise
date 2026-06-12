using System.IO;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) // time O(n + m) space O(n + m) (new nodes created)
        {   /*
           About this probelm:-
              Here array of sorted linklist given, need return single sorted linked list.

           My approach:-
             
               first merge all list in sigle list bcz easy merge the list --> O(lists.Lenght)
               then
               linear sort, take node iterate througtout all nodes ---> o(n^2)

               divide and conquer comes in my mind.
           */

            ListNode mergedList = new ListNode(0, null);
            ListNode currentList = mergedList;

            while (list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    currentList.next = new ListNode(list1.val, null);
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
            List<int> numbers = new List<int>();

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

            numbers.Sort();

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

            while (list1 != null && list2 != null)
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
    }
}
