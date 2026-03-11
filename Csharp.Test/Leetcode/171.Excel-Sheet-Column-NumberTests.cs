
namespace Csharp.Test.Leetcode
{
    public class Test171
    {
        [Fact]
        public void ExcelColumnTitleNumber()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(26, solution.TitleToNumber("Z"));
            Assert.Equal(28, solution.TitleToNumber("AB"));
            Assert.Equal(52, solution.TitleToNumber("ZY"));
            Assert.Equal(1001, solution.TitleToNumber("ALM"));
            Assert.Equal(2147483647, solution.TitleToNumber("FXSHRXW"));
        }
    }
}
