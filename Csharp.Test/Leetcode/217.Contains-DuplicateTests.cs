namespace Csharp.Test.Leetcode
{
    public class Test217
    {
        [Fact]
        public void IsContainDuplicate()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(true, solution.ContainsDuplicate4([1, 2, 3, 1]));
        }
    }
}
