using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s. If there isn't one, return 0 instead.
//
// For example, given the array [2,3,1,2,4,3] and s = 7,
// the subarray [4,3] has the minimal length under the problem constraint.
//
// If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n).

// https://leetcode.com/problems/minimum-size-subarray-sum/
namespace LocalLeet
{
    public class Q209
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            int left = -1;
            int right = 0;
            int sum = 0;
            int answer = nums.Length + 1;
            while (right < nums.Length)
            {
                sum += nums[right];
                if (sum >= s)
                {
                    while (left < right)
                    {
                        if ((sum - nums[left+1]) >= s)
                        {
                            sum -= nums[left+1];
                            left++;
                        } else
                        {
                            break;
                        }
                    }
                    answer = Math.Min(answer, right - left);
                }
                right++;
            }
            return answer > nums.Length ? 0 : answer;
        }

        [Fact]
        public void Q209_MinimumSizeSubarraySum()
        {
            TestHelper.Run(input => MinSubArrayLen(input[0].ToInt(), input[1].ToIntArray()).ToString());
        }
    }
}
