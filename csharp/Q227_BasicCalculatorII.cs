using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Implement a basic calculator to evaluate a simple expression string.
//
// The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.
//
// You may assume that the given expression is always valid.
//
// Some examples:
// "3+2*2" = 7
// " 3/2 " = 1
// " 3+5 / 2 " = 5

// https://leetcode.com/problems/basic-calculator-ii/
namespace LocalLeet
{
    public class Q227
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
                    while (operStk.Count > 0)
                    {
                        ProcessOper(numStk, operStk.Pop());
                    }
                    operStk.Push(c);
                }
                else if (c == '*' || c == '/')
                {
                    while (operStk.Count > 0 && (operStk.Peek() == '*' || operStk.Peek() == '/'))
                    {
                        ProcessOper(numStk, operStk.Pop());
                    }
                    operStk.Push(c);
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
                case '*':
                    numStk.Push(num1 * num2);
                    break;
                case '/':
                    numStk.Push(num1 / num2);
                    break;
                case '-':
                default:
                    numStk.Push(num1 - num2);
                    break;
            }
        }

        [Fact]
        public void Q227_BasicCalculatorII()
        {
            TestHelper.Run(input => Calculate(input.EntireInput.Deserialize()).ToString());
        }
    }
}
