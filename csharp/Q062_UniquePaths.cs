using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

// The robot can only move either down or right at any point in time.
// The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

// How many possible unique paths are there?

namespace LocalLeet
{
    public class Q062
    {
        public int UniquePaths(int m, int n)
        {
            int[] tmp = new int[m];
            tmp[0] = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    tmp[j] = tmp[j] + tmp[j - 1];
                }
            }
            return tmp[m - 1];
        }

        [Fact]
        public void Q062_UniquePaths()
        {
            TestHelper.Run(input => UniquePaths(input[0].ToInt(), input[1].ToInt()).ToString());
        }
    }
}
