using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, find its minimum depth.

// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

namespace LocalLeet
{
    public class Q111
    {
        public int MinDepth(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.Left == null && root.Right == null)
            {
                return 1;
            }
            if (root.Left != null && root.Right == null)
            {
                return 1 + MinDepth(root.Left);
            }
            if (root.Right != null && root.Left == null)
            {
                return 1 + MinDepth(root.Right);
            }
            return 1 + Math.Min(MinDepth(root.Left), MinDepth(root.Right));
        }

        public string SolveQuestion(string input)
        {
            return MinDepth(input[0].ToBinaryTree()).ToString();
        }

        [Fact]
        public void Q111_MinimumDepthofBinaryTree()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
