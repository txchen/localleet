using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//
// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
//
// Find the minimum element.
//
// You may assume no duplicate exists in the array.

// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
namespace LocalLeet
{
    public class Q153
    {
        public int FindMin(int[] num)
        {
            int left = 0;
            int right = num.Length - 1;
            while (left < right)
            {
                if (num[left] < num[right])
                {
                    return num[left];
                }
                int mid = (left + right) /2;
                if (num[left] <= num[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return num[left];
        }

        [Fact]
        public void Q153_FindMinimiumInRotatedSortedArray()
        {
            TestHelper.Run(input => FindMin(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
