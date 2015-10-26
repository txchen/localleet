using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Note: This is an extension of House Robber.
//
// After robbing those houses on that street, the thief has found himself a new place for his thievery so that he will not get too much attention. This time, all houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, the security system for these houses remain the same as for those in the previous street.
//
// Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

// https://leetcode.com/problems/house-robber-ii/
namespace LocalLeet
{
    public class Q213
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length <= 1)
            {
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            // similar to house-robber-i, just the max of (rob(nums[0, -2]), rob(nums[1, -1]))
            int[] shrinkedNums = new int[nums.Length - 1];
            Array.Copy(nums, 0, shrinkedNums, 0, shrinkedNums.Length);
            int answer1 = RobInternal(shrinkedNums);
            Array.Copy(nums, 1, shrinkedNums, 0, shrinkedNums.Length);
            int answer2 = RobInternal(shrinkedNums);
            return Math.Max(answer1, answer2);
        }

        private int RobInternal(int[] nums)
        {
            nums[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i-2] + nums[i], nums[i-1]); // rob current or not
            }
            return nums[nums.Length - 1];
        }

        [Fact]
        public void Q213_HouseRobberII()
        {
            TestHelper.Run(input => Rob(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
