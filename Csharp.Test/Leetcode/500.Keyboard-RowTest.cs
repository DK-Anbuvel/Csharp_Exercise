
namespace Csharp.Test.Leetcode
{
    public class Test500
    {

        [Fact]
        public void FindWordsTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(["Alaska", "Dad"], solution.FindWords(["Hello", "Alaska", "Dad", "Peace"]));

        }
    }
}
