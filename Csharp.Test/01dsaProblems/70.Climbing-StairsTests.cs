namespace Csharp.Test.Leetcode
{
    public class Test70
    {
        [Fact]
        public void ClimbStairsTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            Assert.Equal(3, solution.ClimbStairs1(3));
            Assert.Equal(3, solution.ClimbStairs2(3));
            Assert.Equal(3, solution.ClimbStairs(3));

        }
    }
}
