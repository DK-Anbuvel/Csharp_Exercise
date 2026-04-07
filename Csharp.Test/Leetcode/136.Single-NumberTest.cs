namespace Csharp.Test.Leetcode
{
    public class Test136
    {
        [Fact]
        public void SingleNumberTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(1, solution.SingleNumber2([4, 1, 2, 1, 2]));
            Assert.Equal(1, solution.SingleNumber2([2, 2, 1]));
        }
    }
}
