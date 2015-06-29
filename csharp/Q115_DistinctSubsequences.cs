using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string S and a string T, count the number of distinct subsequences of T in S.

// A subsequence of a string is a new string which is formed from the original string by deleting some
// (can be none) of the characters without disturbing the relative positions of the remaining characters.
// (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).

// Here is an example:
// S = "rabbbit", T = "rabbit"

// Return 3.

namespace LocalLeet
{
    public class Q115_DistinctSubsequences
    {
        public int NumDistinct(string src, string tgt)
        {
            // dp[x, y] means NumDistinct(src.SubString(0, x), tgt.SubString(0, y))
            // dp[x, 0] = 1
            // dp[x, y] = src[x-1] == tgt[y-1] ? dp[x-1, y-1] + dp[x-1, y] : dp[x-1, y]
            // answer = dp[src.Length, tgt.Length]
            int[,] dp = new int[src.Length + 1, tgt.Length + 1];
            for (int i = 0; i < src.Length + 1; i++)
            {
                dp[i, 0] = 1;
            }
            for (int x = 1; x <= src.Length; x++)
            {
                for (int y = 1; y <= tgt.Length; y++)
                {
                    dp[x, y] = src[x - 1] == tgt[y - 1] ?
                        dp[x - 1, y - 1] + dp[x - 1, y] :
                        dp[x - 1, y];
                }
            }
            return dp[src.Length, tgt.Length];
        }

        public string SolveQuestion(string input)
        {
            return NumDistinct(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString();
        }

        [Fact]
        public void Q115_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q115_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
