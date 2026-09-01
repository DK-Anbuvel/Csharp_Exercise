namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode RemoveElements(ListNode head, int val) // time O(n) space O(1)
        {
            /*
             About this problem :- 
                   Here need remove node based on the node.val == val      
             Apporach :-
               
              Attempted 1:-
                    In constraints, node.val minium is 1
                    and val minium is 0 so we can return when val as 0 bcz
                    node.val least no. was 1
                    
                    traverse with dummy node and list node check val --> O(n)

              Attempted 2:-
               
                   Use new list add while loop skip the val --> time o(n) space o(n)

            */

            if (val == 0) return head;
            if (head == null) return null;
            ListNode dummyNode = new ListNode(-1, head); // O(1) for check if head.val == val
            ListNode currentNode = dummyNode;

            while (currentNode.next != null)
            {
                if (currentNode.next.val == val) // [7,7,7,7]
                    currentNode.next = currentNode.next.next; // current node still did not move. reconnect current node to skip the matched node while staying at same position to handle consecutive values.”
                else
                    currentNode = currentNode.next;
            }
            return dummyNode.next;
        }
        public ListNode RemoveElements1(ListNode head, int val)
        {
            if (head == null) return head;

            while (head != null && head.val == val)
            {
                head = head.next;
            }

            if (head == null) return head;

            var pointer = head;
            var p = pointer;

            while (p != null && p.next != null)
            {
                if (p.next.val == val)
                {
                    p.next = p.next.next;
                }
                else
                {
                    p = p.next;
                }
            }

            return pointer;
        }

        public ListNode RemoveElements2(ListNode head, int val)
        {
            ListNode distinctElement = new ListNode();

            while(head != null)
            {
                if(head.val != val)
                {
                    if (distinctElement == null) distinctElement = new ListNode(head.val, null);
                    else distinctElement.next = new ListNode(head.val, null);
                }
                head = head.next;
            }
            return distinctElement;
        }
        public ListNode RemoveElements3(ListNode head, int val)
        {
            ListNode distinctElement = new ListNode(-1, null);
            ListNode traverseNode = distinctElement;
            while (head != null)
            {
                if (head.val != val)
                {
                    traverseNode.next = new ListNode(head.val, null);
                    traverseNode = traverseNode.next;
                }
                head = head.next;
            }
            return distinctElement.next;
        }
      
        public ListNode RemoveElements4(ListNode head, int val)
        {
            if (head == null) return head;

            ListNode dummy = new ListNode(9); // [1] val=1
            dummy.next = head;

            ListNode currentNode = dummy;

            while (currentNode.next != null)  // time O(n) space O(1)
            {
                if (currentNode.next.val == val)
                {
                    currentNode.next = currentNode.next.next;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }
            return dummy.next;
        }
    }
}
