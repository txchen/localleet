using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Sort a linked list in O(n log n) time using constant space complexity.

// https://leetcode.com/problems/sort-list/
namespace LocalLeet
{
    public class Q148
    {
        public ListNode<int> SortList(ListNode<int> head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            ListNode<int> preA = new ListNode<int>(0);
            preA.Next = head;
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.Next;
            }

            for (int step = 1; step < length; step <<= 1)
            {
                head = preA.Next;
                var pre = preA;
                while (head != null)
                {
                    var la = Split(ref head, step);
                    var lb = Split(ref head, step);
                    var t = Merge(la, lb, head);
                    pre.Next = t.Item1;
                    pre = t.Item2;
                }
            }
            return preA.Next;
        }

        private ListNode<int> Split(ref ListNode<int> head, int step)
        {
            if (head == null)
            {
                return head;
            }
            ListNode<int> result = head;
            while (step > 1 && head.Next != null)
            {
                head = head.Next;
                step--;
            }
            var temp = head.Next;
            head.Next = null;
            head = temp;
            return result;
        }

        private Tuple<ListNode<int>, ListNode<int>> Merge(ListNode<int> a, ListNode<int> b, ListNode<int> tail)
        {
            ListNode<int> preA = new ListNode<int>(0);
            var cur = preA;
            while (a != null && b != null)
            {
                if (a.Val < b.Val)
                {
                    cur.Next = a;
                    cur = a;
                    a = a.Next;
                }
                else
                {
                    cur.Next = b;
                    cur = b;
                    b = b.Next;
                }
            }
            var remaining = a != null ? a : b;
            while (remaining != null)
            {
                cur.Next = remaining;
                cur = remaining;
                remaining = remaining.Next;
            }
            cur.Next = tail;
            return Tuple.Create(preA.Next, cur);
        }

        [Fact]
        public void Q148_SortList()
        {
            TestHelper.Run(input =>
                SortList(input.EntireInput.ToListNode2<int>()).SerializeListNode2());
        }
    }
}
