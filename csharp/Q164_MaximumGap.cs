using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an unsorted array, find the maximum difference between the successive elements in its sorted form.
//
// Try to solve it in linear time/space.
//
// Return 0 if the array contains less than 2 elements.
//
// You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.

// https://leetcode.com/problems/maximum-gap/
namespace LocalLeet
{
    public class Q164
    {
        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            int min = nums[0];
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }
            int bucketSize = Math.Max(1, (max - min) / (nums.Length - 1));
            int bucketNum  = (max - min) / bucketSize + 1;
            int[] bucketMin = new int[bucketNum];
            int[] bucketMax = new int[bucketNum];
            bool[] bucketHasEle = new bool[bucketNum];
            for (int i = 0; i < nums.Length; i++)
            {
                int bucketIndex = (nums[i] - min) / bucketSize;
                if (bucketHasEle[bucketIndex])
                {
                    bucketMin[bucketIndex] = Math.Min(bucketMin[bucketIndex], nums[i]);
                    bucketMax[bucketIndex] = Math.Max(bucketMax[bucketIndex], nums[i]);
                }
                else
                {
                    bucketHasEle[bucketIndex] = true;
                    bucketMin[bucketIndex] = bucketMax[bucketIndex] = nums[i];
                }
            }
            int preMax = min;
            int answer = 0;
            for (int i = 0; i < bucketNum; i++)
            {
                if (bucketHasEle[i])
                {
                    answer = Math.Max(answer, bucketMin[i] - preMax);
                    preMax = bucketMax[i];
                }
            }
            return answer;
        }

        [Fact]
        public void Q164_MaximumGap()
        {
            TestHelper.Run(input => MaximumGap(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
