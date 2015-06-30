using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given numRows, generate the first numRows of Pascal's triangle.

// For example, given numRows = 5,
// Return

// [
//      [1],
//     [1,1],
//    [1,2,1],
//   [1,3,3,1],
//  [1,4,6,4,1]
// ]

// https://leetcode.com/problems/pascals-triangle/
namespace LocalLeet
{
    public class Q118
    {
        public int[][] Generate(int numRows)
        {
            if (numRows <= 0)
            {
                return new int[0][];
            }
            List<int[]> answer = new List<int[]>();
            for (int r = 0; r < numRows; r++)
            {
                var row = new int[r + 1];
                row[0] = row[r] = 1;
                for (int i = 1; i < r; i++)
                {
                    row[i] = answer[r - 1][i] + answer[r - 1][i - 1];
                }
                answer.Add(row);
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q118_PascalTriangle()
        {
            TestHelper.Run(input => TestHelper.Serialize(Generate(input[0].ToInt())));
        }
    }
}
