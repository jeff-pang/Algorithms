using System;
using Xunit;

namespace Manacher.Tests
{
    public class LongestPalindromeTests
    {
        [Fact]
        public void palindrome1()
        {
            string input = "abaabc";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            Assert.Equal("baab", palindrome);
        }


        [Fact]
        public void palindrome2()
        {
            string input = "babad";
            
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            var expected = new[] { "bab", "aba" };
            Assert.Single(expected, palindrome);
        }

        [Fact]
        public void palindrome3()
        {
            string input = "cbbd";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            Assert.Equal("bb", palindrome);
        }

        [Fact]
        public void palindrome4()
        {
            string input = "a";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            Assert.Equal("a", palindrome);
        }

        [Fact]
        public void palindrome5()
        {
            string input = "ac";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            var expected = new[] { "a", "c" };
            Assert.Single(expected, palindrome);
        }


        [Fact]
        public void palindrome6()
        {
            string input = "bb";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            Assert.Equal("bb", palindrome);
        }
        [Fact]
        public void palindrome7()
        {
            string input = "ccc";
            var ans = new Answer();
            string palindrome = ans.FindPalindrome(input);
            Assert.Equal("ccc", palindrome);
        }
    }
}