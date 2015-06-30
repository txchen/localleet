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
    public class Q039
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

        [Fact]
        public void Q039_CombinationSum()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(CombinationSum(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
