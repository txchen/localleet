using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s, partition s such that every substring of the partition is a palindrome.

// Return the minimum cuts needed for a palindrome partitioning of s.

// For example, given s = "aab",
// Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.

namespace LocalLeet
{
    public class Q132
    {
        public int MinCut(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }
            // dp[i, j] == true, means input[i..j] is palindrome
            bool[,] dp = new bool[input.Length, input.Length];
            int[] answer = new int[input.Length]; // answer[i] = MinCut(input.substring(0..i))
            // populate worst cases, first
            for (int i = 0; i < input.Length; i++)
            {
                answer[i] = i; // worst case, every split is single char
            }
            for (int end = 0; end < input.Length; end++)
            {
                for (int start = 0; start <= end; start++)
                {
                    if (input[start] == input[end] && (end - start <= 2 || dp[start + 1, end - 1]))
                    {
                        dp[start, end] = true;
                        // improve answer, split into 0..start-1 and start..end
                        answer[end] = Math.Min(answer[end], start == 0 ? 0 : answer[start - 1] + 1);
                    }
                }
            }
            return answer[input.Length - 1];
        }

        private int GetAnswer(bool[,] dp, int start, int end)
        {
            if (dp[start, end])
            {
                return 0; // no need to cut
            }
            int answer = int.MaxValue;
            for (int cut = start; cut < end; cut++)
            {
                answer = Math.Min(answer, 1 + GetAnswer(dp, start, cut) + GetAnswer(dp, cut + 1, end));
                if (answer == 1)
                {
                    return 1;
                }
            }
            return answer;
        }

        [Fact]
        public void Q132_PalindromePartitioningII()
        {
            TestHelper.Run(input => MinCut(input[0].Deserialize()).ToString());
        }
    }
}
