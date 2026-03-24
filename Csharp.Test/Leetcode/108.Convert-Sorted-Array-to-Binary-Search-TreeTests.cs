namespace Csharp.Test.Leetcode
{
    public class Testcase108
    {
        [Fact]
        public void SortedArrayToBSTTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            
            solution.SortedArrayToBST7([-10, -3, 0, 5, 9]); // test even count.
            solution.SortedArrayToBST2([1,3]); // test ood count
            solution.SortedArrayToBST2([1,1,3,4]); // test duplicate no.
            solution.SortedArrayToBST2([1, 1,3]);
            solution.SortedArrayToBST2([0, 1, 2, 3, 4, 5]);
        }
    }
}
