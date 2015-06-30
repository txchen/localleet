using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of strings, return all groups of strings that are anagrams.

// Note: All inputs will be in lower-case.

namespace LocalLeet
{
    public class Q049_Anagrams
    {
        public string[] Anagrams(string[] strs)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string norm = new string(strs[i].OrderBy(c => c).ToArray());
                if (dict.ContainsKey(norm))
                {
                    dict[norm].Add(i);
                }
                else
                {
                    dict[norm] = new List<int>() { i };
                }
            }
            List<int> answerIndexes = new List<int>();
            foreach (var kvp in dict)
            {
                if (kvp.Value.Count > 1)
                {
                    answerIndexes.AddRange(kvp.Value);
                }
            }
            return answerIndexes.Select(i => strs[i]).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Anagrams(input[0].ToStringArray()));
        }

        private bool AreStringsEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArray().OrderBy(s => s).ToArray();
            var arrActual = actual.ToStringArray().OrderBy(s => s).ToArray();
            if (arrExp.Length != arrActual.Length)
            {
                return false;
            }
            for (int i = 0; i < arrExp.Length; i++)
            {
                if (arrExp[i] != arrActual[i])
                {
                    return false;
                }
            }
            return true;
        }

        [Fact]
        public void Q049_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringsEqual);
        }
    }
}
