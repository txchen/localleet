using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times. The algorithm should run in linear time and in O(1) space.

// https://leetcode.com/problems/majority-element-ii/
namespace LocalLeet
{
    public class Q229
    {
        public IList<int> MajorityElement(int[] nums)
        {
            // at most, there are 2 nums in result
            int candidate1 = 0, candidate2 = 0, count1 = 0, count2 = 0;
            foreach (int n in nums)
            {
                if (count1 == 0 || n == candidate1)
                {
                    count1++;
                    candidate1 = n;
                }
                else if (count2 == 0 || n == candidate2)
                {
                    count2++;
                    candidate2 = n;
                }
                else {
                    count1--;
                    count2--;
                }
            }
            count1 = count2 = 0;
            foreach (int n in nums)
            {
                if (n == candidate1)
                {
                    count1++;
                }
                else if (n == candidate2)
                {
                    count2++;
                }
            }
            var result = new List<int>();
            if (count1 > nums.Length / 3)
            {
                result.Add(candidate1);
            }
            if (count2 > nums.Length / 3)
            {
                result.Add(candidate2);
            }
            return result;
        }

        [Fact]
        public void Q229_MajorityElementII()
        {
            TestHelper.Run(input => TestHelper.Serialize(MajorityElement(input.EntireInput.ToIntArray())));
        }
    }
}
