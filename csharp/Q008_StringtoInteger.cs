using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement atoi to convert a string to an integer.

// https://leetcode.com/problems/string-to-integer-atoi/
namespace LocalLeet
{
    public class Q008
    {
        public int Atoi(string str)
        {
            // This one is not interesting
            bool neg = false;
            str = str.Trim();
            int i = 0;
            if (str.StartsWith("-")) {
                neg = true;
                i = 1;
            }
            else if (str.StartsWith("+"))
            {
                i = 1;
            }
            long answer = 0;
            for (; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    answer = answer * 10 + long.Parse(str[i].ToString());
                    if (answer > int.MaxValue)
                    {
                        return neg ? int.MinValue : int.MaxValue;
                    }
                }
                else
                {
                    break;
                }
            }
            return (int)(neg ? 0 - answer: answer);
        }

        [Fact]
        public void Q008_StringtoInteger()
        {
            TestHelper.Run(input => Atoi(input.EntireInput.Deserialize()).ToString());
        }
    }
}
