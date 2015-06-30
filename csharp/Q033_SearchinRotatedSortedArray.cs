using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Suppose a sorted array is rotated at some pivot unknown to you beforehand.

// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

// You are given a target value to search. If found in the array return its index, otherwise return -1.

// You may assume no duplicate exists in the array.

// https://leetcode.com/problems/search-in-rotated-sorted-array/
namespace LocalLeet
{
    public class Q033
    {
        public int Search(int[] a, int target)
        {
            return Search(a, target, 0, a.Length - 1);
        }

        private int Search(int[] a, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            bool shifted = a[start] > a[end];
            int attempt = a[(start + end) / 2];
            if (target == attempt)
            {
                return (start + end) / 2;
            }
            else if (target > attempt)
            {
                if (!shifted)
                {
                    return Search(a, target, (start + end) / 2 + 1, end);
                }
            }
            else // target < attempt
            {
                if (!shifted)
                {
                    return Search(a, target, start, (start + end) / 2 - 1);
                }
            }
            int leftAnswer = Search(a, target, start, (start + end) / 2 - 1);
            if (leftAnswer >= 0)
            {
                return leftAnswer;
            }
            int rightAnswer = Search(a, target, (start + end) / 2 + 1, end);
            if (rightAnswer >= 0)
            {
                return rightAnswer;
            }
            return -1;
        }

        [Fact]
        public void Q033_SearchinRotatedSortedArray()
        {
            TestHelper.Run(input =>
                Search(input[0].ToIntArray(), input[1].ToInt()).ToString());
        }
    }
}
