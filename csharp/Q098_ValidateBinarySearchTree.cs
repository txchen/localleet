using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, determine if it is a valid binary search tree (BST).

// Assume a BST is defined as follows:

// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.

namespace LocalLeet
{
    public class Q098
    {
        public bool IsValidBST(BinaryTree root)
        {
            if (root == null)
            {
                return true;
            }
            int previousValue = int.MinValue;
            Stack<BinaryTree> stk = new Stack<BinaryTree>();
            while (root != null)
            {
                stk.Push(root);
                root = root.Left;
            }
            while (stk.Count > 0)
            {
                var node = stk.Pop();
                if (node.Value <= previousValue)
                {
                    return false;
                }
                previousValue = node.Value;
                var right = node.Right;
                while (right != null)
                {
                    stk.Push(right);
                    right = right.Left;
                }
            }
            return true;
        }

        [Fact]
        public void Q098_ValidateBinarySearchTree()
        {
            TestHelper.Run(input => IsValidBST(input[0].ToBinaryTree()).ToString().ToLower());
        }
    }
}
