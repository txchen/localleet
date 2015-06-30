using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree and a sum, determine if the tree has a root-to-leaf path
// such that adding up all the values along the path equals the given sum.

// For example:
// Given the below binary tree and sum = 22,
//               5
//              / \
//             4   8
//            /   / \
//           11  13  4
//          /  \      \
//         7    2      1
// return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

namespace LocalLeet
{
    public class Q112_PathSum
    {
        public bool HasPathSum(BinaryTree root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.Left == null && root.Right == null)
            {
                return sum == root.Value;
            }
            if (root.Left != null && HasPathSum(root.Left, sum - root.Value))
            {
                return true;
            }
            if (root.Right != null && HasPathSum(root.Right, sum - root.Value))
            {
                return true;
            }
            return false;
        }

        public string SolveQuestion(string input)
        {
            return HasPathSum(input[0].ToBinaryTree(), input[1].ToInt()).ToString().ToLower();
        }

        [Fact]
        public void Q112_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
