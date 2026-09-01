
namespace Csharp.Test.Leetcode
{
    public class Test463
    {

        [Fact]
        public void IslandPerimeterTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            int[][] mock = 
            {
               new int[] { 0, 1, 0, 0 },
              new int[]    { 1, 1, 1, 0 },
             new int[]     { 0, 1, 0, 0 },
               new int[]   { 1, 1, 0, 0 }
           };
            // Act & Assert
            Assert.Equal(16, solution.IslandPerimeter1(mock));
        }
    }
}
