
using System.Collections;

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

        public class doubleLinkNode
        {
            public int key;
            public int val;
            public doubleLinkNode next;
            public doubleLinkNode previous;
        }
        public class LRUCache2 // 31ms time O(1) space O(n)
        {
            doubleLinkNode head = new();
            doubleLinkNode tail = new();
            int sizeLimit = 0;
            Dictionary<int, doubleLinkNode> map_node;
           
            public LRUCache2(int capacity)
            {
                sizeLimit = capacity;
                head.next = tail;
                tail.previous = head;

                map_node = new Dictionary<int, doubleLinkNode>(capacity);
            }

            public int Get(int key)
            {
                int result = -1;
                if (map_node.ContainsKey(key))
                {
                    result= map_node[key].val;

                    remove(map_node[key]);
                    add(map_node[key]);
                }
                return result;
            }

            public void Put(int key, int value)// existing key/add/ update
            {
                doubleLinkNode newNode = new doubleLinkNode
                {
                    key = key,
                    val = value,
                    next = null,
                    previous = null
                };

                if (map_node.ContainsKey(key))
                {
                    remove(map_node[key]);
                    map_node[key].val = value;
                    add(map_node[key]);
                }
                else if(sizeLimit == map_node.Count)// how to get last node for pass remove ? use tail node
                {
                    map_node.Remove(tail.previous.key);
                    remove(tail.previous);
                    add(newNode);
                    map_node.Add(key, newNode);
                }
                else
                {
                    add(newNode);
                    map_node.Add(key, newNode);
                }
            }

            void add(doubleLinkNode node) // add in after head node
            {
                doubleLinkNode temp = head.next;

                head.next = node;
                node.previous = head;
                node.next = temp;
                temp.previous = node;
            }
            void remove(doubleLinkNode node) // remove in before tail node.
            {
                doubleLinkNode BeforeNode = node.previous;
                doubleLinkNode AfterNode = node.next;

                BeforeNode.next = AfterNode;
                AfterNode.previous = BeforeNode;
            }
        }

        public class LRUCache3
        {
            private const int MaxKey = 10000;

            private readonly int _capacity;
            private readonly int[] _values = new int[MaxKey + 1];
            private readonly int[] _prev = new int[MaxKey + 1];
            private readonly int[] _next = new int[MaxKey + 1];
            private readonly bool[] _exists = new bool[MaxKey + 1];

            private int _head = -1; // most recent
            private int _tail = -1; // least recent
            private int _count;

            public LRUCache3(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (!_exists[key])
                    return -1;

                MoveToFront(key);
                return _values[key];
            }

            public void Put(int key, int value)
            {
                if (_exists[key])
                {
                    _values[key] = value;
                    MoveToFront(key);
                    return;
                }

                _values[key] = value;
                _exists[key] = true;
                AddFront(key);
                _count++;

                if (_count <= _capacity)
                    return;

                int lru = _tail;

                Remove(lru);
                _exists[lru] = false;
                _count--;
            }

            private void MoveToFront(int key)
            {
                if (key == _head)
                    return;

                Remove(key);
                AddFront(key);
            }

            private void AddFront(int key)
            {
                _prev[key] = -1;
                _next[key] = _head;

                if (_head != -1)
                    _prev[_head] = key;
                else
                    _tail = key;

                _head = key;
            }

            private void Remove(int key)
            {
                int prev = _prev[key];
                int next = _next[key];

                if (prev != -1)
                    _next[prev] = next;
                else
                    _head = next;

                if (next != -1)
                    _prev[next] = prev;
                else
                    _tail = prev;
            }
        }

        public class LRUCache4
        {
            private class CacheNode
            {
                public int val { get; set; }
                public int key;
                public CacheNode next;
                public CacheNode prev;

                public CacheNode(int key, int val)
                {
                    this.key = key;
                    this.val = val;
                }
            }

            // Hash map acting as the cache.
            private Dictionary<int, CacheNode> _cache;

            // Some usage tracking - Doublely Linked List.
            private CacheNode _head;
            private CacheNode _tail;

            private int _capacity;

            public LRUCache4(int capacity)
            {
                _cache = new Dictionary<int, CacheNode>(capacity);
                _capacity = capacity;
                _head = new CacheNode(0, 0);
                _tail = new CacheNode(0, 0);
                _head.next = _tail;
                _tail.prev = _head;
            }

            public int Get(int key)
            {
                if (_cache.TryGetValue(key, out CacheNode node))
                {
                    MoveToFront(node);
                    return node.val;
                }
                else
                {
                    return -1;
                }
            }

            public void Put(int key, int value)
            {
                if (_cache.TryGetValue(key, out CacheNode node))
                {
                    node.val = value;
                    MoveToFront(node);
                }
                else
                {
                    if (_cache.Count >= _capacity)
                    {
                        var recycledNode = _tail.prev;
                        _cache.Remove(recycledNode.key);
                        recycledNode.key = key;
                        recycledNode.val = value;
                        _cache.Add(recycledNode.key, recycledNode);
                        MoveToFront(recycledNode);
                    }
                    else
                    {
                        node = new CacheNode(key, value);
                        _cache.Add(key, node);
                        AddNode(node);
                    }
                }
            }

            private void AddNode(CacheNode node)
            {
                node.next = _head.next;
                node.prev = _head;
                node.next.prev = node;
                _head.next = node;
            }

            private void RemoveNode(CacheNode node)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }

            private void MoveToFront(CacheNode node)
            {
                RemoveNode(node);
                AddNode(node);
            }

            private void EvictIfNecissary()
            {
                if (_cache.Count >= _capacity)
                {
                    _cache.Remove(_tail.prev.key);
                    RemoveNode(_tail.prev);
                }
            }
        }
        public class LRUCache5
        {
            private DoublyLinkedList list;
            private Dictionary<int, TwoWayListNode> dict;
            private int capacity;

            public LRUCache5(int capacity)
            {
                this.list = new DoublyLinkedList();
                this.dict = new Dictionary<int, TwoWayListNode>();
                this.capacity = capacity;
            }

            public int Get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    TwoWayListNode node = dict[key];
                    list.RemoveNode(node);
                    list.AddToHead(node);
                    return node.val;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (dict.ContainsKey(key))
                {
                    TwoWayListNode node = dict[key];
                    node.val = value;
                    list.RemoveNode(node);
                    list.AddToHead(node);
                }
                else
                {
                    if (dict.Count >= capacity)
                    {
                        // remove the least recently used item
                        TwoWayListNode tailNode = list.RemoveTail();
                        if (tailNode != null)
                        {
                            dict.Remove(tailNode.key);
                        }
                    }
                    // add the new node
                    TwoWayListNode newNode = new TwoWayListNode(value, key);
                    list.AddToHead(newNode);
                    dict[key] = newNode;
                }
            }
        }

        // Node for Doubly Linked List
        public class TwoWayListNode
        {
            public int key; // Key on Dictionary, for removal usage
            public int val;
            public TwoWayListNode next;
            public TwoWayListNode prev;

            public TwoWayListNode(int val, int key, TwoWayListNode next = null, TwoWayListNode prev = null)
            {
                this.val = val;
                this.key = key;
                this.next = next;
                this.prev = prev;
            }
        }

        public class DoublyLinkedList
        {
            public TwoWayListNode head;
            public TwoWayListNode tail;

            public DoublyLinkedList()
            {
                // Head and tail are dummy nodes
                head = new TwoWayListNode(-1, -1);
                tail = new TwoWayListNode(-1, -1);
                head.next = tail;
                tail.prev = head;
            }

            public void AddToHead(TwoWayListNode node)
            {
                node.next = head.next;
                node.prev = head;
                head.next.prev = node;
                head.next = node;
            }

            public void RemoveNode(TwoWayListNode node)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }

            public TwoWayListNode RemoveTail()
            {
                TwoWayListNode tailNode = tail.prev;
                if (tailNode == head)
                {
                    return null;
                }
                RemoveNode(tailNode);
                return tailNode;
            }
        }
        public class LRUCache6
        {
            private int _capacity;

            private Dictionary<int, int> _cache = new Dictionary<int, int>();
            private List<int> _hotKeys = new List<int>();

            public LRUCache6(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (!_cache.ContainsKey(key))
                    return -1;

                if (_hotKeys.Contains(key))
                {
                    _hotKeys.Remove(key);
                    _hotKeys.Add(key);
                }

                return _cache[key];
            }

            public void Put(int key, int value)
            {
                if (_hotKeys.Contains(key))
                {
                    _hotKeys.Remove(key);
                }
                else if (_cache.Count == _capacity)
                {
                    var lruKey = _hotKeys[0];
                    _hotKeys.Remove(lruKey);
                    _cache.Remove(lruKey);
                }

                _hotKeys.Add(key);

                _cache[key] = value;
            }
        }
        public class LRUCache7
        {
            // Definiamo una classe per memorizzare sia chiave che valore nel nodo
            private class CacheItem
            {
                public int Key;
                public int Value;
                public CacheItem(int k, int v) { Key = k; Value = v; }
            }

            private readonly int _capacity;
            private readonly Dictionary<int, LinkedListNode<CacheItem>> _map;
            private readonly LinkedList<CacheItem> _list;

            public LRUCache7(int capacity)
            {
                _capacity = capacity;
                _map = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
                _list = new LinkedList<CacheItem>();
            }

            public int Get(int key)
            {
                if (!_map.TryGetValue(key, out var node))
                {
                    return -1;
                }

                // Sposta il nodo in cima alla lista (Recentemente usato)
                _list.Remove(node);
                _list.AddFirst(node);

                return node.Value.Value;
            }

            public void Put(int key, int value)
            {
                if (_map.TryGetValue(key, out var node))
                {
                    // Aggiorna valore e sposta in testa
                    node.Value.Value = value;
                    _list.Remove(node);
                    _list.AddFirst(node);
                }
                else
                {
                    // Se la cache è piena, rimuovi l'ultimo (Meno usato)
                    if (_map.Count >= _capacity)
                    {
                        var lastNode = _list.Last;
                        _map.Remove(lastNode.Value.Key);
                        _list.RemoveLast();
                    }

                    // Aggiungi nuovo nodo
                    var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
                    _list.AddFirst(newNode);
                    _map.Add(key, newNode);
                }
            }
        }
        /**
         * Your LRUCache object will be instantiated and called as such:
         * LRUCache obj = new LRUCache(capacity);
         * int param_1 = obj.Get(key);
         * obj.Put(key,value);
         */

        /**
         * Your LRUCache object will be instantiated and called as such:
         * LRUCache obj = new LRUCache(capacity);
         * int param_1 = obj.Get(key);
         * obj.Put(key,value);
         */
    }
}
