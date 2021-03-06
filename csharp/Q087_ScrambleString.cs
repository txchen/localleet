using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.

// Below is one possible representation of s1 = "great":

//     great
//    /    \
//   gr    eat
//  / \    /  \
// g   r  e   at
//            / \
//           a   t
// To scramble the string, we may choose any non-leaf node and swap its two children.

// For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

//     rgeat
//    /    \
//   rg    eat
//  / \    /  \
// r   g  e   at
//            / \
//           a   t
// We say that "rgeat" is a scrambled string of "great".

// Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

//     rgtae
//    /    \
//   rg    tae
//  / \    /  \
// r   g  ta  e
//        / \
//       t   a
// We say that "rgtae" is a scrambled string of "great".

// Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.

// https://leetcode.com/problems/scramble-string/
namespace LocalLeet
{
    public class Q087
    {
        public bool IsScramble(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            // chararray cannot compare, so convert to string and compare
            if (new string(s1.OrderBy(c => c).ToArray()) != new string(s2.OrderBy(c => c).ToArray()))
            {
                return false;
            }
            for (int leftLength = 1; leftLength < s1.Length; leftLength++)
            {
                if (IsScramble(s1.Substring(leftLength), s2.Substring(leftLength)) &&
                    IsScramble(s1.Substring(0, leftLength), s2.Substring(0, leftLength)))
                {
                    return true;
                }
                if (IsScramble(s1.Substring(0, leftLength), s2.Substring(s2.Length - leftLength)) &&
                    IsScramble(s1.Substring(leftLength), s2.Substring(0, s2.Length - leftLength)))
                {
                    return true;
                }
            }

            return false;
        }

        [Fact]
        public void Q087_ScrambleString()
        {
            TestHelper.Run(input => IsScramble(input[0].Deserialize(), input[1].Deserialize()).ToString().ToLower());
        }
    }
}
