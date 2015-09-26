using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
//
// Example 1:
//
// 11110
// 11010
// 11000
// 00000
// Answer: 1
//
// Example 2:
//
// 11000
// 11000
// 00100
// 00011
// Answer: 3

// https://leetcode.com/problems/number-of-islands/
namespace LocalLeet
{
    public class Q200
    {
        public int NumIslands(char[,] grid)
        {
            if (grid.Length == 0)
            {
                return 0;
            }
            int answer = 0;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c =0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == '1')
                    {
                        MarkGrid(grid, r, c);
                        answer++;
                    }
                }
            }
            return answer;
        }

        private void MarkGrid(char[,] grid, int r, int c)
        {
            if (r < 0 || r >= grid.GetLength(0) || c < 0 || c >= grid.GetLength(1))
            {
                return;
            }
            if (grid[r,c] == '1')
            {
                grid[r,c] = '0';
                MarkGrid(grid, r + 1, c);
                MarkGrid(grid, r - 1, c);
                MarkGrid(grid, r, c + 1);
                MarkGrid(grid, r, c - 1);
            }
        }

        [Fact]
        public void Q200_NumberOfIslands()
        {
            TestHelper.Run(input => {
                var inputRows = input.EntireInput.ToStringArray();
                char[,] inputCharMap;
                if (inputRows.Length >= 1)
                {
                    inputCharMap = new char[inputRows.Length, inputRows[0].Length];
                    for (int i = 0; i < inputRows.Length; i++)
                    {
                        for (int j = 0; j < inputRows[i].Length; j++)
                        {
                            inputCharMap[i, j] = inputRows[i][j];
                        }
                    }
                }
                else
                {
                    inputCharMap = new char[0, 0];
                }
                return NumIslands(inputCharMap).ToString();
            });
        }
    }
}
