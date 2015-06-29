using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

// For example,
// Given the following matrix:

// [
//  [ 1, 2, 3 ],
//  [ 4, 5, 6 ],
//  [ 7, 8, 9 ]
// ]
// You should return [1,2,3,6,9,8,7,4,5].

namespace LocalLeet
{
    
    public class Q054_SpiralMatrix
    {
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return new int[0];
            }
            var answer = new List<int>();
            int left = 0, right = matrix[0].Length - 1, top = 0, bottom = matrix.Length - 1;
            while (left < right && top < bottom)
            {
                // top edge
                for (int i = left; i < right; i++)
                {
                    answer.Add(matrix[top][i]);
                }
                // right edge
                for (int i = top; i < bottom; i++)
                {
                    answer.Add(matrix[i][right]);
                }
                // bottom edege
                for (int i = right; i > left; i--)
                {
                    answer.Add(matrix[bottom][i]);
                }
                // left edge
                for (int i = bottom; i > top; i--)
                {
                    answer.Add(matrix[i][left]);
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            if (top == bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    answer.Add(matrix[top][i]);
                }
            }
            else if (left == right)
            {
                for (int i = top; i <= bottom; i++)
                {
                    answer.Add(matrix[i][left]);
                }
            }
            return answer.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SpiralOrder(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q054_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q054_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
