using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a linked list and a value x,
// partition it such that all nodes less than x come before nodes greater than or equal to x.

// You should preserve the original relative order of the nodes in each of the two partitions.

// For example,
// Given 1->4->3->2->5->2 and x = 3,
// return 1->2->2->4->3->5.

namespace LocalLeet
{
    public class Q086_PartitionList
    {
        public ListNode<int> Partition(ListNode<int> head, int x)
        {
            ListNode<int> preA = new ListNode<int>(0);
            preA.Next = head;
            var write = preA;
            var scan = preA;
            while (scan != null && scan.Next != null)
            {
                if (scan.Next.Val < x) // then swap write.Next and scan.Next
                {
                    if (write != scan)
                    {
                        var wn = write.Next;
                        var snn = scan.Next.Next;
                        write.Next = scan.Next;
                        write.Next.Next = wn;
                        scan.Next = snn;
                        write = write.Next; // hard to write right
                        continue;
                    }
                    write = write.Next;
                }
                scan = scan.Next;
            }
            return preA.Next;
        }

        public string SolveQuestion(string input)
        {
            return Partition(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [Fact]
        public void Q086_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q086_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
