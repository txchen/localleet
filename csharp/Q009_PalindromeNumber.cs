using System;
using System.Collections.Generic;
using System.Linq;

// Determine whether an integer is a palindrome. Do this without extra space.

namespace LocalLeet
{
    public class Q009_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            int length = 1;
            while (x / (int)Math.Pow(10, length) > 0)
            {
                length++;
            }
            while (x > 0)
            {
                int lowest = x % 10;
                int highest = x / (int)Math.Pow(10, length - 1);
                if (lowest != highest)
                {
                    return false;
                }
                x = x - (int)Math.Pow(10, length - 1) * highest;
                x /= 10;
                length -= 2;
            }
            return true;
        }

        public string SolveQuestion(string input)
        {
            return IsPalindrome(input.ToInt()).ToString().ToLower();
        }

        [Fact]
        public void Q009_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q009_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
