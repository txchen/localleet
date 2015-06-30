using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement int sqrt(int x).

// Compute and return the square root of x.

namespace LocalLeet
{
    public class Q069
    {
        public int Sqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x < 4)
            {
                return 1;
            }
            long high = x >> 1;
            long low = high;
            while (low * low > x)
            {
                high = low;
                low = low >> 1;
            }
            if (low * low == x)
            {
                return (int)low;
            }
            while (low < high - 1)
            {
                long mid = (low + high) / 2;
                if (mid * mid == x)
                {
                    return (int)mid;
                }
                else if (mid * mid > x)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            return (int)low;
        }

        [Fact]
        public void Q069_SqrtX()
        {
            TestHelper.Run(input => Sqrt(input[0].ToInt()).ToString());
        }
    }
}
