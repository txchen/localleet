using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).
//
// For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.

// https://leetcode.com/problems/number-of-1-bits/
namespace LocalLeet
{
    public class Q191
    {
        public int HammingWeight(uint n)
        {
            int answer = 0;
            while (n > 0)
            {
                answer += (int)(n & 1);
                n = n >> 1;
            }
            return answer;
        }

        [Fact]
        public void Q191_NumberOf1Bits()
        {
            TestHelper.Run(input => {
                int idx = input.EntireInput.IndexOf('(');
                uint inputUInt = uint.Parse(input.EntireInput.Substring(0, idx).Trim());
                return HammingWeight(inputUInt).ToString();
            });
        }
    }
}
