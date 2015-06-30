using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Follow up for "Unique Paths":
// Now consider if some obstacles are added to the grids. How many unique paths would there be?
// An obstacle and empty space is marked as 1 and 0 respectively in the grid.
// For example,

// There is one obstacle in the middle of a 3x3 grid as illustrated below.

// [
//   [0,0,0],
//   [0,1,0],
//   [0,0,0]
// ]
// The total number of unique paths is 2.

// Note: m and n will be at most 100.

namespace LocalLeet
{
    public class Q063
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int rowCount = obstacleGrid.Length;
            int colCount = obstacleGrid[0].Length;
            int[] tmp = new int[rowCount];
            tmp[rowCount - 1] = 1;
            for (int c = colCount - 1; c >= 0; c--)
            {
                for (int r = rowCount - 1; r >= 0; r--)
                {
                    if (obstacleGrid[r][c] == 1)
                    {
                        tmp[r] = 0;
                    }
                    else if (r < rowCount -1)
                    {
                        tmp[r] = tmp[r + 1] + tmp[r];
                    }
                }
            }
            return tmp[0];
        }

        [Fact]
        public void Q063_UniquePathsII()
        {
            TestHelper.Run(input => UniquePathsWithObstacles(input[0].ToIntArrayArray()).ToString());
        }
    }
}
