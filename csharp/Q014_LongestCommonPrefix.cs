using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Write a function to find the longest common prefix string amongst an array of strings.

namespace LocalLeet
{
    public class Q014
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return String.Empty;
            }
            int answer = strs[0].Length;
            for (int i = 1; i < strs.Length; i++)
            {
                int newAnswer = 0;
                for (; newAnswer < answer && newAnswer < strs[i].Length; newAnswer++)
                {
                    if (strs[0][newAnswer] != strs[i][newAnswer])
                    {
                        break;
                    }
                }
                answer = newAnswer;
            }
            return strs[0].Substring(0, answer);
        }

        [Fact]
        public void Q014_LongestCommonPrefix()
        {
            TestHelper.Run(input =>
                "\"" + LongestCommonPrefix(input[0].ToStringArray()) + "\"");
        }
    }
}
