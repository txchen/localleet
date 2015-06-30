using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

// For example, this binary tree is symmetric:

//     1
//    / \
//   2   2
//  / \ / \
// 3  4 4  3
// But the following is not:

//     1
//    / \
//   2   2
//    \   \
//    3    3
// Note:
// Bonus points if you could solve it both recursively and iteratively.

namespace LocalLeet
{
    public class Q101
    {
        public bool IsSymmetric(BinaryTree root)
        {
            // means left->right inorder and right-left inorder, outputs are same
            Stack<BinaryTree> stk1 = new Stack<BinaryTree>(); // l -> r
            Stack<BinaryTree> stk2 = new Stack<BinaryTree>(); // r -> l
            var root1 = root;
            while (root1 != null)
            {
                stk1.Push(root1);
                root1 = root1.Left;
            }
            var root2 = root;
            while (root2 != null)
            {
                stk2.Push(root2);
                root2 = root2.Right;
            }
            while (stk1.Count > 0 && stk1.Count == stk2.Count)
            {
                var node1 = stk1.Pop();
                var node2 = stk2.Pop();
                if (node1.Value != node2.Value)
                {
                    return false;
                }
                node1 = node1.Right;
                while (node1 != null)
                {
                    stk1.Push(node1);
                    node1 = node1.Left;
                }
                node2 = node2.Left;
                while (node2 != null)
                {
                    stk2.Push(node2);
                    node2 = node2.Right;
                }
            }
            return stk1.Count == stk2.Count;
        }

        public string SolveQuestion(string input)
        {
            return IsSymmetric(input[0].ToBinaryTree()).ToString().ToLower();
        }

        [Fact]
        public void Q101_SymmetricTree()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
