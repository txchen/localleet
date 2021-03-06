using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

// For example,
// Given n = 3,

// You should return the following matrix:
// [
//  [ 1, 2, 3 ],
//  [ 8, 9, 4 ],
//  [ 7, 6, 5 ]
// ]

// https://leetcode.com/problems/spiral-matrix-ii/
namespace LocalLeet
{
    public class Q059
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                answer[i] = new int[n];
            }
            int left = 0, right = n - 1, top = 0, bottom = n - 1;
            int current = 1;
            while (left < right)
            {
                // top
                for (int i = left; i < right; i++)
                {
                    answer[top][i] = current++;
                }
                // right;
                for (int i = top; i < bottom; i++)
                {
                    answer[i][right] = current++;
                }
                // bottom
                for (int i = right; i > left; i--)
                {
                    answer[bottom][i] = current++;
                }
                for (int i = bottom; i > top; i--)
                {
                    answer[i][left] = current++;
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            if (left == right)
            {
                answer[top][left] = current;
            }
            return answer;
        }

        [Fact]
        public void Q059_SpiralMatrixII()
        {
            TestHelper.Run(input => TestHelper.Serialize(GenerateMatrix(input[0].ToInt())));
        }
    }
}
