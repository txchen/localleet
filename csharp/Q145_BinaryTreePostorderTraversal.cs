using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the postorder traversal of its nodes' values.
//
// For example:
// Given binary tree {1,#,2,3},
//    1
//     \
//      2
//     /
//    3
// return [3,2,1].
//
// Note: Recursive solution is trivial, could you do it iteratively?

// https://leetcode.com/problems/binary-tree-postorder-traversal/
namespace LocalLeet
{
    public class Q145
    {
        public int[] PostorderTraversal(BinaryTree root) {
            if (root == null)
            {
                return new int[0];
            }
            Stack<BinaryTree> stk = new Stack<BinaryTree>();
            Stack<int> answer = new Stack<int>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                var n = stk.Pop();
                answer.Push(n.Value);
                if (n.Left != null)
                {
                    stk.Push(n.Left);
                }
                if (n.Right != null)
                {
                    stk.Push(n.Right);
                }
            }
            List<int> a = new List<int>();
            while (answer.Count > 0)
            {
                a.Add(answer.Pop());
            }
            return a.ToArray();
        }

        [Fact]
        public void Q145_BinaryTreePostorderTraversal()
        {
            TestHelper.Run(input => TestHelper.Serialize(PostorderTraversal(input.EntireInput.ToBinaryTree2())));
        }
    }
}
