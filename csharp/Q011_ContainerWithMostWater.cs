using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n non-negative integers a1, a2, ..., an,
// where each represents a point at coordinate (i, ai). n vertical lines are drawn
// such that the two endpoints of line i is at (i, ai) and (i, 0).
// Find two lines, which together with x-axis forms a container, such that the container contains the most water.

// Note: You may not slant the container.

// https://leetcode.com/problems/container-with-most-water/
namespace LocalLeet
{
    public class Q011
    {
        public int MaxArea(int[] height)
        {
            // l = 0, r = rightmost
            // if h[l] < h[r], then x(l, r) > x(l+1, r), we dont need to check l+1, r
            int left = 0, right = height.Length - 1;
            int answer = 0;
            while (left < right)
            {
                answer = Math.Max(answer, (Math.Min(height[left], height[right]) * (right - left)));
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return answer;
        }

        [Fact]
        public void Q011_ContainerWithMostWater()
        {
            TestHelper.Run(input => MaxArea(input[0].ToIntArray()).ToString());
        }
    }
}
