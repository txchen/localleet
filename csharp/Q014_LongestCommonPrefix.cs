using System;
using System.Collections.Generic;
using System.Linq;

// Write a function to find the longest common prefix string amongst an array of strings.

namespace LocalLeet
{

    public class Q014_LongestCommonPrefix
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

        public string SolveQuestion(string input)
        {
            return "\"" + LongestCommonPrefix(input.ToStringArray()) + "\"";
        }

        [TestMethod]
        public void Q014_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q014_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
