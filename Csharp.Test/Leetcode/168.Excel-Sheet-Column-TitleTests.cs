
namespace Csharp.Test.Leetcode
{
    public class Test168
    {
        [Fact]
        public void ExcelColumnTitle ()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal("AZ", solution.ConvertToTitle(52)); 
            Assert.Equal("BA", solution.ConvertToTitle(53)); 
            Assert.Equal("AB", solution.ConvertToTitle(28)); 
            Assert.Equal("FXSHRXW", solution.ConvertToTitle(2147483647)); //EXSHRXW
            Assert.Equal("ZY", solution.ConvertToTitle(701));
            Assert.Equal("ALM", solution.ConvertToTitle(1001));

        }
    }
}
