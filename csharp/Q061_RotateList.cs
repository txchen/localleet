using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Given a list, rotate the list to the right by k places, where k is non-negative.

// For example:
// Given 1->2->3->4->5->NULL and k = 2,
// return 4->5->1->2->3->NULL.

// https://leetcode.com/problems/rotate-list/
namespace LocalLeet
{
    public class Q061
    {
        public ListNode<int> RotateRight(ListNode<int> head, int n)
        {
            if (head == null)
            {
                return head;
            }
            var end = head;
            int length = 1;
            while (end.Next != null)
            {
                end = end.Next;
                length++;
            }
            n = n % length; if (n == 0)
            {
                return head;
            }
            ListNode<int> preK = new ListNode<int>(0);
            preK.Next = head;
            end = preK;
            while (n-- > 0)
            {
                end = end.Next;
            }
            // move end to the end :)
            while (end.Next != null)
            {
                end = end.Next;
                preK = preK.Next;
            }
            var answer = preK.Next;
            end.Next = head;
            preK.Next = null;
            return answer;
        }

        [Fact]
        public void Q061_RotateList()
        {
            TestHelper.Run(input =>
            {
                return RotateRight(input[0].ToListNode<int>(),
                    input[1].ToInt()).SerializeListNode();
            });
        }
    }
}
