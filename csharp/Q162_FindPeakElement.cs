using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// A peak element is an element that is greater than its neighbors.
//
// Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.
//
// The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
//
// You may imagine that num[-1] = num[n] = -∞.
//
// For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.
//
// Note:
// Your solution should be in logarithmic complexity.

// https://leetcode.com/problems/find-peak-element/
namespace LocalLeet
{
    public class Q162
    {
        public int FindPeakElement(int[] num)
        {
            if (num.Length == 1)
            {
                return 0;
            }
            int len = num.Length;
            if (num[0] > num[1])
            {
                return 0;
            }
            if (num[len -1] > num[len -2])
            {
                return len -1;
            }
            int low = 1;
            int high = len -2;
            while (low < high)
            {
                int mid = (low + high) / 2;
                if (num[mid] > num[mid-1] && num[mid] > num[mid+1])
                {
                    return mid;
                }
                if (num[mid] < num[mid + 1])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        [Fact]
        public void Q162_FindPeakElement()
        {
            TestHelper.Run(input => FindPeakElement(input.EntireInput.ToIntArray()).ToString(),
                specialAssertAction: (result, expected) =>
                {
                    if (expected == "Special judge: No expected output available.")
                    {
                        return true;
                    }
                    return result == expected;
                }
            );
        }
    }
}
