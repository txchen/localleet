using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement regular expression matching with support for '.' and '*'.

// '.' Matches any single character.
// '*' Matches zero or more of the preceding element.

// The matching should cover the entire input string (not partial).

// The function prototype should be:
// bool isMatch(const char *s, const char *p)

// Some examples:
// isMatch("aa","a") ? false
// isMatch("aa","aa") ? true
// isMatch("aaa","aa") ? false
// isMatch("aa", "a*") ? true
// isMatch("aa", ".*") ? true
// isMatch("ab", ".*") ? true
// isMatch("aab", "c*a*b") ? true

// https://leetcode.com/problems/regular-expression-matching/
namespace LocalLeet
{
    public class Q010_RegularExpressionMatching
    {
        public bool IsMatch(string input, string pattern)
        {
            return IsMatchInt(input, 0, pattern, 0);
        }

        private bool IsMatchInt(string input, int inputIndex, string pattern, int patternIndex)
        {
            if (patternIndex >= pattern.Length)
            {
                return input.Length == inputIndex;
            }

            if (patternIndex == pattern.Length - 1 || pattern[patternIndex + 1] != '*') // no star case
            {
                if (inputIndex >= input.Length)
                {
                    return false;
                }
                if (input[inputIndex] == pattern[patternIndex] || pattern[patternIndex] == '.')
                {
                    return IsMatchInt(input, inputIndex + 1, pattern, patternIndex + 1);
                }
                return false;
            }
            else // star case
            {
                while (inputIndex < input.Length &&
                       (input[inputIndex] == pattern[patternIndex] || pattern[patternIndex] == '.'))
                {
                    if (IsMatchInt(input, inputIndex, pattern, patternIndex + 2))
                    {
                        return true;
                    }
                    inputIndex++;
                }
                return IsMatchInt(input, inputIndex, pattern, patternIndex + 2);
            }
        }

        [Fact]
        public void Q010_Small()
        {
            TestHelper.Run(input =>
                IsMatch(input[0].Deserialize(), input[1].Deserialize()).ToString().ToLower()
            );
        }
    }
}
