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
    public class Q202
    {
        public bool IsHappy(int n)
        {
            HashSet<int> h = new HashSet<int>();
            while (n != 1)
            {
                int next = 0;
                while (n > 0)
                {
                    next += (n % 10 ) * (n % 10);
                    n /= 10;
                }
                if (!h.Add(next))
                {
                    return false;
                }
                n = next;
            }
            return true;
        }

        [Fact]
        public void Q202_HappyNumber()
        {
            TestHelper.Run(input => IsHappy(input.EntireInput.ToInt()).ToString().ToLower());
        }
    }
}
