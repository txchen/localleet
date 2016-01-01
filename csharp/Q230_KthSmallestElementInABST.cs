using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.
//
// Note:
// You may assume k is always valid, 1 ≤ k ≤ BST's total elements.
//
// Follow up:
// What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

// https://leetcode.com/problems/kth-smallest-element-in-a-bst/
namespace LocalLeet
{
    public class Q230
    {
        public int KthSmallest(BinaryTree root, int k)
        {
            int leftCount = NodeCount(root.Left);
            if (leftCount >= k)
            {
                return KthSmallest(root.Left, k);
            }
            else if (leftCount + 1 == k)
            {
                return root.Value;
            }
            else
            {
                return KthSmallest(root.Right, k - 1 - leftCount);
            }
        }

        private int NodeCount(BinaryTree root)
        {
            if (root != null)
            {
                return 1 + NodeCount(root.Left) + NodeCount(root.Right);
            }
            return 0;
        }

        [Fact]
        public void Q230_KthSmallestElementInABST()
        {
            TestHelper.Run(input => KthSmallest(input[0].ToBinaryTree2(), input[1].ToInt()).ToString());
        }
    }
}
