using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a linked list, swap every two adjacent nodes and return its head.

// For example,
// Given 1->2->3->4, you should return the list as 2->1->4->3.

// Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

// https://leetcode.com/problems/swap-nodes-in-pairs/
namespace LocalLeet
{
    public class Q024
    {
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            ListNode<int> preAnswer = new ListNode<int>(0);
            preAnswer.Next = head;
            var left = preAnswer;
            while (left.Next != null && left.Next.Next != null)
            {
                var right = left.Next.Next;
                left.Next.Next = right.Next;
                right.Next = left.Next;
                left.Next = right;
                left = right.Next;
            }
            return preAnswer.Next;
        }

        [Fact]
        public void Q024_SwapNodesinPairs()
        {
            TestHelper.Run(input =>
                SwapPairs(input[0].ToListNode<int>()).SerializeListNode());
        }
    }
}
