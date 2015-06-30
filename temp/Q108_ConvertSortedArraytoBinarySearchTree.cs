using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

namespace LocalLeet
{
    public class Q108_ConvertSortedArraytoBinarySearchTree
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

        public string SolveQuestion(string input)
        {
            return SortedArrayToBST(input.ToIntArray()).SerializeBinaryTree();
        }

        [Fact]
        public void Q108_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q108_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
