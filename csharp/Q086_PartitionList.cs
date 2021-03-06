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

// https://leetcode.com/problems/partition-list/
namespace LocalLeet
{
    public class Q086
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

        [Fact]
        public void Q086_PartitionList()
        {
            TestHelper.Run(input => Partition(input[0].ToListNode<int>(), input[1].ToInt()).SerializeListNode());
        }
    }
}
