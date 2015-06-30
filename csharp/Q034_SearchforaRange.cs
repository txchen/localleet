using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted array of integers, find the starting and ending position of a given target value.

// Your algorithm's runtime complexity must be in the order of O(log n).

// If the target is not found in the array, return [-1, -1].

// For example,
// Given [5, 7, 7, 8, 8, 10] and target value 8,
// return [3, 4].

// https://leetcode.com/problems/search-for-a-range/
namespace LocalLeet
{
    public class Q034
    {
        public int[] SearchRange(int[] A, int target)
        {
            int left = SearchRange(A, target, true);
            if (left == -1)
            {
                return new int[] { -1, -1 };
            }
            return new int[] { left, SearchRange(A, target, false) };
        }

        private int SearchRange(int[] A, int target, bool leftMost)
        {
            int start = 0, end = A.Length - 1;
            while (start <= end)
            {
                int attemptIndex = (start + end) / 2;
                int attempt = A[(start + end) / 2];
                if (attempt == target)
                {
                    if (leftMost)
                    {
                        if (attemptIndex == start || A[attemptIndex - 1] < attempt)
                        {
                            return attemptIndex;
                        }
                        else
                        {
                            end = attemptIndex - 1;
                        }
                    }
                    if (!leftMost)
                    {
                        if (attemptIndex == end || A[attemptIndex + 1] > attempt)
                        {
                            return attemptIndex;
                        }
                        else
                        {
                            start = attemptIndex + 1;
                        }
                    }
                }
                else if (attempt > target)
                {
                    end = attemptIndex - 1;
                }
                else
                {
                    start = attemptIndex + 1;
                }
            }
            return -1;
        }

        [Fact]
        public void Q034_SearchforaRange()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(SearchRange(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
