namespace Csharp.Test.Leetcode
{
    public class Testcase16
    {
        [Fact]
        public void LinkedListIntersectionTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes.arrayProblem();

            // Act & Assert
            solution.TwoSum([2, -7, 11, 3], 4);
            solution.ThreeSumClosest([-1, 2, 1, -4],1);
            //solution.PlusOne([1, 2, 4]);
        }
    }
}
