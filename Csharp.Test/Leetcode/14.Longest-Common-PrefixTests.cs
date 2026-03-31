namespace Csharp.Test.Leetcode
{
    public class Leetcode14
    {
        [Fact]
        public void LongestCommonPrefix()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal("flow", solution.LongestCommonPrefix4(["flower", "flower", "flower", "flower"]));
            Assert.Equal("flow", solution.LongestCommonPrefix4(["abc", "ab"]));
            Assert.Equal("flow", solution.LongestCommonPrefix4(["flow", "flow", "flow"]));
            Assert.Equal("flow", solution.LongestCommonPrefix4(["a"]));
            Assert.Equal("flow", solution.LongestCommonPrefix4(["flower", "flow", "flight"]));
            Assert.Equal("flow", solution.LongestCommonPrefix2(["flower", "flow", "flight"]));
            Assert.Equal("flow", solution.LongestCommonPrefix1(["flower", "flow", "flight"]));
        }
    }
}