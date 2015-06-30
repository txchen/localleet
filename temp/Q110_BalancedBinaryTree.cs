using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, determine if it is height-balanced.

// For this problem, a height-balanced binary tree is defined as a binary tree in which the
// depth of the two subtrees of every node never differ by more than 1.

namespace LocalLeet
{
    public class Q110_BalancedBinaryTree
    {
        public bool IsBalanced(BinaryTree root)
        {
            return MaxDepth(root) >= 0;
        }

        private int MaxDepth(BinaryTree root) // if not balanced, return -1
        {
            if (root == null)
            {
                return 0;
            }
            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);
            if (Math.Abs(leftDepth - rightDepth) >= 2 || leftDepth == -1 || rightDepth == -1)
            {
                return -1;
            }
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public string SolveQuestion(string input)
        {
            return IsBalanced(input[0].ToBinaryTree()).ToString().ToLower();
        }

        [Fact]
        public void Q110_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
