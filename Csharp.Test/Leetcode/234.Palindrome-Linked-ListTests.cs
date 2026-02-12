using Csharp_Exercise;
using Xunit;

namespace Csharp.Test.Leetcode
{
    public class PalindromeListTests
    {
        [Fact]
        public void IsPalindromeListTests()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(true, solution.IsPalindrome1());
            Assert.Equal(true, solution.IsPalindrome());
        }
    }
}
