using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Rotate an array of n elements to the right by k steps.
//
// For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].
//
// Note:
// Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.

// https://leetcode.com/problems/rotate-array/
namespace LocalLeet
{
    public class Q189
    {
        public int[] Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            if (k == 0 || nums.Length < 2)
            {
                return nums;
            }
            // rotate 0..n-k-1
            int left = 0;
            int right = n - k - 1;
            do
            {
                int t = nums[left];
                nums[left] = nums[right];
                nums[right] = t;
            }
            while (++left < --right);
            // rotate n-k..n-1
            left = n-k;
            right = n-1;
            do
            {
                int t = nums[left];
                nums[left] = nums[right];
                nums[right] = t;
            }
            while (++left < --right);
            // rotate all
            left = 0;
            right = n-1;
            do
            {
                int t = nums[left];
                nums[left] = nums[right];
                nums[right] = t;
            }
            while (++left < --right);
            return nums;
        }

        [Fact]
        public void Q189_BestTimeToBuyAndSellStockIV()
        {
            TestHelper.Run(input => TestHelper.Serialize(Rotate(input[0].ToIntArray(), input[1].ToInt())));
        }
    }
}
