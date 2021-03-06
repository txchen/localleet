using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

// For example,
// "A man, a plan, a canal: Panama" is a palindrome.
// "race a car" is not a palindrome.

// Note:
// Have you consider that the string might be empty? This is a good question to ask during an interview.

// For the purpose of this problem, we define empty string as valid palindrome.

// https://leetcode.com/problems/valid-palindrome/
namespace LocalLeet
{
    public class Q125
    {
        public bool IsPalindrome(string s)
        {
            var arr = s.Where(c => char.IsLetterOrDigit(c)).Select(c => Char.ToLower(c)).ToArray();
            if (arr.Length == 0)
            {
                return true;
            }
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left++] != arr[right--])
                {
                    return false;
                }
            }
            return true;
        }

        [Fact]
        public void Q125_ValidPalindrome()
        {
            TestHelper.Run(input => IsPalindrome(input.EntireInput.Deserialize()).ToString().ToLower());
        }
    }
}
