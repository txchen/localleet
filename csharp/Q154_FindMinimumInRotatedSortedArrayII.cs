using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
//
// Follow up for "Find Minimum in Rotated Sorted Array":
// What if duplicates are allowed?
//
// Would this affect the run-time complexity? How and why?
// Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//
// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
//
// Find the minimum element.
//
// The array may contain duplicates.

// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
namespace LocalLeet
{
    public class Q154
    {
        public int FindMin(int[] num)
        {
            int l = 0;
            int r = num.Length - 1;
            int answer = num[(l+r) /2];
            while (l <= r)
            {
                if (num[l] < num[r])
                {
                    return num[l];
                }
                int mid = (l + r) / 2;
                int midV = num[mid];
                answer = Math.Min(answer, midV);
                if (midV > num[l])
                {
                    l = mid + 1;
                }
                else if (midV < num[l])
                {
                    r = mid;
                }
                else
                {
                    l++;
                }
            }
            return answer;
        }

        [Fact]
        public void Q154_FindMinimiumInRotatedSortedArrayII()
        {
            TestHelper.Run(input => FindMin(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
