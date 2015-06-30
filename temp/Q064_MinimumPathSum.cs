using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a m x n grid filled with non-negative numbers,
// find a path from top left to bottom right which minimizes the sum of all numbers along its path.

// Note: You can only move either down or right at any point in time.

namespace LocalLeet
{
    public class Q064
    {
        public int MinPathSum(int[][] grid)
        {
            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            int[,] answers = new int[rowCount, colCount];
            answers[rowCount - 1, colCount - 1] = grid[rowCount - 1][colCount - 1];
            // for right and bottom edge, to get answer is very easy
            for (int r = rowCount - 2; r >= 0; r--)
            {
                answers[r, colCount - 1] = grid[r][colCount - 1] + answers[r + 1, colCount - 1];
            }
            for (int c = colCount - 2; c >= 0; c--)
            {
                answers[rowCount - 1, c] = grid[rowCount - 1][c] + answers[rowCount - 1, c + 1];
            }
            // now from right-bottom to top-left, get the answer;
            for (int r = rowCount - 2; r >= 0; r--)
            {
                for (int c = colCount - 2; c >= 0; c--)
                {
                    answers[r, c] = grid[r][c] + Math.Min(answers[r, c + 1], answers[r + 1, c]);
                }
            }
            return answers[0, 0];
        }

        public string SolveQuestion(string input)
        {
            return MinPathSum(input[0].ToIntArrayArray()).ToString();
        }

        [Fact]
        public void Q064_MinimumPathSum()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
