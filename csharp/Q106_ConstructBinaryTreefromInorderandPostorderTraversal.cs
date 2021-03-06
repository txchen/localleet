using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given inorder and postorder traversal of a tree, construct the binary tree.

// Note:
// You may assume that duplicates do not exist in the tree.

// https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
namespace LocalLeet
{
    public class Q106
    {
        public BinaryTree BuildTree(int[] inOrder, int[] postOrder)
        {
            return BuildTree(inOrder, 0, inOrder.Length - 1, postOrder, 0, postOrder.Length - 1);
        }

        private BinaryTree BuildTree(int[] inOrder, int inStart, int inEnd, int[] postOrder, int postStart, int postEnd)
        {
            if (postStart > postEnd || inStart > inEnd)
            {
                return null;
            }
            BinaryTree root = new BinaryTree(postOrder[postEnd]);
            // find where is the root in inorder
            int i = inStart;
            for (; i <= inEnd; i++)
            {
                if (inOrder[i] == postOrder[postEnd])
                {
                    break;
                }
            }
            root.Left = BuildTree(inOrder, inStart, i - 1, postOrder, postStart, postStart + i - inStart - 1);
            root.Right = BuildTree(inOrder, i + 1, inEnd, postOrder, postStart + i - inStart, postEnd - 1);
            return root;
        }

        [Fact]
        public void Q106_ConstructBinaryTreefromInorderandPostorderTraversal()
        {
            TestHelper.Run(input => BuildTree(input[0].ToIntArray(), input[1].ToIntArray()).SerializeBinaryTree());
        }
    }
}
