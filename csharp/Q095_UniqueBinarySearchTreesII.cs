using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

// For example,
// Given n = 3, your program should return all 5 unique BST's shown below.

//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3

// https://leetcode.com/problems/unique-binary-search-trees-ii/
namespace LocalLeet
{
    public class Q095
    {
        public BinaryTree[] GenerateTrees(int n)
        {
            return GenerateTrees(1, n);
        }

        private BinaryTree[] GenerateTrees(int from, int to)
        {
            if (from > to)
            {
                return new BinaryTree[1];
            }
            List<BinaryTree> answer = new List<BinaryTree>();
            for (int i = from; i <= to; i++)
            {
                BinaryTree[] lefts = GenerateTrees(from, i - 1);
                BinaryTree[] rights = GenerateTrees(i + 1, to);
                foreach (var left in lefts)
                {
                    foreach (var right in rights)
                    {
                        BinaryTree root = new BinaryTree(i);
                        root.Left = left;
                        root.Right = right;
                        answer.Add(root);
                    }
                }

            }
            return answer.ToArray();
        }

        [Fact]
        public void Q095_UniqueBinarySearchTreesII()
        {
            TestHelper.Run(input => GenerateTrees(input[0].ToInt()).SerializeBinaryTreeArray());
        }
    }
}
