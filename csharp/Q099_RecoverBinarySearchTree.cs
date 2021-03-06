using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Two elements of a binary search tree (BST) are swapped by mistake.

// Recover the tree without changing its structure.

// Note:
// A solution using O(n) space is pretty straight forward. Could you devise a constant space solution?

// https://leetcode.com/problems/recover-binary-search-tree/
namespace LocalLeet
{
    public class Q099
    {
        public BinaryTree RecoverTree(BinaryTree root)
        {
            if (root == null)
            {
                return null;
            }
            BinaryTree previousNode = null;
            BinaryTree swapNodeA = null;
            BinaryTree swapNodeB = null;
            Stack<BinaryTree> stk = new Stack<BinaryTree>();
            var head = root;
            while (head != null)
            {
                stk.Push(head);
                head = head.Left;
            }
            while (stk.Count > 0)
            {
                var node = stk.Pop();
                if (previousNode != null && previousNode.Value > node.Value)
                {
                    if (swapNodeA == null)
                    {
                        swapNodeA = previousNode;
                    }
                    swapNodeB = node;
                }
                previousNode = node;
                var right = node.Right;
                while (right != null)
                {
                    stk.Push(right);
                    right = right.Left;
                }
            }
            int temp = swapNodeA.Value;
            swapNodeA.Value = swapNodeB.Value;
            swapNodeB.Value = temp;
            return root;
        }

        [Fact]
        public void Q099_RecoverBinarySearchTree()
        {
            TestHelper.Run(input => RecoverTree(input[0].ToBinaryTree()).SerializeBinaryTree());
        }
    }
}
