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

// https://leetcode.com/problems/unique-binary-search-trees/
namespace LocalLeet
{
    public class Q096
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

        [Fact]
        public void Q096_UniqueBinarySearchTrees()
        {
            TestHelper.Run(input => NumTrees(input[0].ToInt()).ToString());
        }
    }
}
