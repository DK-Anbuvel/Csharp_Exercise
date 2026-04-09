namespace Csharp.Test.Leetcode
{
    public class Test219
    {
        [Fact]
        public void IsContainDuplicateII()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
           // Assert.Equal(true, solution.ContainsNearbyDuplicate1([1, 2, 3, 1], 4));
            Assert.Equal(true, solution.ContainsNearbyDuplicate2([1, 2, 3, 1, 2, 3], 2));
            Assert.Equal(true, solution.ContainsNearbyDuplicate1([4, 1, 2, 3, 1, 5], 3));
            Assert.Equal(true, solution.ContainsNearbyDuplicate([1, 2, 3, 1, 2, 3], 2));
            Assert.Equal(true, solution.ContainsNearbyDuplicate([1, 0, 1, 1], 1));
            Assert.Equal(true, solution.ContainsNearbyDuplicate([1, 2, 3, 1], 3));
           
        }
    }
}