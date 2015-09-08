using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
//
// Calling next() will return the next smallest number in the BST.
//
// Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.

// https://leetcode.com/problems/binary-search-tree-iterator/
namespace LocalLeet
{
    public class Q173
    {
        // implement this class
        public class BSTIterator
        {
            private Stack<BinaryTree> stk = new Stack<BinaryTree>();

            public BSTIterator(BinaryTree root)
            {
                while (root != null)
                {
                    stk.Push(root);
                    root = root.Left;
                }
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return stk.Count > 0;
            }

            /** @return the next smallest number */
            public int Next()
            {
                var n = stk.Pop();
                int r = n.Value;
                n = n.Right;
                while (n != null)
                {
                    stk.Push(n);
                    n = n.Left;
                }
                return r;
            }
        }

        [Fact]
        public void Q173_BinarySearchTreeIterator()
        {
            // {"input":"[5,3,6,2,4,null,null,1]","expected":"[1,2,3,4,5,6]"},
            TestHelper.Run(input => {
                var tree = input.EntireInput.ToBinaryTree2();
                BSTIterator iter = new BSTIterator(tree);
                var output = new List<int>();
                while (iter.HasNext())
                {
                    output.Add(iter.Next());
                }
                return TestHelper.Serialize<int[]>(output.ToArray());
            });
        }
    }
}
