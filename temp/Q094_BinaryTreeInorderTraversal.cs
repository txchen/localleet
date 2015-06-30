using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the inorder traversal of its nodes' values.

// For example:
// Given binary tree {1,#,2,3},

//    1
//     \
//      2
//     /
//    3
// return [1,3,2].

// Note: Recursive solution is trivial, could you do it iteratively?

namespace LocalLeet
{
    public class Q094_BinaryTreeInorderTraversal
    {
        public int[] InorderTraversal(BinaryTree root)
        {
            var answer = new List<int>();
            InorderTraveralNonRecur(root, answer);
            return answer.ToArray();
        }

        private void InorderTraversalRecur(BinaryTree root, List<int> answer)
        {
            if (root != null)
            {
                InorderTraversalRecur(root.Left, answer);
                answer.Add(root.Value);
                InorderTraversalRecur(root.Right, answer);
            }
        }

        private void InorderTraveralNonRecur(BinaryTree root, List<int> answer)
        {
            Stack<BinaryTree> stk = new Stack<BinaryTree>();
            while (root != null)
            {
                stk.Push(root);
                root = root.Left;
            }
            while (stk.Count > 0)
            {
                var node = stk.Pop();
                answer.Add(node.Value);
                if (node.Right != null)
                {
                    var temp = node.Right;
                    while (temp != null)
                    {
                        stk.Push(temp);
                        temp = temp.Left;
                    }
                }
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(InorderTraversal(input[0].ToBinaryTree()));
        }

        [Fact]
        public void Q094_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
