using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a binary tree, flatten it to a linked list in-place.

// For example,
// Given

//          1
//         / \
//        2   5
//       / \   \
//      3   4   6
// The flattened tree should look like:
//    1
//     \
//      2
//       \
//        3
//         \
//          4
//           \
//            5
//             \
//              6

namespace LocalLeet
{
    public class Q114
    {
        public BinaryTree Flatten(BinaryTree root)
        {
            if (root == null)
            {
                return null;
            }
            var right = root.Right;
            var flattenedLeft = Flatten(root.Left);
            root.Left = null;
            root.Right = flattenedLeft;
            var tmp = root;
            while (tmp.Right != null)
            {
                tmp = tmp.Right;
            }
            tmp.Right = Flatten(right);
            return root;
        }

        [Fact]
        public void Q114_FlattenBinaryTreetoLinkedList()
        {
            TestHelper.Run(input => Flatten(input[0].ToBinaryTree()).SerializeBinaryTree());
        }
    }
}
