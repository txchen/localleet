using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given two words (start and end), and a dictionary,
// find the length of shortest transformation sequence from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
// return its length 5.

// Note:

// Return 0 if there is no such transformation sequence.
// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LocalLeet
{

    public class Q127_WordLadder
    {
        public int LadderLength(string start, string end, string[] dict)
        {
            List<string> currentStarts = new List<string>() { start };
            int currentLength = 1;
            HashSet<string> currentDict = new HashSet<string>(dict.Where(w => w != start));
            currentDict.Add(end); // put end into dict as well
            while (currentStarts.Count > 0)
            {
                if (currentStarts.Any(s => s == end))
                {
                    return currentLength;
                }
                currentStarts = GetNextMoves(currentDict, currentStarts);
                currentLength++;
            }
            return 0;
        }

        private string letters = "abcdefghijklmnopqrstuvwxyz";
        private List<string> GetNextMoves(HashSet<string> dict, List<string> starts)
        {
            List<string> nextStarts = new List<string>();
            foreach (var start in starts)
            {
                // use hash to speed up the detection
                for (int i = 0; i < start.Length; i++)
                {
                    var charArr = start.ToCharArray();
                    for (int j = 0; j < 26; j++)
                    {
                        charArr[i] = letters[j];
                        string s = new string(charArr);
                        if (dict.Contains(s))
                        {
                            nextStarts.Add(s);
                            dict.Remove(s);
                        }
                    }
                }
            }
            return nextStarts;
        }

        public string SolveQuestion(string input)
        {
            return LadderLength(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize(),
                input.GetToken(2).ToStringArray()).ToString();
        }

        [TestMethod]
        public void Q127_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q127_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
