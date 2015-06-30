using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

// For example,
// S = "ADOBECODEBANC"
// T = "ABC"

// Minimum window is "BANC".

// Note:
// If there is no such window in S that covers all characters in T, return the emtpy string "".
// If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.

// https://leetcode.com/problems/minimum-window-substring/
namespace LocalLeet
{
    public class Q076
    {
        public string MinWindow(string src, string target)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var c in target)
            {
                dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            }
            int answerStart = 0;
            int answerLength = int.MaxValue;
            int left = 0;
            int right = 0;
            while (right < src.Length)
            {
                if (dict.ContainsKey(src[right]))
                {
                    dict[src[right]] = dict[src[right]] - 1;
                }
                if (dict.All(kvp => kvp.Value <= 0)) // left..right covers all
                {
                    // now move left forward, until not cover
                    while (left <= right)
                    {
                        if (dict.ContainsKey(src[left]))
                        {
                            dict[src[left]] += 1;
                            if (dict[src[left]] == 1) // potential answer
                            {
                                if (answerLength > (right - left + 1))
                                {
                                    answerLength = right - left + 1;
                                    answerStart = left;
                                }
                                left++;
                                break;
                            }
                        }
                        left++;
                    }
                }
                right++;
            }
            if (answerLength == int.MaxValue)
            {
                return "";
            }
            return src.Substring(answerStart, answerLength);
        }

        [Fact]
        public void Q076_MinimumWindowSubstring()
        {
            TestHelper.Run(input => "\"" + MinWindow(input[0].Deserialize(), input[1].Deserialize()) + "\"");
        }
    }
}
