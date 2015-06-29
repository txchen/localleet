using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given an index k, return the kth row of the Pascal's triangle.

// For example, given k = 3,
// Return [1,3,3,1].

// Note:
// Could you optimize your algorithm to use only O(k) extra space?

namespace LocalLeet
{

    public class Q119_PascalTriangleII
    {
        public int[] GetRow(int rowIndex)
        {
            if (rowIndex < 0)
            {
                return new int[0];
            }
            int[] row = new int[rowIndex + 1];
            row[0] = 1;
            for (int r = 1; r <= rowIndex; r++)
            {
                int previous = 1;
                for (int j = 1; j < r; j++)
                {
                    row[j] = previous + row[j];
                    previous = row[j] - previous; // key point here!
                }
                row[r] = 1;
            }
            return row;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GetRow(input.ToInt()));
        }

        [TestMethod]
        public void Q119_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q119_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
