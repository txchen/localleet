using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
//
// Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

// https://leetcode.com/problems/house-robber/
namespace LocalLeet
{
    public class Q198
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
            nums[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i-2] + nums[i], nums[i-1]); // rob current or not
            }
            return nums[nums.Length - 1];
        }

        [Fact]
        public void Q198_HouseRobber()
        {
            TestHelper.Run(input => Rob(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
