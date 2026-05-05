
namespace Csharp.Test.Leetcode
{
    public class Test455
    {

        [Fact]
        public void FindContentChildrenTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(2, solution.FindContentChildren([10, 9, 8, 7], [5, 6, 7, 8])); 
        }
    }
}
