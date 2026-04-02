namespace Csharp.Test.Leetcode
{
    public class Testcase121
    {
        [Fact]
        public void MaxProfit()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(3, solution.MaxProfit2([7, 1, 5, 3, 6, 4]));
            Assert.Equal(3, solution.MaxProfit1([7, 1, 5, 3, 6, 4]));
            Assert.Equal(3, solution.MaxProfit([7, 1, 5, 3, 6, 4]));
        }
    }
}
