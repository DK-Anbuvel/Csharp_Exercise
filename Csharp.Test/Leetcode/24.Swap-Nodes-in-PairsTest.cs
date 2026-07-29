namespace Csharp.Test.Leetcode
{
    public class Test24
    {
        [Fact]
        public void SwapPairsTests()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            // Assert.Equal(true, solution.IsPalindrome1());
            solution.SwapPairs2();
            solution.SwapPairs1();
            solution.SwapPairs();
        }
    }
}
