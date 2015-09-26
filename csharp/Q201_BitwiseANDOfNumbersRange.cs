using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.
//
// For example, given the range [5, 7], you should return 4.

// https://leetcode.com/problems/bitwise-and-of-numbers-range/
namespace LocalLeet
{
    public class Q201
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            int shift = 0;
            while (m != n)
            {
                m = m >> 1;
                n = n >> 1;
                shift++;
            }
            return n << shift;
        }

        [Fact]
        public void Q201_BitwiseANDOfNumbersRange()
        {
            TestHelper.Run(input => RangeBitwiseAnd(input[0].ToInt(), input[1].ToInt()).ToString());
        }
    }
}
