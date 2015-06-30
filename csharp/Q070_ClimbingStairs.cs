using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// You are climbing a stair case. It takes n steps to reach to the top.

// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

// https://leetcode.com/problems/climbing-stairs/
namespace LocalLeet
{
    public class Q070
    {
        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            int a = 1, b = 2;
            for (int i = 2; i < n; i++) // try from 3 to n
            {
                int tmp = a;
                a = b;
                b = b + tmp;
            }
            return b;
        }

        [Fact]
        public void Q070_ClimbingStairs()
        {
            TestHelper.Run(input => ClimbStairs(input[0].ToInt()).ToString());
        }
    }
}
