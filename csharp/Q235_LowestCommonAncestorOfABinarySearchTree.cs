using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.
//
// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”
//
//         _______6______
//        /              \
//     ___2__          ___8__
//    /      \        /      \
//    0      _4       7       9
//          /  \
//          3   5
// For example, the lowest common ancestor (LCA) of nodes 2 and 8 is 6. Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
namespace LocalLeet
{
    public class Q235
    {
        public BinaryTree LowestCommonAncestor(BinaryTree root, BinaryTree p, BinaryTree q)
        {
            int pVal = p.Value;
            int qVal = q.Value;
            int rVal = root.Value;
            if (pVal < rVal && qVal < rVal)
            {
                return LowestCommonAncestor(root.Left, p, q);
            }
            else if (pVal > rVal && qVal > rVal)
            {
                return LowestCommonAncestor(root.Right, p, q);
            }
            return root;
        }

        private BinaryTree FindTreeNode(BinaryTree root, int value)
        {
            if (root == null)
            {
                return null;
            }
            if (root.Value == value)
            {
                return root;
            }
            return FindTreeNode(root.Left, value) ?? FindTreeNode(root.Right, value);
        }

        [Fact]
        public void Q235_LowestCommonAncestorOfABinarySearchTree()
        {
            // "input":"[3,1,4,null,2], node with value 2, node with value 4","expected":"3"
            TestHelper.Run(input => {
                var tree = input[0].ToBinaryTree2();
                var v1 = int.Parse(input[1].Replace("node with value ", ""));
                var v2 = int.Parse(input[2].Replace("node with value ", ""));
                var p = FindTreeNode(tree, v1);
                var q = FindTreeNode(tree, v2);
                return LowestCommonAncestor(tree, p, q).Value.ToString();
            });
        }
    }
}
