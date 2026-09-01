using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Test.Leetcode
{
    public class Test5
    {

        [Fact]
        public void LengthOfLongestSubstring_ShouldReturnCorrectLength()
        {
            // Arrange
            var solution = new Csharp_Exercise.Leecodes();

            // Act & Assert
            Assert.Equal("aba",solution.LongestPalindrome1("babad")); // "abc" is the longest substring
            Assert.Equal("aba",solution.LongestPalindrome3("babad"));   
            Assert.Equal("aba",solution.LongestPalindrome("pwwkew"));  // "wke" is the longest substring
            Assert.Equal("aba",solution.LongestPalindrome(""));        // Empty string
            Assert.Equal("aba",solution.LongestPalindrome("abcde"));   // Entire string is unique
        }
    }
}
