using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalLeet
{
    public class BinaryTree
    {
        public int Value;
        public BinaryTree Left;
        public BinaryTree Right;

        public BinaryTree(int value)
        {
            Value = value;
        }
    }

    public class TreeNodeWithNext
    {
        public int Value;
        public TreeNodeWithNext Left;
        public TreeNodeWithNext Right;
        public TreeNodeWithNext Next;

        public TreeNodeWithNext(int value)
        {
            Value = value;
        }
    }
}
