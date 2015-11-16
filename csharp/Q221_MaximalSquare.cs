using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area.
//
// For example, given the following matrix:
//
// 1 0 1 0 0
// 1 0 1 1 1
// 1 1 1 1 1
// 1 0 0 1 0
// Return 4.

// https://leetcode.com/problems/maximal-square/
namespace LocalLeet
{
    public class Q221
    {
        public int MaximalSquare(char[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            // dp[i, j] = n, means i, j is '1', and it is the bottom-right of the square, n is the size
            int[,] dp = new int[row, col];
            int size = 0;
            // init first row and first column
            for (int c = 0; c < col; c++)
            {
                if (matrix[0, c] == '1')
                {
                    dp[0, c] = 1;
                    size = 1;
                }
            }
            for (int r = 0; r < row; r++)
            {
                if (matrix[r, 0] == '1')
                {
                    dp[r, 0] = 1;
                    size = 1;
                }
            }
            // scan the board
            for (int r = 1; r < row; r++)
            {
                for (int c = 1; c < col; c++)
                {
                    if (matrix[r, c] == '1')
                    {
                        // size = min(upleft, left, up) + 1
                        int mySize = Math.Min(dp[r-1, c-1], dp[r-1, c]);
                        mySize = Math.Min(mySize, dp[r, c-1]) + 1;
                        dp[r, c] = mySize;
                        size = Math.Max(size, mySize);
                    }
                }
            }
            return size * size;
        }

        [Fact]
        public void Q221_MaximalSquare()
        {
            TestHelper.Run(input => MaximalSquare(input.EntireInput.ToChar2DArray()).ToString());
        }
    }
}
