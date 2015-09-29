using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Remove all elements from a linked list of integers that have value val.
//
// Example
// Given: 1 --> 2 --> 6 --> 3 --> 4 --> 5 --> 6, val = 6
// Return: 1 --> 2 --> 3 --> 4 --> 5

// https://leetcode.com/problems/remove-linked-list-elements/
namespace LocalLeet
{
    public class Q203
    {
        public ListNode<int> RemoveElements(ListNode<int> head, int val)
        {
            ListNode<int> preA = new ListNode<int>(0);
            preA.Next = head;
            var cur = preA;
            while (cur.Next != null)
            {
                if (cur.Next.Val == val)
                {
                    cur.Next = cur.Next.Next;
                }
                else
                {
                    cur = cur.Next;
                }
            }
            return preA.Next;
        }

        [Fact]
        public void Q203_RemoveLinkedListElements()
        {
            TestHelper.Run(input => RemoveElements(input[0].ToListNode2<int>(), input[1].ToInt()).SerializeListNode2());
        }
    }
}
