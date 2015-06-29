using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a collection of candidate numbers (C) and a target number (T),
// find all unique combinations in C where the candidate numbers sums to T.

// Each number in C may only be used once in the combination.

// Note:

// All numbers (including target) will be positive integers.
// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
// The solution set must not contain duplicate combinations.
// For example, given candidate set 10,1,2,7,6,1,5 and target 8,
// A solution set is:
// [1, 7]
// [1, 2, 5]
// [2, 6]
// [1, 1, 6]

namespace LocalLeet
{
    public class Q040_CombinationSumII
    {
        public int[][] CombinationSum2(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(i => i).ToArray();
            List<int[]> answer = CombinationSum2Int(candidates, 0, target);
            return answer.ToArray();
        }

        private List<int[]> CombinationSum2Int(int[] candidates, int startingIndex, int target)
        {
            if (target == 0)
            {
                return new List<int[]> { new int[0] };
            }
            if (startingIndex >= candidates.Length || candidates[startingIndex] > target)
            {
                return new List<int[]>();
            }
            List<int[]> answer = new List<int[]>();
            // currentElement count
            int cur = candidates[startingIndex];
            int end = startingIndex;
            while (end < candidates.Length && candidates[end] == cur)
            {
                end++;
            }
            int currentCount = end - startingIndex;
            // take 0..count of curent element
            for (int i = currentCount; i >= 0; i--)
            {
                var curs = Enumerable.Range(0, i).Select(n => cur).ToArray();
                var nextAnswers = CombinationSum2Int(candidates, end, target - cur * i);
                foreach(var nextA in nextAnswers)
                {
                    answer.Add(curs.Concat(nextA).ToArray());
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(CombinationSum2(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [Fact]
        public void Q040_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q040_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
