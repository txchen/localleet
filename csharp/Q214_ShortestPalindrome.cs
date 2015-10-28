using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.
//
// For example:
//
// Given "aacecaaa", return "aaacecaaa".
//
// Given "abcd", return "dcbabcd".

// https://leetcode.com/problems/shortest-palindrome/
namespace LocalLeet
{
    public class Q214
    {
        public string ShortestPalindrome(string s)
        {
            // s + '#' + reverse(s)
            string l = s + "#" + new string(s.Reverse().ToArray());
            // then build the next array (in KMP) of this new string
            int[] nextArr = new int[l.Length];
            for (int i = 1; i < l.Length; i++)
            {
                int j = nextArr[i - 1];
                while (j > 0 && l[j] != l[i])
                {
                    j = nextArr[j - 1]; // magic
                }
                nextArr[i] = j + (l[j] == l[i] ? 1 : 0);
            }
            // the last element in the next array, means the longest palindrome started from beginning
            int pLength = nextArr[l.Length - 1];
            return new string(s.Substring(pLength).Reverse().ToArray()) + s;
        }

        [Fact]
        public void Q214_ShortestPalindrome()
        {
            TestHelper.Run(input => ShortestPalindrome(input.EntireInput.Deserialize()).SerializeString());
        }
    }
}
