using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// You are given two linked lists representing two non-negative numbers.
// The digits are stored in reverse order and each of their nodes contain a single digit.
// Add the two numbers and return it as a linked list.

// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
// Output: 7 -> 0 -> 8

namespace LocalLeet
{
    public class Q002
    {
        public ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            var result = new ListNode<int>(0);
            var tmp = result;
            int carry = 0;
            while (carry > 0 || l1 != null || l2 != null)
            {
                int newValue = carry + (l1 == null ? 0 : l1.Val) + (l2 == null ? 0 : l2.Val);
                carry = newValue / 10;
                tmp.Next = new ListNode<int>(newValue % 10);
                tmp = tmp.Next;
                l1 = l1 == null ? null : l1.Next;
                l2 = l2 == null ? null : l2.Next;
            }
            return result.Next;
        }

        [Fact]
        public void Q002_AddTwoNumbers()
        {
            TestHelper.Run(input =>
                AddTwoNumbers(input[0].ToListNode<int>(), input[1].ToListNode<int>()).SerializeListNode());
        }
    }
}
