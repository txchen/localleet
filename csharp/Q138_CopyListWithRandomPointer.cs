using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
//
// Return a deep copy of the list.

// Definition for RandomListNode
// public class RandomListNode
// {
//     public int Val;
//     public RandomListNode Next;
//     public RandomListNode Random;
//
//     public RandomListNode(int x)
//     {
//         Val = x;
//     }
// }

// https://leetcode.com/problems/copy-list-with-random-pointer/
namespace LocalLeet
{
    public class Q138
    {
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var temp = head;
            while (temp != null)
            {
                RandomListNode n = new RandomListNode(temp.Val);
                n.Next = temp.Next;
                temp.Next = n;
                temp = n.Next;
            }
            temp = head;
            while (temp != null)
            {
                if (temp.Random != null)
                {
                    temp.Next.Random = temp.Random.Next;
                }
                temp = temp.Next.Next;
            }
            temp = head;
            var answer = head.Next;
            while (temp.Next != null)
            {
                var n = temp.Next;
                temp.Next = n.Next;
                temp = n;
            }
            return answer;
        }

        [Fact]
        public void Q138_CopyListWithRandomPointer()
        {
            TestHelper.Run(input => {
                var inputNode = input.EntireInput.ToRandomListNode();
                var outputNode = CopyRandomList(inputNode);
                if (inputNode != null && object.Equals(inputNode, outputNode))
                {
                    return "Must create a new instance of node!";
                }
                return outputNode.SerializeRandomListNode();
            });
        }
    }
}
