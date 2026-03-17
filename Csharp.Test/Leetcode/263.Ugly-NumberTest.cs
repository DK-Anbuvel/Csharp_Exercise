namespace Csharp.Test.Leetcode
{
    public class Test263
    {
        [Fact]
        public void IsUglyNumber()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(false, solution.IsUgly(23));
            Assert.Equal(false, solution.IsUgly(689801));
        }
    }
}