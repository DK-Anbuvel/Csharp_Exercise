using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Exercise
{
    public class Middle_of_the_Linked_ListTest
    {
        [Fact]
        public void MiddleNodeTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Exercise();

            ListNode head =
                new ListNode(1,
                    new ListNode(2,
                        new ListNode(3,
                            new ListNode(4,
                                new ListNode(5)))));

            ListNode head1 =
                new ListNode(1,
                    new ListNode(2,
                        new ListNode(3,
                            new ListNode(4,
                                new ListNode(5,new ListNode(6))))));
            // Act & Assert
            ListNode middle = solution.MiddleNode(head);
            ListNode middle1 = solution.MiddleNode(head1);
          //  Console.WriteLine(middle.val);
            Assert.Equal(3,middle.val);
            Assert.Equal(3,middle1.val);
        }
    }
}
