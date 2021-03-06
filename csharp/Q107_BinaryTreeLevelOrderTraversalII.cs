using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the bottom-up level order traversal of its nodes' values.
// (ie, from left to right, level by level from leaf to root).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its bottom-up level order traversal as:

// [
//   [15,7]
//   [9,20],
//   [3],
// ]

// https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
namespace LocalLeet
{
    public class Q107
    {
        public int[][] LevelOrderBottomII(BinaryTree root)
        {
            if (root == null)
            {
                return new int[0][];
            }
            List<BinaryTree> currentLayer = new List<BinaryTree>() { root };
            Stack<int[]> answer = new Stack<int[]>();
            while (true)
            {
                answer.Push(currentLayer.Select(n => n.Value).ToArray());
                var nextLayer = new List<BinaryTree>();
                currentLayer.ForEach(n =>
                {
                    if (n.Left != null)
                    {
                        nextLayer.Add(n.Left);
                    }
                    if (n.Right != null)
                    {
                        nextLayer.Add(n.Right);
                    }
                });
                if (nextLayer.Count == 0)
                {
                    break;
                }
                currentLayer = nextLayer;
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q107_BinaryTreeLevelOrderTraversalII()
        {
            TestHelper.Run(input => TestHelper.Serialize(LevelOrderBottomII(input[0].ToBinaryTree())));
        }
    }
}
