namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public class LRU_list
        {
            public int key;
            public int val;
            public LRU_list next;

            public LRU_list(int k = 0, int v = 0, LRU_list n = null)
            {
                key = k;
                val = v;
                next = n;
            }

        }

        public class LRUCache
        {
            /*
              About this problem:-
                 Here need create/use ds for do the operation like get and put with limited size(capacity) and follow the LIFO rule.

                My approach:-
                   attempt 1 :- failed to run O(1) average time complexity and a Least Recently Used (LRU) cache..
                      since it is linked list set so I create custom link list class with members link
                      key,value and next (pointer).
                      construct -- capacity store in static variable 
                      get -- by using reference of the custom list , iterate till key exist.
                      put -- check < capacity/ iterate tail node / insert
                             check == capacity/ iterate tail node / update

                    attempt 2 :- failed to get mini value in weight
                      To maintain Least Recently Used (LRU) cache add one parameter (weight) in LRU_list class.
                      get() -- if exist weight++
                      put() -- find lower weight meth()

                    attempt 3 :- Time Limit Exceeded
                       To  maintain LRU , maintain recent used as head and least used as tail
                       get() -- if exist, relocate to head.
                       put() -- check < capacity/ iterate tail node / insert in head
                             check == capacity/ iterate tail node / update / relocate to head.

                    attempt 4 :- Time Limit Exceeded O(n) required to do in O(1) average time complexity.
                       To  maintain LRU , maintain recent used as head and least used as tail
                       get() -- if exist, relocate to head.
                       put() -- + dummy node / point before key node or before tail node/ remove / update dummy node key,value -- reduce as single iteration

            */
            public int LRU_limit = 0;
            public int nodeCount = 0;
            public LRU_list head;

            public LRUCache(int capacity)
            {
                LRU_limit = capacity;
            }

            public int Get(int key)//d,2,4
            {
                LRU_list copyNode = new LRU_list(0, 0, head);
                LRU_list currentNode = copyNode;

                while (currentNode.next != null)
                {
                    if (currentNode.next.key == key)
                    {
                        LRU_list temp = currentNode.next;

                        if (currentNode.next.next != null)
                            currentNode.next = currentNode.next.next;
                        else
                            currentNode.next = null;

                        copyNode.key = temp.key;
                        copyNode.val = temp.val;

                        head = copyNode;

                        return head.val;
                    }

                    currentNode = currentNode.next;
                }
                return -1;
            }

            public void Put(int key, int value) //d,1,2,null
            {
                if (head == null)
                {
                    nodeCount++;
                    LRU_list newNode = new LRU_list(key, value);
                    head = newNode;
                    return;
                }
                LRU_list copyNode = new LRU_list(0, 0, head);
                LRU_list currentKey = copyNode;

                while (currentKey.next != null) // check existing key
                {
                    if (currentKey.next.key == key)
                    {
                        currentKey.next.val = value;

                        LRU_list temp = currentKey.next;

                        if (currentKey.next.next != null)
                            currentKey.next = currentKey.next.next;
                        else
                            currentKey.next = null;

                        copyNode.key = temp.key;
                        copyNode.val = value;

                        head = copyNode;

                        return;
                    }
                    currentKey = currentKey.next;
                }
                if (nodeCount == LRU_limit) // update node
                {
                    LRU_list currentNode = copyNode;


                    while (currentNode.next.next != null) // get node before tail
                    {
                        currentNode = currentNode.next;
                    }
                    currentNode.next = null; // remove tail                    

                    copyNode.key = key;
                    copyNode.val = value;

                    head = copyNode;
                }
                else // new node in head
                {
                    nodeCount++;
                    LRU_list newNode = new LRU_list(key, value, head);
                    head = newNode;
                }

            }
        }
        public class LRUCache1
        {

            public int LRU_limit = 0;
            public int nodeCount = 0;
            public LRU_list head;

            public LRUCache1(int capacity)
            {
                LRU_limit = capacity;
            }

            public int Get(int key)//d,2,4
            {
                LRU_list copyNode = new LRU_list(0, 0, head);
                LRU_list currentNode = copyNode;

                while (currentNode.next != null)
                {
                    if (currentNode.next.key == key)
                    {
                        LRU_list temp = currentNode.next;

                        if (currentNode.next.next != null)
                            currentNode.next = currentNode.next.next;
                        else
                            currentNode.next = null;

                        copyNode.key = temp.key;
                        copyNode.val = temp.val;

                        head = copyNode;

                        return head.val;
                    }

                    currentNode = currentNode.next;
                }
                return -1;
            }

            public void Put(int key, int value) //d,1,null
            {
                if (head == null) // set initial node
                {
                    nodeCount++;
                    LRU_list newNode = new LRU_list(key, value);
                    head = newNode;
                    return;
                }
                if (nodeCount < LRU_limit) // update node
                {
                    nodeCount++;
                    LRU_list newNode = new LRU_list(key, value, head);
                    head = newNode;
                    return;
                }

                LRU_list copyNode = new LRU_list(0, 0, head); // dummy node for update last used node.
                LRU_list currentNode = copyNode;

                while (currentNode.next?.next != null) // point before tail or  before key node
                {
                    if (currentNode.next.key == key)
                        break;

                    currentNode = currentNode.next;
                }

                if (currentNode.next?.next != null)
                    currentNode.next = currentNode.next.next;
                else
                    currentNode.next = null;


                copyNode.key = key;  // update new node
                copyNode.val = value;

                head = copyNode;

            }
        }

    }
}
