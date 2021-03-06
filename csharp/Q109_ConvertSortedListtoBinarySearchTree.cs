using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

// https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/
namespace LocalLeet
{
    public class Q109
    {
        public BinaryTree SortedListToBST(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }
            // get length first
            int length = 0;
            var tmp = head;
            while (tmp != null)
            {
                tmp = tmp.Next;
                length++;
            }
            return SortListToBST(ref head, length); // must use ref here
        }

        private BinaryTree SortListToBST(ref ListNode<int> head, int length)
        {
            if (length <= 0)
            {
                return null;
            }
            BinaryTree root = new BinaryTree(0);
            int leftLength = length / 2;
            int rightLength = length - 1 - length / 2;
            root.Left = SortListToBST(ref head, leftLength);
            root.Value = head.Val;
            head = head.Next;
            root.Right = SortListToBST(ref head, rightLength);
            return root;
        }

        [Fact]
        public void Q109_ConvertSortedListtoBinarySearchTree()
        {
            TestHelper.Run(input => SortedListToBST(input[0].ToListNode<int>()).SerializeBinaryTree());
        }
    }
}
