using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Given a linked list, swap every two adjacent nodes and return its head.

// For example,
// Given 1->2->3->4, you should return the list as 2->1->4->3.

// Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

namespace LocalLeet
{
    
    public class Q024_SwapNodesinPairs
    {
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            ListNode<int> preAnswer = new ListNode<int>(0);
            preAnswer.Next = head;
            var left = preAnswer;
            while (left.Next != null && left.Next.Next != null)
            {
                var right = left.Next.Next;
                left.Next.Next = right.Next;
                right.Next = left.Next;
                left.Next = right;
                left = right.Next;
            }
            return preAnswer.Next;
        }

        public string SolveQuestion(string input)
        {
            return SwapPairs(input.ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q024_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q024_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
