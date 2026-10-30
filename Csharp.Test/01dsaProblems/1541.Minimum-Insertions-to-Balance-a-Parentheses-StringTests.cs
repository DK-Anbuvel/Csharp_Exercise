namespace Csharp.Test.Leetcode
{
    public class Testcase1541
    {
        [Fact]
        public void MinInsertionsTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes.GreedyProblem();

            // Act & Assert
            solution.MinInsertions1(")())(");

            //solution.PlusOne([1, 2, 4]);
        }
    }
}
