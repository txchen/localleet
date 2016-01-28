using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given two strings s and t, write a function to determine if t is an anagram of s.
//
// For example,
// s = "anagram", t = "nagaram", return true.
// s = "rat", t = "car", return false.
//
// Note:
// You may assume the string contains only lowercase alphabets.

// https://leetcode.com/problems/valid-anagram/
namespace LocalLeet
{
    public class Q242
    {
        public bool IsAnagram(string s, string t)
        {
            return new string(s.ToCharArray().OrderBy(c => c).ToArray())
                .Equals(new string(t.ToCharArray().OrderBy(c => c).ToArray()));
        }

        [Fact]
        public void Q242_ValidAnagram()
        {
            TestHelper.Run(input => IsAnagram(input[0].Deserialize(), input[1].Deserialize()).ToString().ToLower());
        }
    }
}
