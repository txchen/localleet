using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Sort a linked list using insertion sort.

// https://leetcode.com/problems/insertion-sort-list/
namespace LocalLeet
{
    public class Q147
    {
        public ListNode<int> InsertionSortList(ListNode<int> head)
        {
            var preA = new ListNode<int>(0);
            while (head != null)
            {
                var pre = preA;
                while (pre.Next != null && pre.Next.Val < head.Val)
                {
                    pre = pre.Next;
                }
                var headNext = head.Next;
                var preNext = pre.Next;
                head.Next = preNext;
                pre.Next = head;
                head = headNext;
            }
            return preA.Next;
        }

        [Fact]
        public void Q147_InsertionSortList()
        {
            TestHelper.Run(input =>
                InsertionSortList(input.EntireInput.ToListNode2<int>()).SerializeListNode2());
        }
    }
}
