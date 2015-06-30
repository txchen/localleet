using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted linked list, delete all nodes that have duplicate numbers,
// leaving only distinct numbers from the original list.

// For example,
// Given 1->2->3->3->4->4->5, return 1->2->5.
// Given 1->1->1->2->3, return 2->3.

namespace LocalLeet
{
    public class Q082_RemoveDuplicatesfromSortedListII
    {
        public ListNode<int> DeleteDuplicatesII(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode<int> preA = new ListNode<int>(0);
            preA.Next = head;
            var write = preA;
            var scan = head;
            while (scan != null)
            {
                if (write.Next.Val != scan.Val)
                {
                    if (write.Next.Next == scan) // no dup
                    {
                        write = write.Next;
                    }
                    else // dup
                    {
                        write.Next = scan;
                    }
                }
                scan = scan.Next;
            }
            if (write.Next.Next != null)
            {
                write.Next = null;
            }
            return preA.Next;
        }

        public string SolveQuestion(string input)
        {
            return DeleteDuplicatesII(input[0].ToListNode<int>()).SerializeListNode();
        }

        [Fact]
        public void Q082_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [Fact]
        public void Q082_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
