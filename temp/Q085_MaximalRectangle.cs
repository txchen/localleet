using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing all ones and return its area.

// |   | X |   | X | X |   |                    | 0 | 1 | 0 | 1 | 1 | 0 |
// -------------------------                    -------------------------
// | X | X | X | X | X |   |                    | 1 | 2 | 1 | 2 | 2 | 0 |
// -------------------------                    -------------------------
// |   | X | X | X | X | X |                    | 0 | 3 | 2 | 3 | 3 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X |   |   |                    | 0 | 4 | 3 | 4 | 0 | 0 |
// -------------------------    ============>   -------------------------
// |   | X | X | X | X | X |                    | 0 | 5 | 4 | 5 | 1 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X | X |   |                    | 0 | 6 | 5 | 6 | 2 | 0 |
// -------------------------                    -------------------------
// | X | X | X |   | X | X |                    | 1 | 7 | 6 | 0 | 3 | 1 |
// -------------------------                    -------------------------
// |   | X | X | X |   |   |                    | 0 | 8 | 7 | 1 | 0 | 0 |

namespace LocalLeet
{
    public class Q085_MaximalRectangle
    {
        public int MaximalRectangle(string[] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }
            int[][] data = new int[matrix.Length][];
            for (int i = 0; i < data.Length; i++)
			{
                data[i] = new int[matrix[0].Length];
			}
            // convert the data like above image
            // then use Q84 algorithm to calculate the max
            for (int c = 0; c < matrix[0].Length; c++)
            {
                int currentCont = 0;
                for (int r = 0; r < matrix.Length; r++)
                {
                    if (matrix[r][c] == '1')
                    {
                        currentCont++;
                        data[r][c] = currentCont;
                    }
                    else
                    {
                        currentCont = 0;
                    }
                }
            }
            // now use Q84, count hist max area
            int answer = 0;
            Q084_LargestRectangleinHistogram q84 = new Q084_LargestRectangleinHistogram();
            for (int r = 0; r < matrix.Length; r++)
            {
                answer = Math.Max(answer, q84.LargestRectangleArea(data[r]));
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return MaximalRectangle(input[0].ToStringArray()).ToString();
        }

        [Fact]
        public void Q085_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
