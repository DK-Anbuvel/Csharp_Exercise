using System.Collections;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode AddTwoNumbers()// 6ms time O(M+N) space O(M+N)  suggested space O(max (M+N) )
        {

            var node1 = new ListNode(3);
            var node2 = new ListNode(9);
            var node3 = new ListNode(9);
            var node4 = new ListNode(9);
            var node5 = new ListNode(9);
            var node6 = new ListNode(9);
            var node7 = new ListNode(9);
            var node8 = new ListNode(9);
            var node9 = new ListNode(9);
            var node10 = new ListNode(9);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            node8.next = node9;
            node9.next = node10;


            ListNode l1 = node1;

            var node11 = new ListNode(7);

            ListNode l2 = node11;

            /*
             About the problem:-
                   Here two numbers need to add and return as linkedlist.
                   task 1,2 :- digits given in listnode as some how need to iterate and store the value. O(n) + O(n)
                   task 3 :- add the two numbers.
                   task 4 :- convert the sum to list node. O(s)

             My approach:-
                  attempt 1:-  edge case : [3,9,9,9,9,9,9,9,9,9] range [1, 100]. this digit value can not store int variable bcz int maximum store 9-10 digits, 
                       convert 2 two no. into int / sum / convert sum into int.
                  attempt 2:- 
                         val store in string. // no size limit/ how to get last place char in both N1 and N2.
                         val store in array. // no size limit/ get/set size of the array, hard handle right - left iteration(2 loop) /position
                         val store in stack. // no size limit/ dynamic set, right - left iteration- easy follows FIFO

            */
            Stack<int> N1 = new Stack<int>(); 
            Stack<int> N2 = new Stack<int>(); 

            while (l1 != null)
            {
                N1.Push(l1.val); //append
                l1 = l1.next;
            }

            while (l2 != null)
            {
                N2.Push(l2.val);
                l2 = l2.next;
            }

            if (N1.Count == 0 && N2.Count ==0) return new ListNode(0);  // if it zero.

            int maxLen = N1.Count > N2.Count ? N1.Count : N2.Count;
            ListNode result =null;
            int rem = 0;

            while(maxLen > 0 || rem > 0) // how to get last place char in both N1 and N2.
            {
                int sum = rem + (N1.Count() > 0 ? N1.Pop() : 0 ) + (N2.Count() > 0 ? N2.Pop() : 0);
                int temp = sum % 10;
                rem = sum / 10;

                if (result == null)
                    result = new ListNode(temp);
                else
                {
                    ListNode copyNode = new ListNode(temp, result);
                    result = copyNode;
                }
                maxLen--;
            }

            return result;
        }
        public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
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
                sum = Sum(l2Reversed, l1Reversed);
            else
                sum = Sum(l1Reversed, l2Reversed);

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

        private ListNode Sum(ListNode less, ListNode greater)
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
        public ListNode AddTwoNumbers3(ListNode l1, ListNode l2)
        {
            l1 = CreateReversedList(l1);
            l2 = CreateReversedList(l2);

            var carry = 0;
            var result = default(ListNode);

            while (l1 != null || l2 != null || carry != 0)
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                var val = sum % 10;
                carry = sum / 10;

                result = new ListNode(val, result);
                l1 = l1?.next;
                l2 = l2?.next;
            }

            return result;
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            l1 = ReverseList2(l1);
            l2 = ReverseList2(l2);

            var val = 0;
            var carry = 0;
            var head = new ListNode(0);

            while (l1 != null || l2 != null)
            {
                var total = 0;

                if (l1 != null)
                {
                    total += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    total += l2.val;
                    l2 = l2.next;
                }

                val = (total + carry) % 10;
                carry = (total + carry) / 10;

                var node = new ListNode(val);

                node.next = head.next;
                head.next = node;
                head.val = carry;
            }

            return carry == 0 ? head.next : head;
        }
        private ListNode ReverseList2(ListNode root)
        {
            ListNode prev, cur, next;
            cur = root;
            prev = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            return prev;
        }

        private ListNode CreateReversedList(ListNode root)
        {
            var list = default(ListNode);

            while (root != null)
            {
                var next = list;
                list = new ListNode(root.val, next);
                root = root.next;
            }

            return list;
        }

        
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;

            }

            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;

            }

            int carry = 0;
            ListNode head = null;

            while (s1.Count > 0 || s2.Count > 0 || carry > 0)
            {
                int sum = carry;

                if (s1.Count > 0)
                    sum += s1.Pop();

                if (s2.Count > 0)
                    sum += s2.Pop();

                carry = sum / 10;
                ListNode node = new ListNode(sum % 10);
                node.next = head;
                head = node;

            }

            return head;
        }
        public ListNode AddTwoNumbers4(ListNode l1, ListNode l2)
        {
            string digits1 = "";

            while (l1 != null)
            {
                digits1 += l1.val;
                l1 = l1.next;
            }

            string digits2 = "";

            while (l2 != null)
            {
                digits2 += l2.val;
                l2 = l2.next;
            }



            int remaining = 0;

            int offset = 0;


            ListNode prev = null;

            while (offset < digits2.Length || offset < digits1.Length)
            {
                int currSum = 0;

                if (offset < digits1.Length)
                {
                    currSum = int.Parse(digits1[digits1.Length - 1 - offset].ToString());
                }

                if (offset < digits2.Length)
                {
                    currSum += int.Parse(digits2[digits2.Length - 1 - offset].ToString());
                }

                currSum += remaining;

                int currVal = currSum % 10;
                remaining = currSum / 10;


                var curr = new ListNode(currVal);
                curr.next = prev;
                prev = curr;

                offset++;
            }

            if (remaining > 0)
            {
                var curr = new ListNode(remaining);
                curr.next = prev;
                prev = curr;
            }


            return prev;
        }
    }
}
