
namespace Csharp.Test.Leetcode
{
    public class Test506
    {

        [Fact]
        public void FindRelativeRanksTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();
            Assert.Equal(["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"], solution.FindRelativeRanks2([10, 3, 8, 9, 4]));

        }
    }
}
  