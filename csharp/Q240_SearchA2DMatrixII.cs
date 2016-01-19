using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
//
// Integers in each row are sorted in ascending from left to right.
// Integers in each column are sorted in ascending from top to bottom.
// For example,
//
// Consider the following matrix:
//
// [
//   [1,   4,  7, 11, 15],
//   [2,   5,  8, 12, 19],
//   [3,   6,  9, 16, 22],
//   [10, 13, 14, 17, 24],
//   [18, 21, 23, 26, 30]
// ]
// Given target = 5, return true.
//
// Given target = 20, return false.

// https://leetcode.com/problems/search-a-2d-matrix-ii/
namespace LocalLeet
{
    public class Q240
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            return SearchMatrixInt(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1, target);
        }

        private bool SearchMatrixInt(int[,] matrix, int top, int bottom, int left, int right, int target)
        {
            if (top > bottom || left > right)
            {
                return false;
            }
            int vMid = (top + bottom ) / 2;
            int hMid = (left + right) / 2;
            int mValue = matrix[vMid, hMid];
            if (mValue == target)
            {
                return true;
            }
            else if (mValue > target)
            {
                return SearchMatrixInt(matrix, top, vMid - 1, left, right, target) ||
                    SearchMatrixInt(matrix, vMid, bottom, left, hMid - 1, target);
            }
            else
            {
                return SearchMatrixInt(matrix, top, vMid, hMid + 1, right, target) ||
                    SearchMatrixInt(matrix, vMid + 1, bottom, left, right, target);
            }
        }

        [Fact]
        public void Q240_SearchA2DMatrixII()
        {
            TestHelper.Run(input => SearchMatrix(input[0].ToInt2DArray(), input[1].ToInt()).ToString().ToLower());
        }
    }
}
