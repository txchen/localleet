using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a collection of intervals, merge all overlapping intervals.

// For example,
// Given [1,3],[2,6],[8,10],[15,18],
// return [1,6],[8,10],[15,18].

namespace LocalLeet
{
    public class Q056_MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return new int[0][];
            }
            var answer = new List<int[]>();
            // sort the input first
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            int[] temp = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] > temp[1])
                {
                    answer.Add(temp);
                    temp = intervals[i];
                }
                else // merge
                {
                    temp = new int[] { Math.Min(intervals[i][0], temp[0]), Math.Max(intervals[i][1], temp[1]) };
                }
            }
            answer.Add(temp);
            return answer.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Merge(input[0].ToIntArrayArray()));
        }

        [Fact]
        public void Q056_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
