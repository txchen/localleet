using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
//
// Solve it without division and in O(n).
//
// For example, given [1,2,3,4], return [24,12,8,6].
//
// Follow up:
// Could you solve it with constant space complexity? (Note: The output array does not count as extra space for the purpose of space complexity analysis.)

// https://leetcode.com/problems/product-of-array-except-self/
namespace LocalLeet
{
    public class Q238
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            // [a, b, c, d]
            // pass 1, make [1, a, ab, abc]
            int[] answer = new int[nums.Length];
            int left = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = left;
                left = left * nums[i];
            }
            // pass 2, right to left, [bcd, acd, abd, abc]
            int right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                answer[i] *= right;
                right = right * nums[i];
            }
            return answer;
        }

        [Fact]
        public void Q238_ProductOfArrayExceptSelf()
        {
            TestHelper.Run(input => TestHelper.Serialize(ProductExceptSelf(input.EntireInput.ToIntArray())));
        }
    }
}
