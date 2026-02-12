using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Testcase202
    {
        [Fact]
        public void IsHappyTests()
        {
           // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(true, solution.IsHappy1(2));

        }
    }
}
