using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement pow(x, n).

namespace LocalLeet
{
    public class Q050
    {
        public double Pow(double x, int n)
        {
            // key point: Pow(x, n) = Pow(x, n/2) * Pow(x, n/2) * Pow(x, n%2)
            if (n == 0)
            {
                return 1;
            }
            if (x == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return x;
            }
            bool neg = n < 0;
            long ln = n;
            ln = Math.Abs(ln);
            long current = 1;
            double answer = x;
            while (current * 2 <= ln)
            {
                answer *= answer;
                current = current * 2;
            }
            answer *= Pow(x, (int)(ln - current));
            if (neg)
            {
                answer = 1 / answer;
            }
            return answer;
        }

        [Fact]
        public void Q050_PowXN()
        {
            TestHelper.Run(input => Pow(input[0].ToDouble(), input[1].ToInt()).ToString("f5"));
        }
    }
}
