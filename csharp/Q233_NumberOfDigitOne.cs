using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.
//
// For example:
// Given n = 13,
// Return 6, because digit 1 occurred in the following numbers: 1, 10, 11, 12, 13.

// https://leetcode.com/problems/number-of-digit-one/
namespace LocalLeet
{
    public class Q233
    {
        public int CountDigitOne(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n < 10)
            {
                return 1;
            }
            int length = n.ToString().Length;
            int highestBase = (int)Math.Pow(10, length - 1);
            int highest = n / highestBase;
            int remaining = n % highestBase;
            int onesInHighest = 0;
            if (highest == 1)
            {
                onesInHighest = remaining + 1;
            }
            else
            {
                onesInHighest = highestBase;
            }
            return onesInHighest + CountDigitOne(remaining) + CountDigitOne(highestBase - 1) * highest;
        }

        [Fact]
        public void Q233_NumberOfDigitOne()
        {
            TestHelper.Run(input => CountDigitOne(input.EntireInput.ToInt()).ToString());
        }
    }
}
