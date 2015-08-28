using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// Write a program to find the node at which the intersection of two singly linked lists begins.
//
// For example, the following two linked lists:
//
// A:          a1 → a2
//                    ↘
//                      c1 → c2 → c3
//                    ↗
// B:     b1 → b2 → b3
// begin to intersect at node c1.
//
// Notes:
//
// If the two linked lists have no intersection at all, return null.
// The linked lists must retain their original structure after the function returns.
// You may assume there are no cycles anywhere in the entire linked structure.
// Your code should preferably run in O(n) time and use only O(1) memory.

// https://leetcode.com/problems/intersection-of-two-linked-lists/
namespace LocalLeet
{
    public class Q160
    {
        public ListNode<int> GetIntersectionNode(ListNode<int> headA, ListNode<int> headB)
        {
            int lenA = GetLength(headA);
            int lenB = GetLength(headB);
            while (lenB > lenA)
            {
                headB = headB.Next;
                lenB--;
            }
            while (lenA > lenB)
            {
                headA = headA.Next;
                lenA--;
            }
            while (headA != null)
            {
                if (headA.Val == headB.Val)
                {
                    return headA;
                }
                headA = headA.Next;
                headB = headB.Next;
            }
            return null;
        }

        private int GetLength(ListNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }
            int answer = 0;
            while (node != null)
            {
                answer++;
                node = node.Next;
            }
            return answer;
        }

        [Fact]
        public void Q160_IntersectionOfTwoLinkedLists()
        {
            // {"input":"No intersection: [1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33], [2,4,6]","expected":"No intersection"},
            // {"input":"Intersected at '1': [1], [1]","expected":"Intersected at '1'"},
            // {"input":"Intersected at '1': [1,2,3,4,5,6,7,8,9,10,11,12,13], [1,2,3,4,5,6,7,8,9,10,11,12,13]","expected":"Intersected at '1'"},
            TestHelper.Run(input => {
                var listStrs = input.EntireInput.Substring(2 + input.EntireInput.IndexOf(": "));
                var tokens = listStrs.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                var list1 = tokens[0].ToListNode2<int>();
                var list2 = tokens[1].ToListNode2<int>();
                var output = GetIntersectionNode(list1, list2);
                return output == null ? "No intersection" : String.Format("Intersected at '{0}'", output.Val);
            });
        }
    }
}
