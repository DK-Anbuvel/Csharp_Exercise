using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test7
    {
        [Fact]
        public void ReverseTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal(0, solution.Reverse(-2147483648));
            Assert.Equal(0, solution.Reverse(2147483647));
            Assert.Equal(0, solution.Reverse(1534236469));
            Assert.Equal(233, solution.Reverse(2147483647));
            Assert.Equal(233, solution.Reverse(332));
        }
    }
}
