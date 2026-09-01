
namespace Csharp.Test.Leetcode
{
    public class Test566
    {

        [Fact]
        public void MatrixReshapeTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();
            Assert.Equal([[1, 2, 3, 4]], solution.MatrixReshape1([[1, 2], [3, 4]],1,4));

        }
    }
}
