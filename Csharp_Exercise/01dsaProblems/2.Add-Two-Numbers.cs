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
        public ListNode AddTwoNumbersI2(ListNode l1, ListNode l2)
        {
            ListNode less = null;
            ListNode greater = null;

            ListNode l1Reversed = null;
            ListNode l2Reversed = null;

            int l1Count = 0;
            int l2Count = 0;

            while (l1 != null)
            {
                l1Count++;

                ListNode tmp = l1.next;
                l1.next = l1Reversed;
                l1Reversed = l1;
                l1 = tmp;
            }

            while (l2 != null)
            {
                l2Count++;

                ListNode tmp = l2.next;
                l2.next = l2Reversed;
                l2Reversed = l2;
                l2 = tmp;
            }

            ListNode sum;

            if (l1Count >= l2Count)
                sum = SumI(l2Reversed, l1Reversed);
            else
                sum = SumI(l1Reversed, l2Reversed);

            ListNode reversedSum = null;

            while (sum != null)
            {
                ListNode tmp = sum.next;
                sum.next = reversedSum;
                reversedSum = sum;
                sum = tmp;
            }

            return reversedSum;
        }

        private ListNode SumI(ListNode less, ListNode greater)
        {
            ListNode dummy = new ListNode();
            ListNode sum = dummy;

            bool incrementNext = false;

            while (less != null || greater != null)
            {
                if (less != null)
                {
                    int bigValue = greater.val;
                    int smallValue = less.val;

                    if (incrementNext)
                    {
                        incrementNext = false;

                        if (bigValue + 1 >= 10)
                        {
                            bigValue = 0;
                            incrementNext = true;
                        }
                        else
                            bigValue++;
                    }

                    int result = bigValue + smallValue;

                    if (result >= 10)
                    {
                        result -= 10;
                        incrementNext = true;
                    }

                    sum.next = new ListNode(result);
                    sum = sum.next;

                    greater = greater.next;
                    less = less.next;
                }
                else
                {
                    int bigValue = greater.val;

                    if (incrementNext)
                    {
                        incrementNext = false;

                        if (bigValue + 1 >= 10)
                        {
                            bigValue = 0;
                            incrementNext = true;
                        }
                        else
                            bigValue++;
                    }

                    sum.next = new ListNode(bigValue);
                    sum = sum.next;

                    greater = greater.next;
                }
            }
            sum = dummy.next;


            if (incrementNext)
            {
                ListNode end = new ListNode(1);

                ListNode current = sum;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = end;
            }

            return sum;
        }
        public ListNode AddTwoNumbersI3(ListNode l1, ListNode l2)
        {
            ListNode inv1 = null;
            ListNode inv2 = null;
            int carry = 0;

            do
            {
                inv1 = new ListNode(l1.val, inv1);
                l1 = l1.next;
            } while (l1 != null);

            do
            {
                inv2 = new ListNode(l2.val, inv2);
                l2 = l2.next;
            } while (l2 != null);

            ListNode result = null;

            do
            {

                int val = carry;
                if (inv1 != null)
                {
                    val = val + inv1.val;
                    inv1 = inv1.next;
                }
                if (inv2 != null)
                {
                    val = val + inv2.val;
                    inv2 = inv2.next;
                }
                carry = val / 10;
                val = val % 10;

                result = new ListNode(val, result);


            } while (inv1 != null || inv2 != null);


            if (carry > 0)
            {
                result = new ListNode(carry, result);
            }
            return result;

        }
    }
}
