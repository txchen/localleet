using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a set of candidate numbers (C) and a target number (T),
// find all unique combinations in C where the candidate numbers sums to T.

// The same repeated number may be chosen from C unlimited number of times.

// Note:

// All numbers (including target) will be positive integers.
// Elements in a combination (a1, a2, � , ak) must be in non-descending order. (ie, a1 ? a2 ? � ? ak).
// The solution set must not contain duplicate combinations.
// For example, given candidate set 2,3,6,7 and target 7,
// A solution set is:
// [7]
// [2, 2, 3]

namespace LocalLeet
{

    public class Q039_CombinationSum
    {
        public int[][] CombinationSum(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(i => i).ToArray();
            List<int[]> answer = CombinationSumInt(candidates, 0, target);
            return answer.ToArray();
        }

        private List<int[]> CombinationSumInt(int[] candidates, int startingIndex, int target)
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
            // take current
            int cur = candidates[startingIndex];
            var nextAnswers = CombinationSumInt(candidates, startingIndex, target - cur);
            nextAnswers.ForEach(a => answer.Add(new int[] { cur }.Concat(a).ToArray()));
            // not take current
            CombinationSumInt(candidates, startingIndex + 1, target).ForEach(a => answer.Add(a));
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(CombinationSum(input.GetToken(0).ToIntArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q039_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q039_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
