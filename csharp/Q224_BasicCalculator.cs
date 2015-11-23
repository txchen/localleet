using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Implement a basic calculator to evaluate a simple expression string.
//
// The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
//
// You may assume that the given expression is always valid.
//
// Some examples:
// "1 + 1" = 2
// " 2-1 + 2 " = 3
// "(1+(4+5+2)-3)+(6+8)" = 23
// Note: Do not use the eval built-in library function.

// https://leetcode.com/problems/basic-calculator/
namespace LocalLeet
{
    public class Q224
    {
        public int Calculate(string s)
        {
            Stack<char> operStk = new Stack<char>();
            Stack<int> numStk = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    long currentNumber = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        currentNumber = currentNumber * 10 + int.Parse(s[i].ToString());
                        i++;
                    }
                    numStk.Push((int)currentNumber);
                    i--;
                }
                else if (c == '+' || c == '-')
                {
                    while (operStk.Count > 0 && operStk.Peek() != '(')
                    {
                        ProcessOper(numStk, operStk.Pop());
                    }
                    operStk.Push(c);
                }
                else if (c == '(')
                {
                    operStk.Push(c);
                }
                else if (c == ')')
                {
                    while (true)
                    {
                        var op = operStk.Pop();
                        if (op == '(')
                        {
                            break;
                        }
                        ProcessOper(numStk, op);
                    }
                }
            }
            while (operStk.Count > 0)
            {
                ProcessOper(numStk, operStk.Pop());
            }
            return numStk.Pop();
        }

        private void ProcessOper(Stack<int> numStk, char oper)
        {
            int num2 = numStk.Pop();
            int num1 = numStk.Pop();
            switch (oper)
            {
                case '+':
                    numStk.Push(num1 + num2);
                    break;
                case '-':
                default:
                    numStk.Push(num1 - num2);
                    break;
            }
        }

        [Fact]
        public void Q224_BasicCalculator()
        {
            TestHelper.Run(input => Calculate(input.EntireInput.Deserialize()).ToString());
        }
    }
}
