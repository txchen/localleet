using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, find its maximum depth.

// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

namespace LocalLeet
{
    public class Q104
    {
        public int MaxDepth(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
        }

        public string SolveQuestion(string input)
        {
            return MaxDepth(input[0].ToBinaryTree()).ToString();
        }

        [Fact]
        public void Q104_MaximumDepthofBinaryTree()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
