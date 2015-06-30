using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree

//     struct TreeLinkNode {
//       TreeLinkNode *left;
//       TreeLinkNode *right;
//       TreeLinkNode *next;
//     }
// Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

// Initially, all next pointers are set to NULL.

// Note:

// You may only use constant extra space.
// You may assume that it is a perfect binary tree (ie, all leaves are at the same level, and every parent has two children).
// For example,
// Given the following perfect binary tree,

//          1
//        /  \
//       2    3
//      / \  / \
//     4  5  6  7
// After calling your function, the tree should look like:

//          1 -> NULL
//        /  \
//       2 -> 3 -> NULL
//      / \  / \
//     4->5->6->7 -> NULL

// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
namespace LocalLeet
{
    public class Q116
    {
        public TreeNodeWithNext Connect(BinaryTree input)
        {
            if (input == null)
            {
                return null;
            }
            // use queue and layered scan tree seems straight forward, but it says constant space
            TreeNodeWithNext root = input.ConvertToTreeNodeWithNext();
            Connect(root, null);
            // use queue's solution
            //ConnectWithQueue(root);
            return root;
        }

        private void Connect(TreeNodeWithNext node, TreeNodeWithNext parentNext)
        {
            // key point: parent Next, move right until find good candidate to connect
            while (parentNext != null && parentNext.Left == null && parentNext.Right == null)
            {
                parentNext = parentNext.Next;
            }
            // now connect
            if (parentNext != null)
            {
                if (parentNext.Left != null)
                {
                    node.Next = parentNext.Left;
                }
                else if (parentNext.Right != null)
                {
                    node.Next = parentNext.Right;
                }
            }
            // now care about children
            if (node.Left != null && node.Right != null)
            {
                node.Left.Next = node.Right;
                Connect(node.Right, node.Next); // connect right first
                Connect(node.Left, null); // still need to connect left, for its children!
            }
            else if (node.Right != null)
            {
                Connect(node.Right, node.Next);
            }
            else if (node.Left != null)
            {
                Connect(node.Left, node.Next);
            }
        }

        private void ConnectWithQueue(TreeNodeWithNext node)
        {
            Queue<TreeNodeWithNext> q = new Queue<TreeNodeWithNext>();
            q.Enqueue(node);
            q.Enqueue(null); // for each level, insert a null at the end
            TreeNodeWithNext pre = null;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (pre != null)
                {
                    pre.Next = current;
                }
                else
                {
                    if (q.Count == 0)
                    { // dequeue null and queue empty, means it is last one
                        break;
                    }
                    q.Enqueue(null); // insert null for next level
                }
                pre = current;
                if (current != null && current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current != null && current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
        }

        [Fact]
        public void Q116_PopulatingNextRightPointersinEachNode()
        {
            TestHelper.Run(input => Connect(input[0].ToBinaryTree()).SerializeTreeNodeWithNext());
        }
    }
}
