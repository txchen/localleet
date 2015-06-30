using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a sorted linked list, delete all duplicates such that each element appear only once.

// For example,
// Given 1->1->2, return 1->2.
// Given 1->1->2->3->3, return 1->2->3.

namespace LocalLeet
{
    public class Q083_RemoveDuplicatesfromSortedList
    {
        public ListNode<int> DeleteDuplicates(ListNode<int> head)
        {
            ListNode<int> preA = new ListNode<int>(0);
            preA.Next = head;
            var start = head;
            var scan = head;
            while (scan != null)
            {
                if (scan.Val != start.Val)
                {
                    start = start.Next;
                    start.Val = scan.Val;
                }
                scan = scan.Next;
            }
            if (start != null)
            {
                start.Next = null;
            }
            return preA.Next;
        }

        public string SolveQuestion(string input)
        {
            return DeleteDuplicates(input[0].ToListNode<int>()).SerializeListNode();
        }

        [Fact]
        public void Q083_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
