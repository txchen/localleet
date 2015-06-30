using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, find its minimum depth.

// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

// https://leetcode.com/problems/minimum-depth-of-binary-tree/
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

        [Fact]
        public void Q111_MinimumDepthofBinaryTree()
        {
            TestHelper.Run(input => MinDepth(input[0].ToBinaryTree()).ToString());
        }
    }
}
