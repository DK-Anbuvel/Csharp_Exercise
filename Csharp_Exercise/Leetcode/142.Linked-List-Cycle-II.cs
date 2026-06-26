using System.Collections.Generic;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public ListNode DetectCycle(ListNode head) // 283 ms time o(n^2) space o(n)
        {

            /*
              About this problem:-
                given linked list , return cycle start head node.

              My approach:- [3,2,0,-4,2]

                  Failed: [3,2,2,0,-4] dictionary key stores unique value
                     Here while iterate and store the node value in dictionary 
                     till find the match node finded or become null.
            */
            if (head == null) return null;

            List<ListNode> track = new List<ListNode>(); //o(n)
            ListNode currentNode = head;
            while (currentNode != null) //o(n)
            {

                if (track.Contains(currentNode)) // o(n)
                    return currentNode;

                track.Add(currentNode);
                currentNode = currentNode.next;
            }

            return null;
        }
    }
}
