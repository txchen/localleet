using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Reverse bits of a given 32 bits unsigned integer.
//
// For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), return 964176192 (represented in binary as 00111001011110000010100101000000).

// https://leetcode.com/problems/reverse-bits/
namespace LocalLeet
{
    public class Q190
    {
        public uint ReverseBits(uint n)
        {
            uint high = (uint)1 << 31;
            uint low = 1;
            while (high > low)
            {
                bool highHasOne = (n & high) > 0;
                bool lowHasOne = (n & low) > 0;
                if (highHasOne && !lowHasOne)
                {
                    n &= ~high;
                    n |= low;
                }
                if (lowHasOne && !highHasOne)
                {
                    n &= ~low;
                    n |= high;
                }
                high = high >> 1;
                low = low << 1;
            }
            return n;
        }

        [Fact]
        public void Q190_ReverseBits()
        {
            TestHelper.Run(input => {
                int idx = input.EntireInput.IndexOf('(');
                uint inputUInt = uint.Parse(input.EntireInput.Substring(0, idx).Trim());
                uint result = ReverseBits(inputUInt);
                return String.Format(" {0, 11} ({1})", result, Convert.ToString(result, 2).PadLeft(32, '0'));
            });
        }
    }
}
