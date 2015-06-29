using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

namespace LocalLeet
{

    public class Q020_ValidParentheses
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

        public string SolveQuestion(string input)
        {
            return IsValid(input.Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q020_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q020_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
