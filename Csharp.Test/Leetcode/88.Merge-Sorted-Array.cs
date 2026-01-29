using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test88
    {
        [Fact]
        public void mergeSort()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            // solution.Merge([1, 2, 3, 0, 0, 0],3, [2, 5, 6],3);
            // solution.Merge2([5, 6, 7, 0, 0, 0],3, [2, 3, 9],3);
             solution.Merge2([1, 55, 98, 99, 0, 0],4, [2, 56],2);
             solution.Merge([1],1, [],0);
             solution.Merge([0],0, [2],1);
        }
    }
}
