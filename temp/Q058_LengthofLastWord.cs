using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

// If the last word does not exist, return 0.

// Note: A word is defined as a character sequence consists of non-space characters only.

// For example,
// Given s = "Hello World",
// return 5.

namespace LocalLeet
{
    public class Q058_LengthofLastWord
    {
        public int LengthOfLastWord(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }
            int right = input.Length - 1;
            while (right >= 0 && input[right] == ' ')
            {
                right--;
            }
            for (int i = right; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    return right - i;
                }
            }
            return right + 1;
        }

        public string SolveQuestion(string input)
        {
            return LengthOfLastWord(input[0].Deserialize()).ToString();
        }

        [Fact]
        public void Q058_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
