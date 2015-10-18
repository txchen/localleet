using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Reverse a singly linked list.

// https://leetcode.com/problems/reverse-linked-list/
namespace LocalLeet
{
    public class Q206
    {
        public ListNode<int> ReverseList(ListNode<int> head)
        {
            var preA = new ListNode<int>(0);
            preA.Next = head;
            while (head != null && head.Next != null)
            {
                var hn = head.Next;
                head.Next = hn.Next;
                var pn = preA.Next;
                preA.Next = hn;
                hn.Next = pn;
            }
            return preA.Next;
        }

        [Fact]
        public void Q206_ReverseLinkedList()
        {
            TestHelper.Run(input => ReverseList(input.EntireInput.ToListNode2<int>()).SerializeListNode2());
        }
    }
}
