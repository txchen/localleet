using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
// If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
// You may not alter the values in the nodes, only nodes itself may be changed.

// Only constant memory is allowed.

// For example,
// Given this linked list: 1->2->3->4->5
// For k = 2, you should return: 2->1->4->3->5
// For k = 3, you should return: 3->2->1->4->5

namespace LocalLeet
{
    public class Q025
    {
        public ListNode<int> ReverseKGroup(ListNode<int> head, int k)
        {
            ListNode<int> preAnswer = new ListNode<int>(0);
            var pre = preAnswer;
            pre.Next = head;
            var start = head;
            var end = start;
            while (true)
            {
                for (int i = 0; i < k - 1 && end != null; i++)
                {
                    end = end.Next;
                }
                if (end == null)
                {
                    break;
                }
                var nextStart = end.Next;
                // 4 pointer here, pre -> start -> -> -> -> end -> nextStart
                while (start.Next != nextStart)
                {
                    // reverse in k group
                    var temp = pre.Next;
                    pre.Next = start.Next;
                    start.Next = start.Next.Next;
                    pre.Next.Next = temp;
                }
                // next round
                pre = start;
                start = pre.Next;
                end = start;
            }
            return preAnswer.Next;
        }

        [Fact]
        public void Q025_ReverseNodesinKGroup()
        {
            TestHelper.Run(input =>
                ReverseKGroup(input[0].ToListNode<int>(), input[1].ToInt()).SerializeListNode());
        }
    }
}
