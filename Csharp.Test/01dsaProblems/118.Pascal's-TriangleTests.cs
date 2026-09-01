namespace Csharp.Test.Leetcode
{
    public class Testcase118
    {
        [Fact]
        public void GenerateTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
             solution.GetRow(2);
             solution.Generate(2);
        }
    }
}
