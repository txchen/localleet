using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
//
// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”
//
//         _______3______
//        /              \
//     ___5__          ___1__
//    /      \        /      \
//    6      _2       0       8
//          /  \
//          7   4
// For example, the lowest common ancestor (LCA) of nodes 5 and 1 is 3. Another example is LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
namespace LocalLeet
{
    public class Q236
    {
        public BinaryTree LowestCommonAncestor(BinaryTree root, BinaryTree p, BinaryTree q)
        {
            if (root == null)
            {
                return null;
            }
            var l = LowestCommonAncestor(root.Left, p, q);
            if (l != null)
            {
                return l;
            }
            var r = LowestCommonAncestor(root.Right, p, q);
            if (r != null)
            {
                return r;
            }
            if (CoversNode(root, p) && CoversNode(root, q))
            {
                return root;
            }
            return null;
        }

        private bool CoversNode(BinaryTree root, BinaryTree p)
        {
            if (root == null)
            {
                return false;
            }
            if (root == p)
            {
                return true;
            }
            return CoversNode(root.Left, p) || CoversNode(root.Right, p);
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
        public void Q236_LowestCommonAncestorOfABinaryTree()
        {
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
