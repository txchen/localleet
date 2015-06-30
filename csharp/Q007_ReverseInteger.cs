using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Reverse digits of an integer.

// Example1: x = 123, return 321
// Example2: x = -123, return -321

// https://leetcode.com/problems/reverse-integer/
namespace LocalLeet
{
    public class Q007
    {
        public int ReverseInterger(int x)
        {
            bool isNeg = x < 0;
            x = isNeg ? 0 - x : x;
            int res = 0;
            while (x > 0)
            {
                int lowest = x % 10;
                res = res * 10 + lowest;
                x = x / 10;
            }
            return isNeg ? 0 - res : res;
        }

        [Fact]
        public void Q007_ReverseInteger()
        {
            TestHelper.Run(input => ReverseInterger(input[0].ToInt()).ToString());
        }
    }
}
