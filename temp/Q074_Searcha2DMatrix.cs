using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

// Integers in each row are sorted from left to right.
// The first integer of each row is greater than the last integer of the previous row.
// For example,

// Consider the following matrix:
// [
//  [1,   3,  5,  7],
//  [10, 11, 16, 20],
//  [23, 30, 34, 50]
// ]
// Given target = 3, return true.

namespace LocalLeet
{
    public class Q074
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            // find the row first
            int row = -1;
            int top = 0, bottom = matrix.Length - 1;
            while (top <= bottom)
            {
                int detect = (top + bottom) / 2;
                if (target < matrix[detect][0])
                {
                    bottom = detect - 1;
                }
                else if (target == matrix[detect][0])
                {
                    return true;
                }
                else
                {
                    if (detect + 1 < matrix.Length && matrix[detect + 1][0] > target)
                    {
                        row = detect;
                        break;
                    }
                    if (detect == matrix.Length - 1)
                    {
                        row = detect;
                        break;
                    }
                    top = detect + 1;
                }
            }
            if (row == -1)
            {
                return false;
            }
            int left = 0, right = matrix[0].Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int midValue = matrix[row][mid];
                if (midValue == target)
                {
                    return true;
                }
                else if (midValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return false;
        }

        public string SolveQuestion(string input)
        {
            return SearchMatrix(input[0].ToIntArrayArray(), input[1].ToInt()).ToString()
                .ToLower();
        }

        [Fact]
        public void Q074_Searcha2DMatrix()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
