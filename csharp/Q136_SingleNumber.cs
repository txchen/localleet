using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of integers, every element appears twice except for one. Find that single one.
//
// Note:
// Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

// https://leetcode.com/problems/single-number/
namespace LocalLeet
{
    public class Q136
    {
        public int SingleNumber(int[] A)
        {
            int answer = 0;
            A.ToList().ForEach(a => answer = answer ^ a);
            return answer;
        }

        [Fact]
        public void Q136_SingleNumber()
        {
            TestHelper.Run(input => SingleNumber(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
