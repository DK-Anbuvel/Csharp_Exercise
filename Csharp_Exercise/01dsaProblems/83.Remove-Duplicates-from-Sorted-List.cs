namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            /*
               My approach :-
                   store head then compare with current node with next node --O(n)
            */
            if (head == null) return head;
            ListNode HeadNode = head; // Since it is reference type, Here assigning the reference (address) to the same object in memory 
            while (head.next != null) // Both head and HeadNode point to the same linked list. 
            {
                if (head.val == head.next.val)
                {
                    if (head.next.next == null)
                    {
                        head.next = null;
                        return HeadNode;
                    }
                    head.next = head.next.next; // if some thing change on head, it will applies HeadNode too.
                }
                else
                    head = head.next;
            }
            return HeadNode;
        }
        public ListNode DeleteDuplicates1(ListNode head)
        {
            ListNode temp = head;
            while (temp != null && temp.next != null)
            {
                if (temp.val == temp.next.val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return head;
        }
        public ListNode DeleteDuplicates2(ListNode head) //1 -> 1 -> 2 -> 3 -> 3
        {
            if (head == null) return head;

            var result = head; // store the reference and result
            var tmp = result; // to traverse and modify the value

            var p = head.next; // n+1
            int prev_val = result.val; // n

            while (p != null) // start from n-1
            {
                if (prev_val != p.val)
                {
                    prev_val = p.val; // store the n+1 value
                    tmp.next = p;
                    tmp = tmp.next; 
                }
                p = p.next; // moving the pointer
            }

            tmp.next = null;

            return result;
        }
        public ListNode DeleteDuplicates3(ListNode head)
        {
            HashSet<int> seen = new();
            var p = head;
            ListNode result = new ListNode(0); 
            var r = result;

            while (p != null)
            {
                if (!seen.Contains(p.val))
                {
                    r.next = new ListNode(p.val);
                    r = r.next;
                    seen.Add(p.val);
                }
                p = p.next;
            }

            return result.next;
        }
        public ListNode DeleteDuplicates4(ListNode head)
        {
            if (head == null)
                return null;

            ListNode index = head;
            ListNode dedup = new ListNode();
            ListNode traverser = dedup;

            traverser.val = index.val;
            index = index.next;

            while (index != null)
            {
                if (traverser.val != index.val)
                {
                    traverser.next = new ListNode(index.val);
                    traverser = traverser.next;
                }
                index = index.next;
            }

            return dedup;
        }
    }
}
