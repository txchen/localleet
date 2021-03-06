using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an integer, convert it to a roman numeral.

// Input is guaranteed to be within the range from 1 to 3999.

// https://leetcode.com/problems/integer-to-roman/
namespace LocalLeet
{
    public class Q012
    {
        string[] ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        string[] tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] thousands = new string[] { "", "M", "MM", "MMM" };

        public string IntToRoman(int num)
        {
            string result = "";
            int thousand = num / 1000;
            result += thousands[thousand];
            int hundred = (num / 100) % 10;
            result += hundreds[hundred];
            int ten = (num / 10) % 10;
            result += tens[ten];
            int one = num % 10;
            result += ones[one];
            return result;
        }

        [Fact]
        public void Q012_IntegertoRoman()
        {
            TestHelper.Run(input =>
                "\"" + IntToRoman(input[0].ToInt()) + "\"");
        }
    }
}
