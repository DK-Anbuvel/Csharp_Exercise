using static Csharp_Exercise.Leecodes;

namespace Csharp.Test.Leetcode
{
    public class Testcase146
    {
        [Fact]
        public void LRUCacheTest()
        {
            LRUCache2 lRUCache2 = new LRUCache2(2);
            lRUCache2.Put(2, 1); // cache is {2=1}
            lRUCache2.Put(1, 1); // cache is {1=1, 2=1}
            lRUCache2.Put(2, 3); // cache is {2=3, 1=1}
            lRUCache2.Put(4, 1); // cache is {4=1, 2=3}
            Assert.Equal(-1,lRUCache2.Get(1));    // return -1
            Assert.Equal(3, lRUCache2.Get(2));    // return 3

            LRUCache2 lRUCache = new LRUCache2(3);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            Assert.Equal(1, lRUCache.Get(1));    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Assert.Equal(2, lRUCache.Get(2));    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            lRUCache.Put(4, 5); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            Assert.Equal(-1, lRUCache.Get(1));    // return -1 (not found)
            Assert.Equal(3, lRUCache.Get(3));    // return 3
            Assert.Equal(4, lRUCache.Get(4));    // return 4

            LRUCache2 lRUCache1 = new LRUCache2(2);
            lRUCache1.Put(2, 1); // cache is {2=1}
            lRUCache1.Put(1, 1); // cache is {1=1, 2=1}
            lRUCache1.Put(2, 3); // cache is {2=3, 1=1}
            lRUCache1.Put(4, 1); // cache is {4=1, 2=3}
            Assert.Equal(-1, lRUCache1.Get(1));    // return -1
            Assert.Equal(3, lRUCache1.Get(2));    // return 3
        }
    }
}
