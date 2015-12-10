using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a sorted integer array without duplicates, return the summary of its ranges.
//
// For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"].

// https://leetcode.com/problems/summary-ranges/
namespace LocalLeet
{
    public class Q228
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new List<string>();
            }
            List<string> result = new List<string>();
            int currentStart = nums[0];
            int currentEnd = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == currentEnd + 1)
                {
                    currentEnd = nums[i];
                }
                else
                {
                    result.Add(GenSeg(currentStart, currentEnd));
                    currentStart = currentEnd = nums[i];
                }
            }
            result.Add(GenSeg(currentStart, currentEnd));
            return result;
        }

        private string GenSeg(int start, int end)
        {
            if (start == end)
            {
                return start.ToString();
            }
            else
            {
                return start.ToString() + "->" + end.ToString();
            }
        }

        [Fact]
        public void Q228_SummaryRanges()
        {
            TestHelper.Run(input => TestHelper.Serialize(SummaryRanges(input.EntireInput.ToIntArray())));
        }
    }
}
