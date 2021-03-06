using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

// You may assume that the intervals were initially sorted according to their start times.

// Example 1:
// Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

// Example 2:
// Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

// This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

// https://leetcode.com/problems/insert-interval/
namespace LocalLeet
{
    public class Q057
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var answer = new List<int[]>();
            int mergedLow = newInterval[0];
            int mergedHigh = newInterval[1];
            for (int i = 0; i < intervals.Length; i++)
            {
                // compare newInterval with currentInterval
                if (mergedHigh < intervals[i][0]) // i.. are all larger than newInterval, no more merge
                {
                    // write merged interval
                    answer.Add(new int[2] {mergedLow, mergedHigh});
                    // write rest
                    for (int j = i; j < intervals.Length; j++)
                    {
                        answer.Add(intervals[j]);
                    }
                    return answer.ToArray();
                }
                else if (intervals[i][1] < mergedLow)
                {
                    answer.Add(intervals[i]);
                }
                else // has overlap
                {
                    mergedLow = Math.Min(mergedLow, intervals[i][0]);
                    mergedHigh = Math.Max(mergedHigh, intervals[i][1]);
                }
            }
            // merged has not been written yet;
            answer.Add(new int[2] { mergedLow, mergedHigh });
            return answer.ToArray();
        }

        [Fact]
        public void Q057_InsertInterval()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(Insert(input[0].ToIntArrayArray(), input[1].ToIntArray())));
        }
    }
}
