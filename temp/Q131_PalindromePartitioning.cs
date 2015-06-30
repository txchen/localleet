using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s, partition s such that every substring of the partition is a palindrome.

// Return all possible palindrome partitioning of s.

// For example, given s = "aab",
// Return

//   [
//     ["aa","b"],
//     ["a","a","b"]
//   ]

namespace LocalLeet
{
    public class Q131_PalindromePartitioning
    {
        public string[][] Partition(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return new string[0][];
            }
            // dp[i, j] == true, means input[i..j] is palindrome
            bool[,] dp = new bool[input.Length, input.Length];
            for (int end = 0; end < input.Length; end++)
            {
                for (int start = 0; start <= end; start++)
                {
                    if (input[start] == input[end] && (end - start <= 2 || dp[start + 1, end - 1]))
                    {
                        dp[start, end] = true;
                    }
                }
            }
            // now use the dp, scan and get result;
            return GetAnswer(dp, input.Length, 0, input);
        }

        private string[][] GetAnswer(bool[,] dp, int length, int start, string input)
        {
            List<string[]> answer = new List<string[]>();
            if (start == length)
            {
                return new string[1][];
            }
            for (int j = start; j < length; j++)
            {
                if (dp[start, j])
                {
                    string current = input.Substring(start, j - start + 1);
                    string[][] nexts = GetAnswer(dp, length, j + 1, input);
                    foreach (var arr in nexts)
                    {
                        List<string> a = new List<string>();
                        a.Add(current);
                        if (arr != null)
                        {
                            a.AddRange(arr);
                        }
                        answer.Add(a.ToArray());
                    }
                }
            }
            return answer.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Partition(input[0].Deserialize()));
        }

        [Fact]
        public void Q131_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
