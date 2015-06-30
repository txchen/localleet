using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
namespace LocalLeet
{
    public class Q108
    {
        public BinaryTree SortedArrayToBST(int[] num)
        {
            if (num == null || num.Length == 0)
            {
                return null;
            }
            BinaryTree root = new BinaryTree(num[num.Length / 2]);
            root.Left = SortedArrayToBST(num.Take(num.Length / 2).ToArray());
            root.Right = SortedArrayToBST(num.Skip(num.Length / 2 + 1).ToArray());
            return root;
        }

        [Fact]
        public void Q108_ConvertSortedArraytoBinarySearchTree()
        {
            TestHelper.Run(input => SortedArrayToBST(input[0].ToIntArray()).SerializeBinaryTree());
        }
    }
}
