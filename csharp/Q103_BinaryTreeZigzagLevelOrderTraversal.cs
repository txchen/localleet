using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, return the zigzag level order traversal of its nodes' values.
// (ie, from left to right, then right to left for the next level and alternate between).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its zigzag level order traversal as:

// [
//  [3],
//  [20,9],
//  [15,7]
// ]

// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
namespace LocalLeet
{
    public class Q103
    {
        public int[][] ZigzagLevelOrder(BinaryTree root)
        {
            if (root == null)
            {
                return new int[0][];
            }
            List<int[]> answer = new List<int[]>();
            Stack<BinaryTree> stk1 = new Stack<BinaryTree>();
            Stack<BinaryTree> stk2 = new Stack<BinaryTree>();
            stk1.Push(root);
            while (stk1.Count > 0 || stk2.Count > 0)
            {
                List<int> currentLevel = new List<int>();
                if (stk1.Count > 0)
                {
                    while (stk1.Count > 0)
                    {
                        var temp = stk1.Pop();
                        currentLevel.Add(temp.Value);
                        if (temp.Left != null)
                        {
                            stk2.Push(temp.Left);
                        }
                        if (temp.Right != null)
                        {
                            stk2.Push(temp.Right);
                        }
                    }
                }
                else if (stk2.Count > 0)
                {
                    while (stk2.Count > 0)
                    {
                        var temp = stk2.Pop();
                        currentLevel.Add(temp.Value);
                        if (temp.Right != null)
                        {
                            stk1.Push(temp.Right);
                        }
                        if (temp.Left != null)
                        {
                            stk1.Push(temp.Left);
                        }
                    }
                }
                answer.Add(currentLevel.ToArray());
            }
            return answer.ToArray();
        }

        [Fact]
        public void Q103_BinaryTreeZigzagLevelOrderTraversal()
        {
            TestHelper.Run(input => TestHelper.Serialize(ZigzagLevelOrder(input[0].ToBinaryTree())));
        }
    }
}
