using System;
using System.Collections.Generic;
using System.Linq;

// Reverse digits of an integer.

// Example1: x = 123, return 321
// Example2: x = -123, return -321

namespace LocalLeet
{
    public class Q007_ReverseInteger
    {
        public int ReverseInterger(int x)
        {
            bool isNeg = x < 0;
            x = isNeg ? 0 - x : x;
            int res = 0;
            while (x > 0)
            {
                int lowest = x % 10;
                res = res * 10 + lowest;
                x = x / 10;
            }
            return isNeg ? 0 - res : res;
        }

        public string SolveQuestion(string input)
        {
            return ReverseInterger(input.ToInt()).ToString();
        }

        [Fact]
        public void Q007_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q007_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
