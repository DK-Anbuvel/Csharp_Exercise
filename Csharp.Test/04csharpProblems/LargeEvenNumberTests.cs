using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Exercise
{
    public partial class ExerciseTest
    {

        [Fact]
        public void LargestEvenTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Exercise();

            // Act & Assert
            Assert.Equal("2", solution.LargestEven("21"));
            Assert.Equal("1112", solution.LargestEven("1112"));
            Assert.Equal("22", solution.LargestEven("221"));
            Assert.Equal("2", solution.LargestEven("2"));

        }
    }
}
