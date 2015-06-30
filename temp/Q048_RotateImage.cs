using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// You are given an n x n 2D matrix representing an image.

// Rotate the image by 90 degrees (clockwise).

// Follow up:
// Could you do this in-place?

namespace LocalLeet
{
    public class Q048_RotateImage
    {
        public int[][] Rotate(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return new int[0][];
            }
            int left = 0, right = matrix.Length - 1, top = 0, bottom = matrix.Length - 1;
            while (left < right)
            {
                for (int i = 0; i < right - left; i++)
                {
                    int temp = matrix[top][left + i];
                    matrix[top][left + i] = matrix[bottom - i][left];
                    matrix[bottom - i][left] = matrix[bottom][right - i];
                    matrix[bottom][right - i] = matrix[top + i][right];
                    matrix[top + i][right] = temp;
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return matrix;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Rotate(input[0].ToIntArrayArray()));
        }

        [Fact]
        public void Q048_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q048_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
