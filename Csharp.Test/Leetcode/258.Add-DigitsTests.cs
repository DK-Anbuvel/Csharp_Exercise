namespace Csharp.Test.Leetcode
{
    public class Testcase258
    {
        [Fact]
        public void AddDigitsTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            solution.AddDigits3(38);
            solution.AddDigits1(388);
        }
    }
}