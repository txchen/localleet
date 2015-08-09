using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s and a dictionary of words dict, add spaces in s to construct a sentence where each word is a valid dictionary word.
//
// Return all such possible sentences.
//
// For example, given
// s = "catsanddog",
// dict = ["cat", "cats", "and", "sand", "dog"].
//
// A solution is ["cats and dog", "cat sand dog"].

// https://leetcode.com/problems/word-break-ii/
namespace LocalLeet
{
    public class Q140
    {
        public string[] WordBreak(string s, HashSet<string> dict) {
            List<string> answer = new List<string>();
            for (int j = s.Length - 1; j >= 0; j--)
            {
                if (dict.Contains(s.Substring(j)))
                {
                    break;
                }
                else
                {
                    if (j == 0)
                    {
                        return answer.ToArray();
                    }
                }
            }
            for (int i = 1; i <= s.Length; i++)
            {
                if (dict.Contains(s.Substring(0, i)))
                {
                    var nextAnswers = WordBreak(s.Substring(i), dict);
                    foreach (var na in nextAnswers)
                    {
                        answer.Add(s.Substring(0, i) + " " + na);
                    }
                }
            }
            if (dict.Contains(s))
            {
                answer.Add(s);
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q140_WordBreakII()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(WordBreak(input[0].Deserialize(), input[1].ToStringHashSet())),
                specialAssertAction: TestHelper.AreStringArraysEqual);
        }
    }
}
