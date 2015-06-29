using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2.
// (each operation is counted as 1 step.)

// You have the following 3 operations permitted on a word:

// a) Insert a character
// b) Delete a character
// c) Replace a character

namespace LocalLeet
{

    public class Q072_EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            // dp[i, j] = MinDistance(word1.Substring(0, i), word2.Substring(0, j))
            // dp[0, j] = j, dp[i, 0] = i
            // dp[i, j] = Min[ (dp[i-1, j] +1), (dp[i, j-1] +1), (dp[i-1, j-1] + 0 or 1)]
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i < word1.Length + 1; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < word2.Length + 1; j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    int zeroorone = word1[i - 1] == word2[j - 1] ? 0 : 1;
                    dp[i, j] = Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1);
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + zeroorone);
                }
            }
            return dp[word1.Length, word2.Length];
        }

        public string SolveQuestion(string input)
        {
            return MinDistance(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString();
        }

        [TestMethod]
        public void Q072_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q072_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
