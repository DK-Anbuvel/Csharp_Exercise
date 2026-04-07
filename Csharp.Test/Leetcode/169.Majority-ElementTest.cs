namespace Csharp.Test.Leetcode
{
    public class Test169
    {
        [Fact]
        public void ExcelColumnTitleNumber()
        { // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
          // Assert.Equal(26, solution.MajorityElement3([3, 2, 3]));
            Assert.Equal(26, solution.MajorityElement3([2, 2, 1, 1, 1, 2, 2]));
        }
    }
}
