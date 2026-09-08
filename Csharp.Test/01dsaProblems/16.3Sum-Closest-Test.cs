namespace Csharp.Test.Leetcode
{
    public class Testcase16
    {
        [Fact]
        public void LinkedListIntersectionTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes.arrayProblem();

            // Act & Assert
            solution.ThreeSumClosest([-1, 2, 1, -4],1);
            //solution.PlusOne([1, 2, 4]);
        }
    }
}
