using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a complete binary tree, count the number of nodes.
//
// Definition of a complete binary tree from Wikipedia:
// In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

// https://leetcode.com/problems/count-complete-tree-nodes/
namespace LocalLeet
{
    public class Q222
    {
        public int CountNodes(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftDepth = 0;
            BinaryTree tmp = root;
            while (tmp != null)
            {
                leftDepth++;
                tmp = tmp.Left;
            }
            int rightDepth = 0;
            tmp = root;
            while (tmp != null)
            {
                rightDepth++;
                tmp = tmp.Right;
            }
            if (leftDepth == rightDepth)
            {
                return (int)Math.Pow(2, leftDepth) - 1;
            }
            return 1 + CountNodes(root.Left) + CountNodes(root.Right);
        }

        [Fact]
        public void Q222_CountCompleteTreeNodes()
        {
            TestHelper.Run(input => CountNodes(input.EntireInput.ToBinaryTree2()).ToString());
        }
    }
}
