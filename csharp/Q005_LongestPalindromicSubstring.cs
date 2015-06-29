using System;
using System.Collections.Generic;
using System.Linq;

// Given a string S, find the longest palindromic substring in S.
// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

namespace LocalLeet
{

    public class Q005_LongestPalindromicSubstring
    {
        string LongestPalindrome(string input)
        {
            int longestLength = 0;
            int longestLeft = 0;
            int right = 0;
            bool[,] dp = new bool[input.Length, input.Length];
            while (right < input.Length)
            {
                for (int left = 0; left <= right; left++)
                {
                    if (input[left] == input[right])
                    {
                        int length = right - left + 1;
                        if ((length <= 3) || dp[left + 1, right - 1]) // then it is palindrome
                        {
                            dp[left, right] = true;
                            if (length > longestLength)
                            {
                                longestLength = length;
                                longestLeft = left;
                            }
                        }
                    }
                }
                right++;
            }
            // dp[i, j] = true means input[i:j] is palindrome
            return input.Substring(longestLeft, longestLength);
        }

        public string SolveQuestion(string input)
        {
            return "\"" + LongestPalindrome(input.Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q005_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q005_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
