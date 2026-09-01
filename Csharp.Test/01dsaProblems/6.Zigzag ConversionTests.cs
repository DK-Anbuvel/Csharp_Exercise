using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test6
    {


        [Fact]
        public void zigzagConversionTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal("PAHNAPLSIIGYIR", solution.Convert0("PAYPALISHIRING",3)); 
            Assert.Equal("PAHNAPLSIIGYIR", solution.Convert4("PAYPALISHIRING",3)); 

        }
    }
}
