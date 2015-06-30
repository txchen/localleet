using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

// For example:
// Given the below binary tree and sum = 22,
//               5
//              / \
//             4   8
//            /   / \
//           11  13  4
//          /  \    / \
//         7    2  5   1
// return

// [
//    [5,4,11,2],
//    [5,8,4,5]
// ]

// https://leetcode.com/problems/path-sum-ii/
namespace LocalLeet
{
    public class Q113
    {
        public int[][] PathSum(BinaryTree root, int sum)
        {
            if (root == null)
            {
                return new int[0][];
            }
            List<int[]> answer = new List<int[]>();
            List<int> currentPath = new List<int>();
            PathSum(root, sum, answer, currentPath);
            return answer.ToArray();
        }

        private void PathSum(BinaryTree root, int sum, List<int[]> answer, List<int> currentPath)
        {
            if (root.Left == null && root.Right == null && sum == root.Value)
            {
                currentPath.Add(root.Value);
                answer.Add(currentPath.ToArray());
                currentPath.RemoveAt(currentPath.Count - 1);
                return;
            }
            if (root.Left != null)
            {
                currentPath.Add(root.Value);
                PathSum(root.Left, sum - root.Value, answer, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
            if (root.Right != null)
            {
                currentPath.Add(root.Value);
                PathSum(root.Right, sum - root.Value, answer, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }

        [Fact]
        public void Q113_PathSumII()
        {
            TestHelper.Run(input => TestHelper.Serialize(PathSum(input[0].ToBinaryTree(), input[1].ToInt())));
        }
    }
}
