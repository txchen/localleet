using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a triangle, find the minimum path sum from top to bottom.
// Each step you may move to adjacent numbers on the row below.

// For example, given the following triangle

// [
//      [2],
//     [3,4],
//    [6,5,7],
//   [4,1,8,3]
// ]
// The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

// Note:
// Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.

// https://leetcode.com/problems/triangle/
namespace LocalLeet
{
    public class Q120
    {
        public int MinimumTotal(int[][] triangle)
        {
            int[] answer = triangle[triangle.Length - 1]; // last row;
            // calculate every row
            for (int j = triangle.Length - 2; j >= 0; j--)
            {
                for (int i = 0; i <= j; i++)
                {
                    answer[i] = triangle[j][i] + Math.Min(answer[i], answer[i + 1]);
                }
            }
            return answer[0];
        }

        [Fact]
        public void Q120_Triangle()
        {
            TestHelper.Run(input => MinimumTotal(input[0].ToIntArrayArray()).ToString());
        }
    }
}
