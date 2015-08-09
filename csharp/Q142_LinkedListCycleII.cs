using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

// Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
//
// Follow up:
// Can you solve it without using extra space?

// https://leetcode.com/problems/linked-list-cycle-ii/
namespace LocalLeet
{
    public class Q142
    {
        public ListNode<int> DetectCycle(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }
            var slow = head;
            var fast = head;
            while (slow != null)
            {
                slow = slow.Next;
                if (fast == null || fast.Next == null || fast.Next.Next == null)
                {
                    return null;
                }
                fast = fast.Next.Next;
                if (fast == slow)
                {
                    while (slow != head)
                    {
                        slow = slow.Next;
                        head = head.Next;
                    }
                    return head;
                }
            }
            return null;
        }

        [Fact]
        public void Q142_LinkedListCycleII()
        {
            TestHelper.Run(input => {
                var head = BuildCycleListNode(input[0].Replace("[", "{").Replace("]", "}")
                    .ToListNode<int>(), input[1]);
                var result = DetectCycle(head);
                if (result == null)
                {
                    return "no cycle";
                }
                else
                {
                    int cycleIndex = 0;
                    while (head != null)
                    {
                        if (head == result)
                        {
                            return "tail connects to node index " + cycleIndex.ToString();
                        }
                        cycleIndex++;
                        head = head.Next;
                    }
                    return "returned node not in input listnode";
                }
            });
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
