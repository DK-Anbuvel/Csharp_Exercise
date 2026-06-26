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
        public Node CopyRandomList()// time O(n) space O(1)
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
        public Node CopyRandomList1(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node newHead = new Node(head.val);
            Node currentNew = newHead;
            Node currentOriginal = head.next;

            Dictionary<Node, Node> correspondingNodes = new Dictionary<Node, Node>();
            correspondingNodes.Add(head, newHead);

            while (currentOriginal != null)
            {
                currentNew.next = new Node(currentOriginal.val);
                currentNew = currentNew.next;
                correspondingNodes.Add(currentOriginal, currentNew);
                currentOriginal = currentOriginal.next;
            }

            currentOriginal = head;
            currentNew = newHead;

            while (currentOriginal != null)
            {
                if (currentOriginal.random != null)
                {
                    currentNew.random = correspondingNodes[currentOriginal.random];
                }
                currentNew = currentNew.next;
                currentOriginal = currentOriginal.next;
            }

            return newHead;
        }
        Dictionary<Node, Node> hashMap = new Dictionary<Node, Node>();
        public Node CopyRandomList2(Node head)
        {
            // if(head==null)
            // {
            //     return null;
            // }
            // Node curr = head;
            // Dictionary<Node,Node> hashMap = new Dictionary<Node,Node>();
            // while(curr!=null)
            // {
            //     Node newNode = new Node(curr.val);
            //     hashMap.Add(curr,new Node(curr.val));
            //     curr = curr.next;
            // }

            // curr = head;
            // while(curr!=null)
            // {
            //     hashMap[curr].next = curr.next!=null?hashMap[curr.next]:null;
            //     hashMap[curr].random = curr.random!=null?hashMap[curr.random]:null;
            //     curr = curr.next;
            // }

            // return hashMap[head];

            if (head == null)
            {
                return null;
            }
            if (hashMap.ContainsKey(head) == true)
            {
                return hashMap[head];
            }
            Node newHead = new Node(head.val);
            hashMap.Add(head, newHead);

            newHead.next = CopyRandomList2(head.next);
            newHead.random = CopyRandomList2(head.random);

            return newHead;
        }
        public Node CopyRandomList3(Node head)
        {
            if (head == null)
                return head;

            Node ori = head;
            Node n = new(0);
            Node r = n;

            List<Node> l1 = new();
            List<Node> l2 = new();

            while (head != null)
            {
                n.val = head.val;
                n.next = new(0);
                l1.Add(head);
                l2.Add(n);

                n = n.next;
                head = head.next;
            }

            head = ori;
            n = r;

            while (head != null)
            {
                if (head.random != null)
                {
                    var idx = l1.IndexOf(head.random);
                    if (idx != -1)
                        n.random = l2[idx];
                }
                if (head.next == null)
                    n.next = null;
                n = n.next;
                head = head.next;
            }

            return r;
        }
        public Node CopyRandomList4(Node head)
        {
            return CopyNode(head, new());
        }

        private Node CopyNode(Node node, Dictionary<Node, Node> copies)
        {
            if (node == null)
            {
                return null;
            }
            if (copies.ContainsKey(node))
            {
                return copies[node];
            }
            Node copy = new(node.val);
            copies.Add(node, copy);
            copy.next = CopyNode(node.next, copies);
            copy.random = CopyNode(node.random, copies);
            return copy;
        }
        public Node CopyRandomList5(Node head)
        {
            if (head is null) return head;
            Dictionary<Node, Node> dic = new()
            {
                [head] = new(head.val)
            };
            var curr = head;
            while (curr is not null)
            {
                if (curr.next is not null && !dic.ContainsKey(curr.next))
                    dic[curr.next] = new(curr.next.val);
                if (curr.next is not null)
                    dic[curr].next = dic[curr.next];
                if (curr.random is not null)
                {
                    if (!dic.ContainsKey(curr.random))
                    {
                        dic[curr.random] = new(curr.random.val);
                    }
                    dic[curr].random = dic[curr.random];
                }
                curr = curr.next;
            }
            return dic[head];
        }
    }
}
