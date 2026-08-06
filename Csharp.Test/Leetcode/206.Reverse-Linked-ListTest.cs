using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Csharp.Test.Leetcode
{
    public class Testcase206
    {
        [Fact]
        public void ReverseListTest()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();
            //Act

            // Act & Assert  head = [1,2,3,4,5]
           var result5 = solution.ReverseList5();
           var result3 = solution.ReverseList2();
           var result4 = solution.ReverseList3();
           var result = solution.ReverseList();

        }
    }
}
