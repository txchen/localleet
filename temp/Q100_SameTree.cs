using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given two binary trees, write a function to check if they are equal or not.

// Two binary trees are considered equal if they are structurally identical and the nodes have the same value.

namespace LocalLeet
{
    public class Q100_SameTree
    {
        public bool IsSameTree(BinaryTree t1, BinaryTree t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }
            if (t1 == null || t2 == null)
            {
                return false;
            }
            if (t1.Value != t2.Value)
            {
                return false;
            }
            return IsSameTree(t1.Left, t2.Left) && IsSameTree(t1.Right, t2.Right);
        }

        public string SolveQuestion(string input)
        {
            return IsSameTree(input[0].ToBinaryTree(), input[1].ToBinaryTree()).ToString()
                .ToLower();
        }

        [Fact]
        public void Q100_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q100_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
