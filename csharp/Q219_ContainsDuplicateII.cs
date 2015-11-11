using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k.

// https://leetcode.com/problems/contains-duplicate-ii/
namespace LocalLeet
{
    public class Q219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hs.Add(nums[i]))
                {
                    return true;
                }
                if (i >= k)
                {
                    hs.Remove(nums[i - k]);
                }
            }
            return false;
        }

        [Fact]
        public void Q219_ContainsDuplicateII()
        {
            TestHelper.Run(input => ContainsNearbyDuplicate(input[0].ToIntArray(), input[1].ToInt()).ToString().ToLower());
        }
    }
}
