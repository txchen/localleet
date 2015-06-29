using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
// For example,
// If n = 4 and k = 2, a solution is:

// [
//  [2,4],
//  [3,4],
//  [2,3],
//  [1,2],
//  [1,3],
//  [1,4],
// ]

namespace LocalLeet
{
    
    public class Q077_Combinations
    {
        public int[][] Combinations(int n, int k)
        {
            List<int[]> result = new List<int[]>();
            int[] tmp = new int[k]; // just fill in tmp, and copy to result
            ComboRecur(n, k, 0, 1, result, tmp);
            return result.ToArray();
        }
        
        private void ComboRecur(int n, int k, int level, int startNum, List<int[]> result, int[] tmp)
        {
            if (k == level)
            {
                result.Add(tmp.ToArray()); // toArray to copy
                return;
            }
            for (int i = startNum; i <= n; i++)
            {
                tmp[level] = i;
                ComboRecur(n, k, level + 1, i + 1, result, tmp);
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Combinations(input.GetToken(0).ToInt(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q077_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q077_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
