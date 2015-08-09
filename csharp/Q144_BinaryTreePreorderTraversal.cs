using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the preorder traversal of its nodes' values.
//
// For example:
// Given binary tree {1,#,2,3},
//    1
//     \
//      2
//     /
//    3
// return [1,2,3].
//
// Note: Recursive solution is trivial, could you do it iteratively?

// https://leetcode.com/problems/binary-tree-preorder-traversal/
namespace LocalLeet
{
    public class Q144
    {
        public int[] PreorderTraversal(BinaryTree root)
        {
            if (root == null)
            {
                return new int[0];
            }
            List<int> answer = new List<int>();
            Stack<BinaryTree> stk = new Stack<BinaryTree>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                var n = stk.Pop();
                answer.Add(n.Value);
                if (n.Right != null)
                {
                    stk.Push(n.Right);
                }
                if (n.Left != null)
                {
                    stk.Push(n.Left);
                }
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q144_BinaryTreePreorderTraversal()
        {
            TestHelper.Run(input => TestHelper.Serialize(PreorderTraversal(input.EntireInput.ToBinaryTree2())));
        }
    }
}
