using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test344
    {

        [Fact]
        public void ReverseStringTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            solution.ReverseString(['a','n','b','u','v','e','l']);
        }
    }
}
