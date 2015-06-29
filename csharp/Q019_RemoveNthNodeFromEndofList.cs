using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a linked list, remove the nth node from the end of list and return its head.
// For example,
//   Given linked list: 1->2->3->4->5, and n = 2.
//   After removing the second node from the end, the linked list becomes 1->2->3->5.
//
// Note:
// Given n will always be valid.
// Try to do this in one pass.

namespace LocalLeet
{
    public class Q019_RemoveNthNodeFromEndofList
    {
        public ListNode<int> RemoveNthFromEnd(ListNode<int> head, int n)
        {
            var left = head;
            var right = head;
            while (n-- > 0)
            {
                right = right.Next;
            }
            if (right == null)
            {
                return head.Next;
            }
            while (right.Next != null)
            {
                left = left.Next;
                right = right.Next;
            }
            left.Next = left.Next.Next;
            return head;
        }

        public string SolveQuestion(string input)
        {
            return RemoveNthFromEnd(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [Fact]
        public void Q019_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q019_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
