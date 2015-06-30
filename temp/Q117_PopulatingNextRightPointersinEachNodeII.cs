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

namespace LocalLeet
{
    public class Q117
    {
        public TreeNodeWithNext Connect(BinaryTree input)
        {
            Q116_PopulatingNextRightPointersinEachNode q = new Q116_PopulatingNextRightPointersinEachNode();
            return q.Connect(input);
        }

        public string SolveQuestion(string input)
        {
            return Connect(input[0].ToBinaryTree()).SerializeTreeNodeWithNext();
        }

        [Fact]
        public void Q117_PopulatingNextRightPointersinEachNodeII()
        {
            TestHelper.Run(input => SolveQuestion(s));
        }
    }
}
