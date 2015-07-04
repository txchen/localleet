using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a roman numeral, convert it to an integer.

// Input is guaranteed to be within the range from 1 to 3999.

// https://leetcode.com/problems/roman-to-integer/
namespace LocalLeet
{
    public class Q013
    {
        static Dictionary<string, int> dict = null;
        Q012 itr = new Q012();
        int RomanToInt(string s)
        {
            if (dict == null)
            {
                dict = new Dictionary<string, int>();
                for (int i = 1; i < 4000; i++)
                {
                    dict.Add(itr.IntToRoman(i), i);
                }
            }
            return dict[s];
        }

        [Fact]
        public void Q013_RomantoInteger()
        {
            TestHelper.Run(input => RomanToInt(input.EntireInput.Deserialize()).ToString());
        }
    }
}
