using Csharp_Exercise;

namespace Csharp.Test.Leetcode
{
    public class Test23
    {
        [Fact]
        public void MergeKListsTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            // Assert.Equal(true, solution.ContainsNearbyDuplicate1([1, 2, 3, 1], 4));

           ListNode[] lists = new ListNode[]
           {
               new ListNode(1,
                   new ListNode(4,
                       new ListNode(5))),
           
               new ListNode(1,
                   new ListNode(3,
                       new ListNode(4))),
           
               new ListNode(2,
                   new ListNode(6))
           };

            ListNode result = solution.MergeKLists2(lists);
        }
    }
}
