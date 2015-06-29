using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) 
// parentheses substring.

// For "(()", the longest valid parentheses substring is "()", which has length = 2.

// Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

namespace LocalLeet
{
    
    public class Q032_LongestValidParentheses
    {
        public int LongestValidParentheses(string s)
        {
            int answer = 0;
            Stack<Tuple<char, int>> stk = new Stack<Tuple<char, int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stk.Push(Tuple.Create('(', i));
                }
                else // ')'
                {
                    if (stk.Count() > 0 && stk.Peek().Item1 == '(')
                    {
                        stk.Pop();
                        int answerStart = stk.Count() > 0 ? stk.Peek().Item2 : -1;
                        answer = Math.Max(answer, i - answerStart);
                    }
                    else
                    {
                        stk.Push(Tuple.Create(')', i));
                    }
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return LongestValidParentheses(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q032_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q032_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
