using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given an integer n, return the number of trailing zeroes in n!.
//
// Note: Your solution should be in logarithmic time complexity.

// https://leetcode.com/problems/factorial-trailing-zeroes/
namespace LocalLeet
{
    public class Q172
    {
        public int TrailingZeroes(int n)
        {
            int answer = 0;
            int fives = n / 5 ;
            while (fives > 0)
            {
                answer += fives;
                fives /= 5;
            }
            return answer;
        }

        [Fact]
        public void Q172_FactorialTrailingZeroes()
        {
            TestHelper.Run(input => TrailingZeroes(input.EntireInput.ToInt()).ToString());
        }
    }
}
