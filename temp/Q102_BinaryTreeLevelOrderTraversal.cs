using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its level order traversal as:

// [
//  [3],
//  [9,20],
//  [15,7]
// ]

namespace LocalLeet
{
    public class Q102
    {
        public int[][] LevelOrder(BinaryTree root)
        {
            if (root == null)
            {
                return new int[0][];
            }
            List<int[]> answer = new List<int[]>();
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                List<int> currentLevel = new List<int>();
                Queue<BinaryTree> nq = new Queue<BinaryTree>();
                while(q.Count > 0)
                {
                    var node = q.Dequeue();
                    currentLevel.Add(node.Value);
                    if (node.Left != null)
                    {
                        nq.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        nq.Enqueue(node.Right);
                    }
                }
                answer.Add(currentLevel.ToArray());
                q = nq;
            }
            return answer.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LevelOrder(input[0].ToBinaryTree()));
        }

        [Fact]
        public void Q102_BinaryTreeLevelOrderTraversal()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
