using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, find the maximum path sum.

// The path may start and end at any node in the tree.

// For example:
// Given the below binary tree,

//       1
//      / \
//     2   3
// Return 6.

namespace LocalLeet
{
    public class Q124_BinaryTreeMaximumPathSum
    {
        public int MaxPathSum(BinaryTree root)
        {
            return MaxPathSumInt(root).Item2;
        }

        // Item1, answer that including root, can be combine with upstream node, so it can only connect to 1 child
        // Item2, answer
        public Tuple<int, int> MaxPathSumInt(BinaryTree root)
        {
            if (root == null)
            {
                return Tuple.Create(0, 0);
            }
            if (root.Left == null && root.Right == null)
            {
                return Tuple.Create(root.Value, root.Value);
            }
            if (root.Left == null)
            {
                var rAnswer = MaxPathSumInt(root.Right);
                int item1 = Math.Max(0, rAnswer.Item1) + root.Value;
                int item2 = (new[] { item1, rAnswer.Item2 }).Max();
                return Tuple.Create(item1, item2);
            }
            if (root.Right == null)
            {
                var lAnswer = MaxPathSumInt(root.Left);
                int item1 = Math.Max(0, lAnswer.Item1) + root.Value;
                int item2 = (new[] { item1, lAnswer.Item2 }).Max();
                return Tuple.Create(item1, item2);
            }
            // left and right both exist
            var ll = MaxPathSumInt(root.Left);
            var rr = MaxPathSumInt(root.Right);
            int a1 = Math.Max(0, Math.Max(ll.Item1, rr.Item1)) + root.Value;
            int a2 = (new[] { a1, ll.Item2, rr.Item2, (root.Value + ll.Item1 + rr.Item1) }).Max();
            return Tuple.Create(a1, a2);
        }

        public string SolveQuestion(string input)
        {
            return MaxPathSum(input[0].ToBinaryTree()).ToString();
        }

        [Fact]
        public void Q124_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q124_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
