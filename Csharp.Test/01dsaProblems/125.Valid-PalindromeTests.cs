using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class  Test125
    {
        [Fact]
        public void IsPalindrome()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            //  Assert.Equal(true, solution.IsPalindrome125(""));
            Assert.Equal(false, solution.IsPalindrome125VII("P0"));
            Assert.Equal(false, solution.IsPalindrome125VII("0P"));
            Assert.Equal(false, solution.IsPalindrome125VII("race a car"));
            Assert.Equal(false, solution.IsPalindrome125VII("A man, a plan, a canal: Panama"));

        }
    }
}
