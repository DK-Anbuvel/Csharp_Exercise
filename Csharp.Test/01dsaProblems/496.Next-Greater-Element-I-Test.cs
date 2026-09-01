
namespace Csharp.Test.Leetcode
{
    public class Test496
    {

        [Fact]
        public void NextGreaterElementTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal([-1,3,-1], solution.NextGreaterElement4([4, 1, 2], [1, 3, 4, 2]));
            Assert.Equal([-1,3,-1], solution.NextGreaterElement3([4, 1, 2], [1, 3, 4, 2]));
        }
    }
}
