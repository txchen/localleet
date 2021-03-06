using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Follow up for problem "Populating Next Right Pointers in Each Node".

// What if the given tree could be any binary tree? Would your previous solution still work?

// Note:

// You may only use constant extra space.
// For example,
// Given the following binary tree,

//          1
//        /  \
//       2    3
//      / \    \
//     4   5    7
// After calling your function, the tree should look like:

//          1 -> NULL
//        /  \
//       2 -> 3 -> NULL
//      / \    \
//     4-> 5 -> 7 -> NULL

// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
namespace LocalLeet
{
    public class Q117
    {
        public TreeNodeWithNext Connect(BinaryTree input)
        {
            Q116 q = new Q116();
            return q.Connect(input);
        }

        [Fact]
        public void Q117_PopulatingNextRightPointersinEachNodeII()
        {
            TestHelper.Run(input => Connect(input[0].ToBinaryTree()).SerializeTreeNodeWithNext());
        }
    }
}
