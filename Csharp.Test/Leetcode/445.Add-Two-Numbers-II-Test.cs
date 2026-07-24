namespace Csharp.Test.Leetcode
{
    public class Test445
    {
        [Fact]
        public void AddTwoNumbersTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            solution.AddTwoNumbersI(null,null);
            solution.AddTwoNumbers();
        }
    }
}
