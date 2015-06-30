using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Merge two sorted linked lists and return it as a new list.
// The new list should be made by splicing together the nodes of the first two lists.

namespace LocalLeet
{
    public class Q021
    {
        public ListNode<int> MergeTwoLists(ListNode<int> l1, ListNode<int> l2)
        {
            ListNode<int> preAnswer = new ListNode<int>(0);
            var temp = preAnswer;
            while (l1 != null && l2 != null)
            {
                if (l1.Val < l2.Val)
                {
                    temp.Next = new ListNode<int>(l1.Val);
                    l1 = l1.Next;
                }
                else
                {
                    temp.Next = new ListNode<int>(l2.Val);
                    l2 = l2.Next;
                }
                temp = temp.Next;
            }
            if (l1 != null)
            {
                temp.Next = l1;
            }
            if (l2 != null)
            {
                temp.Next = l2;
            }
            return preAnswer.Next;
        }

        [Fact]
        public void Q021_MergeTwoSortedLists()
        {
            TestHelper.Run(input =>
                MergeTwoLists(input[0].ToListNode<int>(), input[1].ToListNode<int>()).SerializeListNode());
        }
    }
}
