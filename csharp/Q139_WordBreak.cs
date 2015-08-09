using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.
//
// For example, given
// s = "leetcode",
// dict = ["leet", "code"].
//
// Return true because "leetcode" can be segmented as "leet code".

// https://leetcode.com/problems/word-break/
namespace LocalLeet
{
    public class Q139
    {
        public bool WordBreak(string s, HashSet<string> dict)
        {
            if (dict.Contains(s)) return true;
            bool[] mark = new bool[s.Length + 1];
            dfs(s, 0, dict, mark);
            return mark[s.Length];
        }

        private bool dfs(string s, int i, HashSet<string> dict, bool[] mark)
        {
            for (int j = i + 1; j <= s.Length; j++)
            {
                if (dict.Contains(s.Substring(i, j - i)) && !mark[j])
                {
                    mark[j] = true;
                    if (j == s.Length)
                    {
                        return true;
                    }
                    dfs(s, j, dict, mark);
                }
            }
            return false;
        }

        [Fact]
        public void Q139_WordBreak()
        {
            TestHelper.Run(input =>
                WordBreak(input[0].Deserialize(), input[1].ToStringHashSet()).ToString().ToLower());
        }
    }
}
