using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Divide two integers without using multiplication, division and mod operator.

namespace LocalLeet
{

    public class Q029_DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            bool neg = false;
            neg = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);
            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);
            int shift = 0;
            while (b << shift <= a)
            {
                shift++;
            }
            shift = shift - 1; // now b << shift <= a
            // try to minus b << shift , and shrink shift until zero
            long answer = 0;
            while (shift >= 0)
            {
                if (b << shift <= a)
                {
                    a -= b << shift;
                    answer += 1 << shift; // key point !
                }
                shift--;
            }
            return (int)(neg ? 0 - answer : answer);
        }

        public string SolveQuestion(string input)
        {
            return Divide(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()).ToString();
        }

        [TestMethod]
        public void Q029_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q029_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
