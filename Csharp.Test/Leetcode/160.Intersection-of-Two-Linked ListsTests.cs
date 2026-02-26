using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Testcase160
    {
        [Fact]
        public void LinkedListIntersectionTest()
        {           // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            solution.GetIntersectionNode1();
            solution.GetIntersectionNode();
        }
    }
}
