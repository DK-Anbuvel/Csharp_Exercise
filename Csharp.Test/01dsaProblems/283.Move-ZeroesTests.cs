using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test202
    {

        [Fact]
        public void MoveZeroTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            solution.MoveZeroes([0, 3, 0, 0, 3]);
            solution.MoveZeroes([0,1]);
            solution.MoveZeroes([0,1,0,1]);
            solution.MoveZeroes([1,0]);
            solution.MoveZeroes([1,0,1]);
            solution.MoveZeroes1([0, 3, 0, 0, 3]);
        }
    }
}
