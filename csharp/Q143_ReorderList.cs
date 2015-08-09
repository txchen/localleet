using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

// Given a singly linked list L: L0→L1→...→Ln-1→Ln,
// reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→...
//
// You must do this in-place without altering the nodes' values.
//
// For example,
// Given {1,2,3,4}, reorder it to {1,4,2,3}.

// https://leetcode.com/problems/reorder-list/
namespace LocalLeet
{
    public class Q143
    {
        public void ReorderList(ListNode<int> head)
        {
            if (head == null || head.Next == null || head.Next.Next == null)
            {
                return;
            }
            var mid = head;
            var fast = head.Next;
            while (fast != null && fast.Next != null)
            {
                mid = mid.Next;
                fast = fast.Next.Next;
            }
            // now reverse the node after mid
            var temp = mid.Next;
            while (temp.Next != null)
            {
                var mn = mid.Next;
                mid.Next = temp.Next;
                temp.Next = temp.Next.Next;
                mid.Next.Next = mn;
            }
            // now combine
            while (mid.Next != null && mid != head)
            {
                var mn = mid.Next;
                mid.Next = mn.Next;
                var hn = head.Next;
                head.Next = mn;
                mn.Next = hn;
                head = hn;
            }
        }

        [Fact]
        public void Q143_ReorderList()
        {
            TestHelper.Run(input => {
                var head = input[0].Replace("[", "{").Replace("]", "}").ToListNode<int>();
                ReorderList(head);
                return head.SerializeListNode().Replace("{", "[").Replace("}", "]");
            });
        }
    }
}
