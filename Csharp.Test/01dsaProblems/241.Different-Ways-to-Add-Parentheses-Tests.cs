namespace Csharp.Test.Leetcode
{
    public class Test241
    {
        [Fact]
        public void DiffWaysToComputeTest()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(new List<int> { 0,1}, solution.DiffWaysToCompute4("2-1-1"));
            Assert.Equal(new List<int> {-34, -14, -10, -10, 10}, solution.DiffWaysToCompute1("2*3-4*5"));

        }
    }
}