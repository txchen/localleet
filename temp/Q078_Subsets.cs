using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a set of distinct integers, S, return all possible subsets.

// Note:
//  Elements in a subset must be in non-descending order.
//  The solution set must not contain duplicate subsets.
//  For example,
//  If S = [1,2,3], a solution is:

// [
//  [3],
//  [1],
//  [2],
//  [1,2,3],
//  [1,3],
//  [2,3],
//  [1,2],
//  []
// ]

namespace LocalLeet
{
    public class Q078
    {
        public int[][] Subsets(int[] input)
        {
            List<int[]> result = new List<int[]>();
            result.Add(new int[0]);
            input = input.OrderBy(a => a).ToArray(); // sort not necessary, just to pass the test
            foreach (var i in input)
            {
                // take out every value in results, append i, insert back to result
                int existingCount = result.Count;
                for (int j = 0; j < existingCount; j++)
                {
                    result.Add(result[j].Concat(new int[] { i }).ToArray());
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Subsets(input[0].ToIntArray()));
        }

        private bool AreIntArrayArrayEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int[][] a1 = s1.ToIntArrayArray();
            int[][] a2 = s2.ToIntArrayArray();
            a1 = a1.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            a2 = a2.OrderBy(a => a.Length).ThenBy(a => String.Join("", a)).ToArray();
            return TestHelper.Serialize(a1) == TestHelper.Serialize(a2);
        }

        [Fact]
        public void Q078_Subsets()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
