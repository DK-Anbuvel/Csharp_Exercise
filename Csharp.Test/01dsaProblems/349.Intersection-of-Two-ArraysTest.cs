namespace Csharp.Test.Leetcode
{
    public class Test349
    {

        [Fact]
        public void ArrayIntersectionTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal([2, 2], solution.Intersection1([1, 2, 2, 1], [2, 2]));
        }
    }
}