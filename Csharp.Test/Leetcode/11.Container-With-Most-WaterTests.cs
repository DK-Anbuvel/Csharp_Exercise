using Csharp.Test.MockInput;
using Csharp_Exercise;
using Xunit;

namespace Csharp.Test.Leetcode
{
    public class ContainerWithMostWater
    {
        [Fact]
        public void MaxAreaTests()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();
            var MockData = new ArraryMock();
            // Act & Assert
            Assert.Equal(49, solution.MaxArea3([2, 3, 4, 4]));
            Assert.Equal(49, solution.MaxArea2([2, 3, 4, 4]));
            Assert.Equal(49, solution.MaxArea1(MockData.Intarrary));
            Assert.Equal(8, solution.MaxArea(MockData.Intarrary));
            Assert.Equal(8, solution.MaxArea([2,3,4,4]));
            
        }
    }
}
