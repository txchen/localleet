using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an input string, reverse the string word by word.
//
// For example,
// Given s = "the sky is blue",
// return "blue is sky the".
//
// Clarification:
// What constitutes a word?
// A sequence of non-space characters constitutes a word.
// Could the input string contain leading or trailing spaces?
// Yes. However, your reversed string should not contain leading or trailing spaces.
// How about multiple spaces between two words?
// Reduce them to a single space in the reversed string.

// https://leetcode.com/problems/reverse-words-in-a-string/
namespace LocalLeet
{
    public class Q151
    {
        public string ReverseWords(string s) {
            var rss = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => new string(i.Reverse().ToArray()));
            return new string(String.Join(" ", rss).Trim().Reverse().ToArray());
        }

        [Fact]
        public void Q135_Candy()
        {
            TestHelper.Run(input => "\"" + ReverseWords(input.EntireInput.Deserialize()) + "\"");
        }
    }
}
