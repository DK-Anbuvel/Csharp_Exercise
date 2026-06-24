namespace Csharp_Exercise
{
    public partial class Leecodes
    {
            public class Node
            {
                public int val;
                public Node next;
                public Node random;

                public Node(int _val)
                {
                    val = _val;
                    next = null;
                    random = null;
                }
            }
        public Node CopyRandomList()
        {
            /*
             about this problem:-
                  Here need to copy the exactly copy of the head
                  I think edge case was how to set the value for random pointer ? 

             my approach:-
                 let split into 3 parts,
                  1 part - create new list and copy the value and next node
                  2 part - using dictionary<int,int> for track position
                  3 part - 

               attempt 2:-

                  In linked list, insert and delete is big advantage,
                  insert between new node copy in every list of nodes.
                  and set random node
                  finally separate the old and new nodes.

             */

            var node1 = new Node(7);
            var node2 = new Node(13);
            var node3 = new Node(11);
            var node4 = new Node(10);
            var node5 = new Node(1);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            node1.random = null;
            node2.random = node1;
            node3.random = node5;
            node4.random = node3;
            node5.random = node1;



            Node head = node1;

            if (head == null) return null;


            Node NewHead = head; // head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
            Node curr_NewHead = NewHead;
            Node curr1_NewHead = NewHead;
            Node curr2_NewHead = NewHead;
            // insert the copy of the new nodes
            while (curr_NewHead != null)
            {
                Node newNode = new Node(curr_NewHead.val);
                newNode.next = curr_NewHead.next;
                curr_NewHead.next = newNode;

                curr_NewHead = curr_NewHead.next.next;
            }
            // set random node value
            while (curr1_NewHead != null)
            {
                if (curr1_NewHead.random != null)
                    curr1_NewHead.next.random = curr1_NewHead.random.next;

                curr1_NewHead = curr1_NewHead.next.next;
            }
            // split the old and new nodes
            Node Result = new Node(0);
            Node CurrentResult = Result;

            while (curr2_NewHead != null)
            {
                CurrentResult.next = curr2_NewHead.next;
                CurrentResult = CurrentResult.next;

                curr2_NewHead.next = curr2_NewHead.next.next;
                curr2_NewHead = curr2_NewHead.next;
            }

            return Result.next;
        }

    }
}
