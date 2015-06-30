using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

namespace LocalLeet
{
    public class Q023
    {
        public ListNode<int> MergeKLists(ListNode<int>[] lists)
        {
            var preAnswer = new ListNode<int>(0);
            var temp = preAnswer;
            // use a min head, to get min value everytime.rt
            MinHeap<ListNode<int>> mh = new MinHeap<ListNode<int>>(new ListNodeComparer());
            foreach (var list in lists)
            {
                if (list != null)
                {
                    mh.Add(list);
                }
            }
            while (mh.Count > 0)
            {
                temp.Next = mh.ExtractDominating();
                temp = temp.Next;
                if (temp.Next != null)
                {
                    mh.Add(temp.Next);
                }
            }
            return preAnswer.Next;
        }

        class ListNodeComparer : Comparer<ListNode<int>>
        {
            public override int Compare(ListNode<int> x, ListNode<int> y)
            {
                return x.Val.CompareTo(y.Val);
            }
        }

        [Fact]
        public void Q023_MergekSortedLists()
        {
            TestHelper.Run(input =>
                MergeKLists(input[0].ToListNodeArray<int>()).SerializeListNode());
        }
    }
}
