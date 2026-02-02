using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test141
    {
        /**
 * Definition for singly-linked list. **/
  public class ListNode1 {
      public int val;
      public ListNode1 next;
      public ListNode1(int x) {
          val = x;
          next = null;
      }
  }

        [Fact]
        public void HasCycleTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            //Act
            var node1 = new ListNode1(2);
            var node2 = new ListNode1(22);
            node1.next = node2;
            node2.next = node1; // create cycle

            // Assert
            Assert.Equal(true, solution.HasCycle());
        }
    }
}
