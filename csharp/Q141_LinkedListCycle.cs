using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

// Given a linked list, determine if it has a cycle in it.
//
// Follow up:
// Can you solve it without using extra space?

// https://leetcode.com/problems/linked-list-cycle/
namespace LocalLeet
{
    public class Q141
    {
        public bool HasCycle(ListNode<int> head)
        {
            if (head == null)
            {
                return false;
            }
            var fast = head.Next;
            while (head != null)
            {
                if (fast == head)
                {
                    return true;
                }
                head = head.Next;
                if (fast == null || fast.Next == null || fast.Next.Next == null)
                {
                    return false;
                }
                fast = fast.Next.Next;
            }
            return false;
        }

        [Fact]
        public void Q141_LinkedListCycle()
        {
            TestHelper.Run(input =>
                HasCycle(BuildCycleListNode(input[0].Replace("[", "{").Replace("]", "}").ToListNode<int>(), input[1]))
                    .ToString().ToLower());
        }

        private Regex r = new Regex("tail connects to node index (\\d+)");
        private ListNode<int> BuildCycleListNode(ListNode<int> n, string cycleDesc)
        {
            Match m = r.Match(cycleDesc);
            if (m.Success)
            {
                int cycleIndex = int.Parse(m.Groups[1].ToString());
                var tail = n;
                while (tail.Next != null)
                {
                    tail = tail.Next;
                }
                var cycle = n;
                while (cycleIndex > 0)
                {
                    cycle = cycle.Next;
                    cycleIndex--;
                }
                tail.Next = cycle;
            }
            return n;
        }
    }
}
