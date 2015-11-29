using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Invert a binary tree.
//
//      4
//    /   \
//   2     7
//  / \   / \
// 1   3 6   9
// to
//      4
//    /   \
//   7     2
//  / \   / \
// 9   6 3   1

// https://leetcode.com/problems/invert-binary-tree/
namespace LocalLeet
{
    public class Q226
    {
        public BinaryTree InvertTree(BinaryTree root)
        {
            if (root != null)
            {
                BinaryTree tmp = root.Left;
                root.Left = root.Right;
                root.Right = tmp;
                InvertTree(root.Left);
                InvertTree(root.Right);
            }
            return root;
        }

        [Fact]
        public void Q226_InvertBinaryTree()
        {
            TestHelper.Run(input => InvertTree(input.EntireInput.ToBinaryTree2()).SerializeBinaryTree2());
        }
    }
}
