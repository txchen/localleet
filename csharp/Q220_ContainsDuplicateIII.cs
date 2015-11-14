using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an array of integers, find out whether there are two distinct indices i and j in the array such that the difference between nums[i] and nums[j] is at most t and the difference between i and j is at most k.

// https://leetcode.com/problems/contains-duplicate-iii/
namespace LocalLeet
{
    public class Q220
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k < 1 || t < 0)
            {
                return false;
            }
            int bucketSize = t + 1;
            Dictionary<long, long> dic = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++)
            {
                long bucketIndex = nums[i] / bucketSize;
                if (nums[i] < 0)
                {
                    bucketIndex -= 1; // Notice: -4 / 5 = 0, so for negative, need to adjust
                }
                if (dic.ContainsKey(bucketIndex) ||
                    (dic.ContainsKey(bucketIndex - 1) && Math.Abs(dic[bucketIndex - 1] - nums[i]) <= t) ||
                    (dic.ContainsKey(bucketIndex + 1) && Math.Abs(dic[bucketIndex + 1] - nums[i]) <= t))
                {
                    return true;
                }
                dic[bucketIndex] = nums[i];
                if (dic.Count > k)
                {
                    dic.Remove(nums[i - k] / bucketSize);
                }
            }
            return false;
        }

        [Fact]
        public void Q220_ContainsDuplicateIII()
        {
            TestHelper.Run(input => ContainsNearbyAlmostDuplicate(input[0].ToIntArray(),
                input[1].ToInt(),
                input[2].ToInt()).ToString().ToLower());
        }
    }
}
