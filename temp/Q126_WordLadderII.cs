using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given two words (start and end), and a dictionary, find all shortest transformation
// sequence(s) from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// Return

//   [
//     ["hit","hot","dot","dog","cog"],
//     ["hit","hot","lot","log","cog"]
//   ]
// Note:

// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LocalLeet
{
    public class Q126_WordLadderII
    {
        public string[][] FindLadders(string start, string end, string[] dict)
        {
            Dictionary<string, List<string[]>> pathDict = new Dictionary<string, List<string[]>>();
            List<string> currentStarts = new List<string>() { start };
            HashSet<string> currentDict = new HashSet<string>(dict.Where(w => w != start));
            currentDict.Add(end); // put end into dict as well
            pathDict.Add(start, new List<string[]>() { new string[] { start } });
            while (currentStarts.Count > 0)
            {
                if (pathDict.ContainsKey(end))
                {
                    return pathDict[end].ToArray();
                }
                currentStarts = GetNextMoves(currentDict, currentStarts, pathDict);
            }
            return new string[0][];
        }

        private string letters = "abcdefghijklmnopqrstuvwxyz";
        private List<string> GetNextMoves(HashSet<string> dict, List<string> starts,
            Dictionary<string, List<string[]>> pathDict)
        {
            HashSet<string> nextStarts = new HashSet<string>();
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
                            if (!pathDict.ContainsKey(s))
                            {
                                pathDict[s] = new List<string[]>();
                            }
                            var newPaths = pathDict[start].Select(path => path.Concat(new[] { s }).ToArray()).ToArray();
                            pathDict[s].AddRange(newPaths);
                        }
                    }
                }
            }
            // remove nextStarts from dict
            dict.RemoveWhere(w => nextStarts.Contains(w));
            starts.ForEach(s => pathDict.Remove(s)); // shrink pathdict, make it a little faster
            return nextStarts.ToList();
        }

        private int CompareStringArray(string[] arr1, string[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                int res = arr1[i].CompareTo(arr2[i]);
                if (res != 0)
                {
                    return res;
                }
            }
            return 0;
        }

        private bool AreStringArrayArrayEqual(string expected, string actual)
        {
            var arrExp = expected.ToStringArrayArray().ToList();
            var arrActual = actual.ToStringArrayArray().ToList();
            arrExp.Sort(CompareStringArray);
            arrActual.Sort(CompareStringArray);
            return TestHelper.Serialize(arrExp.ToArray()) ==
                TestHelper.Serialize(arrActual.ToArray());
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FindLadders(input[0].Deserialize(),
                input[1].Deserialize(), input[0].GetToken(2).ToStringArray()));
        }

        [Fact]
        public void Q126_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
        [Fact]
        public void Q126_Large()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreStringArrayArrayEqual);
        }
    }
}
