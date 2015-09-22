using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
//
// For example:
// Given the following binary tree,
//    1            <---
//  /   \
// 2     3         <---
//  \     \
//   5     4       <---
// You should return [1, 3, 4].

// https://leetcode.com/problems/binary-tree-right-side-view/
namespace LocalLeet
{
    public class Q199
    {
        public int[] RightSideView(BinaryTree root)
        {
            int seeDepth = 0;
            List<int> answer = new List<int>();
            Scan(root, 1, answer, ref seeDepth);
            return answer.ToArray();
        }

        private void Scan(BinaryTree root, int currentDepth, List<int> answer, ref int seenDepth)
        {
            if (root == null)
            {
                return;
            }
            if (currentDepth > seenDepth)
            {
                seenDepth = currentDepth;
                answer.Add(root.Value);
            }
            Scan(root.Right, currentDepth + 1, answer, ref seenDepth);
            Scan(root.Left, currentDepth + 1, answer, ref seenDepth);
        }

        [Fact]
        public void Q199_BinaryTreeRightSideView()
        {
            TestHelper.Run(input => TestHelper.Serialize(RightSideView(input.EntireInput.ToBinaryTree2())));
        }
    }
}
