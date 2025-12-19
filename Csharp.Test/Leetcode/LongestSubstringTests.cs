using Csharp_Exercise.Leetcode;
using Xunit;

namespace Csharp.Test.Leetcode
{
    public class LongestSubstringTests
    {
        [Fact]
        public void LengthOfLongestSubstring_ShouldReturnCorrectLength()
        {
            // Arrange
            var solution = new _3();

            // Act & Assert
            Assert.Equal(3, solution.LengthOfLongestSubstring("abcabcbb")); // "abc" is the longest substring
            Assert.Equal(1, solution.LengthOfLongestSubstring("bbbbb"));   // "b" is the longest substring
            Assert.Equal(3, solution.LengthOfLongestSubstring("pwwkew"));  // "wke" is the longest substring
            Assert.Equal(0, solution.LengthOfLongestSubstring(""));        // Empty string
            Assert.Equal(5, solution.LengthOfLongestSubstring("abcde"));   // Entire string is unique
        }

        [Fact]
        public void LengthOfLongestSubstring_ShouldHandleEdgeCases()
        {
            // Arrange
            var solution = new _3();

            // Act & Assert
            Assert.Equal(0, solution.LengthOfLongestSubstring(null));      // Null input
            Assert.Equal(2, solution.LengthOfLongestSubstring("aab"));     // "ab" is the longest substring
            Assert.Equal(4, solution.LengthOfLongestSubstring("aabcdabc")); // "abcd" is the longest substring
        }
    }
}