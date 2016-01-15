using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string S, find the longest palindromic substring in S.
// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

// https://leetcode.com/problems/longest-palindromic-substring/
namespace LocalLeet
{
    public class Q005
    {
        string LongestPalindrome(string input)
        {
            // Manacher's Algorithm, https://en.wikipedia.org/wiki/Longest_palindromic_substring
            if (input.Length < 2)
            {
                return input;
            }
            string s = "|#" + String.Join("#", input.ToCharArray()) + "##"; // add some magic
            int[] dp = new int[s.Length];
            // S | # 1 # 2 # 2 # 1 # 2 # 3 # 2 # 1 # #
            // P 0 1 2 1 2 5 2 1 4 1 2 1 6 1 2 1 2 1 0
            // P[i] - 1 is the length of palindrome
            int center = 0, mx = 0; // mx = i + dp[i], right edge of palindrome + 1
            for (int i = 1; i < s.Length - 1; i++)
            {
                dp[i] = mx <= i ? 1 : Math.Min(mx - i, dp[center - (i - center)]);
                while (s[i + dp[i]] == s[i - dp[i]])
                {
                    dp[i]++;
                }
                if (i + dp[i] > mx)
                {
                    mx = i + dp[i];
                    center = i;
                }
            }
            center = Array.IndexOf(dp, dp.Max());
            int length = dp[center] - 1;
            return input.Substring((center - length) / 2, length);
        }

        string LongestPalindromeO2(string input)
        {
            int longestLength = 0;
            int longestLeft = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int left = i;
                int right = i;
                while (right < input.Length - 1 && input[left] == input[right + 1])
                {
                    right++;
                }
                while (left >= 1 && right < input.Length - 1 && input[left - 1] == input[right + 1])
                {
                    left--;
                    right++;
                }
                if (right - left + 1 > longestLength)
                {
                    longestLength = right - left + 1;
                    longestLeft = left;
                }
            }
            return input.Substring(longestLeft, longestLength);
        }

        [Fact]
        public void Q005_LongestPalindromicSubstring()
        {
            TestHelper.Run(input =>
                "\"" + LongestPalindrome(input.EntireInput.Deserialize()) + "\"");
        }
    }
}
