using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
//
// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
//
// Some examples:
//   ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
//   ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6

// https://leetcode.com/problems/evaluate-reverse-polish-notation/
namespace LocalLeet
{
    public class Q150
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stk = new Stack<int>();
            int p1, p2;
            foreach (string t in tokens)
            {
                switch (t)
                {
                    case "+":
                        p2 = stk.Pop();
                        p1 = stk.Pop();
                        stk.Push(p1 + p2);
                        break;
                    case "-":
                        p2 = stk.Pop();
                        p1 = stk.Pop();
                        stk.Push(p1 - p2);
                        break;
                    case "*":
                        p2 = stk.Pop();
                        p1 = stk.Pop();
                        stk.Push(p1 * p2);
                        break;
                    case "/":
                        p2 = stk.Pop();
                        p1 = stk.Pop();
                        stk.Push(p1 / p2);
                        break;
                    default:
                        stk.Push(int.Parse(t));
                        break;
                }
            }
            return stk.Peek();
        }

        [Fact]
        public void Q150_EvaluateReversePolishNotation()
        {
            TestHelper.Run(input => EvalRPN(input.EntireInput.ToStringArray()).ToString());
        }
    }
}
