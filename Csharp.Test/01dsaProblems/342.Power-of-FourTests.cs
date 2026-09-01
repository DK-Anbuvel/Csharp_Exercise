namespace Csharp.Test.Leetcode
{
    public class PowerOfFourTests
    {
        [Fact]
        public void IsPowerOfFourTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(false, solution.IsPowerOfFour(8));
     
        }
    }
}
