using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.

// Follow up:
// Did you use extra space?
// A straight forward solution using O(mn) space is probably a bad idea.
// A simple improvement uses O(m + n) space, but still not the best solution.
// Could you devise a constant space solution?

namespace LocalLeet
{
    public class Q073
    {
        public int[][] SetZeroes(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return matrix;
            }
            // use the top and left edge to store the '0'
            int rowCount = matrix.Length;
            int colCount = matrix[0].Length;
            bool firstRowZero = matrix[0].Any(i => i == 0);
            bool firstColZero = matrix.Any(r => r[0] == 0);
            for (int r =1; r < rowCount; r++)
            {
                for (int c = 1; c < colCount; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[0][c] = matrix[r][0] = 0;
                     }
                }
            }
            for (int c = 1; c < colCount; c++)
            {
                if (matrix[0][c] == 0)
                {
                    for (int r = 0; r < rowCount; r++)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }
            for (int r = 1; r < rowCount; r++)
            {
                if (matrix[r][0] == 0)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }
            if (firstRowZero)
            {
                for (int c = 0; c < colCount; c++)
                {
                    matrix[0][c] = 0;
                }
            }
            if (firstColZero)
            {
                for (int r = 0; r < rowCount; r++)
                {
                    matrix[r][0] = 0;
                }
            }
            return matrix;
        }

        [Fact]
        public void Q073_SetMatrixZeroes()
        {
            TestHelper.Run(input => TestHelper.Serialize(SetZeroes(input[0].ToIntArrayArray())));
        }
    }
}
