using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a number represented as an array of digits, plus one to the number.

namespace LocalLeet
{
    public class Q066_PlusOne
    {
        public int[] PlusOne(int[] digits)
        {
            int[] result = new int[digits.Length];
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int tmp = carry + digits[i];
                carry = tmp / 10;
                result[i] = tmp % 10;
            }
            if (carry == 0)
            {
                return result;
            }
            return (new int[1] { 1 }).Concat(result).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(PlusOne(input.ToIntArray()));
        }

        [Fact]
        public void Q066_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q066_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
