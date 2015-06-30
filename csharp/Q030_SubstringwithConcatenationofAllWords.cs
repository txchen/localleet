using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// You are given a string, S, and a list of words, L, that are all of the same length.
// Find all starting indices of substring(s) in S that is a concatenation
// of each word in L exactly once and without any intervening characters.

// For example, given:
// S: "barfoothefoobarman"
// L: ["foo", "bar"]

// You should return the indices: [0,9].
// (order does not matter).

namespace LocalLeet
{
    public class Q030
    {
        public int[] FindSubstring(string s, string[] l)
        {
            List<int> answer = new List<int>();
            int slotLength = l[0].Length;
            int totalLength = l.Length * slotLength;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            l.ToList().ForEach(w => dic[w] = dic.ContainsKey(w) ? dic[w] + 1 : 1);
            // optimize here, don't start from anywhere, it will be slow
            for (int i = 0; i < slotLength; i++)
            {
                var tempDic = new Dictionary<string, int>(dic);
                for (int j = 0; i + j * slotLength + slotLength <= s.Length; j++)
                {
                    string currentWord = s.Substring(i + j * slotLength, slotLength);
                    if (tempDic.ContainsKey(currentWord))
                    {
                        tempDic[currentWord] -= 1;
                    }
                    // try add back the previous word
                    if (j >= l.Length)
                    {
                        string previousWord = s.Substring(i + (j - l.Length) * slotLength, slotLength);
                        if (tempDic.ContainsKey(previousWord))
                        {
                            tempDic[previousWord] += 1;
                        }
                    }
                    if (tempDic.All(kvp => kvp.Value == 0)) // no remaining, match
                    {
                        answer.Add(i + j * slotLength - totalLength + slotLength);
                    }
                }
            }
            return answer.OrderBy(a => a).ToArray();
        }

        [Fact]
        public void Q030_SubstringwithConcatenationofAllWords()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(FindSubstring(input[0].Deserialize(), input[1].ToStringArray())));
        }
    }
}
