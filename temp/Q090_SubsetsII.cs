using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a collection of integers that might contain duplicates, S, return all possible subsets.

// Note:

// Elements in a subset must be in non-descending order.
// The solution set must not contain duplicate subsets.
// For example,
// If S = [1,2,2], a solution is:

// [
//   [2],
//   [1],
//   [1,2,2],
//   [2,2],
//   [1,2],
//   []
// ]

namespace LocalLeet
{
    public class Q090_SubsetsII
    {
        public int[][] SubsetsWithDup(int[] num)
        {
            List<int[]> result = new List<int[]>();
            result.Add(new int[0]);
            num = num.OrderBy(a => a).ToArray(); // sort not necessary, just to pass the test
            for (int i = 0; i < num.Length; )
            {
                int currentEle = num[i];
                int currentEleCount = 0;
                while (i < num.Length && num[i] == currentEle) // count the number of current element
                {
                    i++;
                    currentEleCount++;
                }
                int existingCount = result.Count;
                for (int j = 0; j < existingCount; j++) // take out existing results, append current
                {
                    for (int n = 1; n <= currentEleCount; n++)
                    {
                        var toAppend = Enumerable.Range(1, n).Select(q => currentEle).ToArray();
                        result.Add(result[j].Concat(toAppend).ToArray());
                    }
                }
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SubsetsWithDup(input[0].ToIntArray()));
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
        public void Q090_Small()
        {
            TestHelper.Run(s => SolveQuestion(s), specialAssertAction: AreIntArrayArrayEqual);
        }
    }
}
