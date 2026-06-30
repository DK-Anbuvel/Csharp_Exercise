using static Csharp_Exercise.Leecodes;

namespace Csharp.Test.Leetcode
{
    public class Testcase146
    {
        [Fact]
        public void LRUCacheTest()
        {
            LRUCache1 lRUCache = new LRUCache1(3);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            lRUCache.Get(1);    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            lRUCache.Get(2);    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            lRUCache.Put(4, 5); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            lRUCache.Get(1);    // return -1 (not found)
            lRUCache.Get(3);    // return 3
            lRUCache.Get(4);    // return 4

            LRUCache1 lRUCache1 = new LRUCache1(2);
            lRUCache1.Put(2, 1); // cache is {2=1}
            lRUCache1.Put(1, 1); // cache is {1=1, 2=1}
            lRUCache1.Put(2, 3); // cache is {2=3, 1=1}
            lRUCache1.Put(4, 1); // cache is {4=1, 2=3}
            lRUCache1.Get(1);    // return -1
            lRUCache1.Get(2);    // return 3
        }
    }
}
