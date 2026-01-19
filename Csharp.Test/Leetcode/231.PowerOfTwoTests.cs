using Csharp_Exercise;
using Xunit;

namespace Csharp.Test.Leetcode
{
    public class PowerOfTwoTests
    {
        [Fact]
        public void IsPowerOfTwoTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(true, solution.IsPowerOfTwo2(323343242));
            Assert.Equal(true, solution.IsPowerOfTwo3(323343242));
            Assert.Equal(true, solution.IsPowerOfTwo3(323343242));
            Assert.Equal(true, solution.IsPowerOfTwo1(323343242));
            Assert.Equal(true, solution.IsPowerOfTwo(3));
        }
    }
}
