using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

// For example,
// Given n = 3, there are a total of 5 unique BST's.

//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3

namespace LocalLeet
{

    public class Q096_UniqueBinarySearchTrees
    {
        public int NumTrees(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            int answer = 0;
            for (int i = 1; i <= n; i++)
            {
                answer += NumTrees(i - 1) * NumTrees(n - i);
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return NumTrees(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q096_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q096_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
