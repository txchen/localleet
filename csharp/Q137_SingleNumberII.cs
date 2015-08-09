using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array of integers, every element appears three times except for one. Find that single one.
//
// Note:
// Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

// https://leetcode.com/problems/single-number-ii/
namespace LocalLeet
{
    public class Q137
    {
        public int SingleNumberII(int[] A)
        {
            int ones = 0;
            int twos = 0;
            int threes = 0;
            A.ToList().ForEach(a => {
                twos |= ones & a;
                ones = ones ^ a;
                threes = twos & ones;
                ones = ones & ~threes;
                twos = twos & ~threes;
            });
            return ones;
        }

        [Fact]
        public void Q137_SingleNumberII()
        {
            TestHelper.Run(input => SingleNumberII(input.EntireInput.ToIntArray()).ToString());
        }
    }
}
