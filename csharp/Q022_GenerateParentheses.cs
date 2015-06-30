using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// For example, given n = 3, a solution set is:

// "((()))", "(()())", "(())()", "()(())", "()()()"

namespace LocalLeet
{
    public class Q022
    {
        public string[] GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            char[] charArr = new char[2 * n];
            InternalGenerate(2 * n, charArr, 0, 0, result);
            return result.ToArray();
        }

        private void InternalGenerate(int totalLength, char[] charArr, int index, int leftCount, List<string> result)
        {
            if (index >= totalLength)
            {
                if (leftCount == 0)
                {
                    result.Add(new string(charArr));
                }
            }
            else
            {
                if (leftCount < totalLength / 2)
                {
                    charArr[index] = '(';
                    InternalGenerate(totalLength, charArr, index + 1, leftCount + 1, result);
                }
                if (leftCount > 0)
                {
                    charArr[index] = ')';
                    InternalGenerate(totalLength, charArr, index + 1, leftCount - 1, result);
                }
            }
        }

        [Fact]
        public void Q022_GenerateParentheses()
        {
            TestHelper.Run(input =>
                TestHelper.Serialize(GenerateParenthesis(input[0].ToInt())));
        }
    }
}
