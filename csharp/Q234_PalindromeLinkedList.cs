using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

// Given a singly linked list, determine if it is a palindrome.

// https://leetcode.com/problems/palindrome-linked-list/
namespace LocalLeet
{
    public class Q234
    {
        public bool IsPalindrome(ListNode<int> head)
        {
            if (head == null)
            {
                return true;
            }
            int length = 0;
            var tmp = head;
            while (tmp != null)
            {
                length++;
                tmp = tmp.Next;
            }
            tmp = head;
            var stk = new Stack<int>();
            int position = 0;
            while (tmp != null)
            {
                if (position < length / 2)
                {
                    stk.Push(tmp.Val);
                }
                else if (position > (length - 1) / 2)
                {
                    if (tmp.Val != stk.Pop())
                    {
                        return false;
                    }
                }
                tmp = tmp.Next;
                position++;
            }
            return true;
        }

        [Fact]
        public void Q234_PalindromeLinkedList()
        {
            TestHelper.Run(input => IsPalindrome(input.EntireInput.ToListNode2<int>()).ToString().ToLower());
        }
    }
}
