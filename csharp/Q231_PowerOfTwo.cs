using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an integer, write a function to determine if it is a power of two.

// https://leetcode.com/problems/power-of-two/
namespace LocalLeet
{
    public class Q231
    {
        public bool IsPowerOfTwo(int n)
        {
            int numOfOne = 0;
            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    numOfOne++;
                }
                n = n >> 1;
            }
            return numOfOne == 1;
        }

        [Fact]
        public void Q231_PowerOfTwo()
        {
            TestHelper.Run(input => IsPowerOfTwo(input.EntireInput.ToInt()).ToString().ToLower());
        }
    }
}
