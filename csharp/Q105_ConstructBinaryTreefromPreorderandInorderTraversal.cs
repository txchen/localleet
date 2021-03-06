using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given preorder and inorder traversal of a tree, construct the binary tree.

// Note:
// You may assume that duplicates do not exist in the tree.

// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
namespace LocalLeet
{
    public class Q105
    {
        public BinaryTree BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private BinaryTree BuildTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd)
            {
                return null;
            }
            BinaryTree root = new BinaryTree(preorder[preStart]);
            // find where is the root in inorder
            int i = inStart;
            for (; i <= inEnd; i++)
            {
                if (inorder[i] == preorder[preStart])
                {
                    break;
                }
            }
            root.Left = BuildTree(preorder, preStart + 1, preStart + i - inStart, inorder, inStart, i - 1);
            root.Right = BuildTree(preorder, preStart + i - inStart + 1, preEnd, inorder, i + 1, inEnd);
            return root;
        }

        [Fact]
        public void Q105_ConstructBinaryTreefromPreorderandInorderTraversal()
        {
            TestHelper.Run(input => BuildTree(input[0].ToIntArray(), input[1].ToIntArray()).SerializeBinaryTree());
        }
    }
}
