using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

// https://leetcode.com/problems/valid-parentheses/
namespace LocalLeet
{
    public class Q020
    {
        public bool IsValid(string s)
        {
            Stack<char> stk = new Stack<char>();
            stk.Push('M'); // for cleaner code
            foreach (var c in s)
            {
                if (c == ')')
                {
                    var previous = stk.Pop();
                    if (previous != '(')
                    {
                        return false;
                    }
                }
                else if (c == ']')
                {
                    var previous = stk.Pop();
                    if (previous != '[')
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    var previous = stk.Pop();
                    if (previous != '{')
                    {
                        return false;
                    }
                }
                else
                {
                    stk.Push(c);
                }
            }
            return stk.Count == 1;
        }

        [Fact]
        public void Q020_ValidParentheses()
        {
            TestHelper.Run(input => IsValid(input[0].Deserialize()).ToString().ToLower());
        }
    }
}
