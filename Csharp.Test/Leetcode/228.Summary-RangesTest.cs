namespace Csharp.Test.Leetcode
{
    public class Test228
    {
        [Fact]
        public void SummaryRangesTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            // Assert.Equal(true, solution.ContainsNearbyDuplicate1([1, 2, 3, 1], 4));
            Assert.Equal(new List<string> { "1->3","" }, solution.SummaryRanges([0, 1, 2, 4, 5, 7]));
            Assert.Equal(new List<string> { "1->3","" }, solution.SummaryRanges([0, 2, 3, 4, 6, 8, 9]));
        }
    }
}
