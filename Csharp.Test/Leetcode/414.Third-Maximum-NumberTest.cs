namespace Csharp.Test.Leetcode
{
    public class Test414
    {
        [Fact]
        public void ThirdMaxTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(3, solution.ThirdMax2([3, 2, 1]));
            Assert.Equal(3, solution.ThirdMax([3, 2, 1]));

        }
    }
}
