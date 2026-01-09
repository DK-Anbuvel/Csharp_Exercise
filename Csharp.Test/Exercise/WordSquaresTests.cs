using Csharp_Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test 
{
    public partial class ExerciseTest
    {
        [Fact]
        public void LargestEvenTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Exercise();

            // Act & Assert
            Assert.Empty(solution.WordSquares(["able", "area", "echo", "also"]));
        }
    }
}
