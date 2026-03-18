namespace Csharp.Test.Leetcode
{
    public class Test268
    {
        [Fact]
        public void MissingNumber()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(4, solution.MissingNumber([0]));
            Assert.Equal(4, solution.MissingNumber([4,1,3,0]));
            
        }
    }
}