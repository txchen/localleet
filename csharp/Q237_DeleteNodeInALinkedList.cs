using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
//
// Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.

// https://leetcode.com/problems/delete-node-in-a-linked-list/
namespace LocalLeet
{
    public class Q237
    {
        public void DeleteNode(ListNode<int> node)
        {
            var next = node.Next;
            while (next != null)
            {
                node.Val = next.Val;
                if (next.Next != null)
                {
                    node = next;
                    next = node.Next;
                }
                else
                {
                    break;
                }
            }
            node.Next = null;
        }

        [Fact]
        public void Q237_DeleteNodeInALinkedList()
        {
            // "input":"[0,1,2,3,4,5,6,7,8,9], node at index 0 (node.val = 0)","expected":"[1,2,3,4,5,6,7,8,9]"
            TestHelper.Run(input => {
                var listNode = input[0].ToListNode2<int>();
                var indexExp = input[1].Replace("node at index ", "");
                indexExp = indexExp.Substring(0, indexExp.IndexOf(" "));
                int index = int.Parse(indexExp);
                var nodeToDelete = listNode;
                while (index > 0)
                {
                    nodeToDelete = nodeToDelete.Next;
                    index--;
                }
                DeleteNode(nodeToDelete);
                return listNode.SerializeListNode2();
            });
        }
    }
}
