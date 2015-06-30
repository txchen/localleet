using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Divide two integers without using multiplication, division and mod operator.

// https://leetcode.com/problems/divide-two-integers/
namespace LocalLeet
{
    public class Q029
    {
        public int Divide(int dividend, int divisor)
        {
            bool neg = false;
            neg = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);
            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);
            int shift = 0;
            while (b << shift <= a)
            {
                shift++;
            }
            shift = shift - 1; // now b << shift <= a
            // try to minus b << shift , and shrink shift until zero
            long answer = 0;
            while (shift >= 0)
            {
                if (b << shift <= a)
                {
                    a -= b << shift;
                    answer += 1 << shift; // key point !
                }
                shift--;
            }
            return (int)(neg ? 0 - answer : answer);
        }

        [Fact]
        public void Q029_DivideTwoIntegers()
        {
            TestHelper.Run(input => Divide(input[0].ToInt(), input[1].ToInt()).ToString());
        }
    }
}
