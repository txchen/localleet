using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Count the number of prime numbers less than a non-negative number, n.

// https://leetcode.com/problems/count-primes/
namespace LocalLeet
{
    public class Q204
    {
        public int CountPrimes(int n)
        {
            if (n <= 2)
            {
                return 0;
            }
            BitArray ba = new BitArray(n);
            int answer = n - 2; // 1 and n should not be counted
            for (int i = 2; i < n ; i++)
            {
                for (int j = i + i; j < n ; j+=i)
                {
                    if (!ba[j])
                    {
                        ba[j] = true;
                        answer--;
                    }
                }
            }
            return answer;
        }

        [Fact]
        public void Q204_CountPrimes()
        {
            TestHelper.Run(input => CountPrimes(input.EntireInput.ToInt()).ToString());
        }
    }
}
