namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode AddTwoNumbersI(ListNode l1, ListNode l2)// 15 ms, time O(max(l1,l2)), space O(max(l1,l2))
        {
            /*
             about this problem:-
                need to return the sum of the link list, 
                the list digit stored in reverse order so no need to iterate for to go end node, this the 
                different between I and II.

             My approach:-
                attempt 1: failed to understanding gap
                    iterate l1 & l2 / store the int value d1 & d2 / summ / store in link list --> O(l1+ l2(max))
                attempt 2: failed
                    stack (LIFO)/ store and fast loopup/ peek /store in new link list --> O(l1 + l2(min))
                attempt 3:
                    recursion ?     
                attempt 4:
                   Queue(FIFO)/ store Enqueue and fast loop up/ Dequeue / store in new Link list
            */

            Queue<int> List1 = new Queue<int>();
            Queue<int> List2 = new Queue<int>();

            ListNode result = null;
            ListNode currentNode = null;

            while (l1 != null)
            {
                List1.Enqueue(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                List2.Enqueue(l2.val);
                l2 = l2.next;
            }

            int carryNo = 0;

            while (List1.Count() > 0 || List2.Count() > 0 || carryNo > 0)
            {

                int sum = carryNo + (List1.Count() > 0 ? List1.Dequeue() : 0)
                                    + (List2.Count() > 0 ? List2.Dequeue() : 0);

                carryNo = sum / 10;
                sum = sum % 10;


                if (result == null)
                {
                    result = new(sum);
                    currentNode = result;
                }
                else
                {
                    currentNode.next = new(sum);
                    currentNode = currentNode.next;
                }

            }
            return result;
        }
        public ListNode AddTwoNumbersI1(ListNode l1, ListNode l2, int carry = 0)
        {


            if (l1 == null && l2 == null && carry == 0) return null;

            int sum = ((l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0)) + carry;
            carry = sum / 10;

            return new ListNode(sum % 10, AddTwoNumbersI1(l1?.next, l2?.next, carry));



        }
    }
}
