using System;
using System.Collections.Generic;

namespace LocalLeet
{
    public class ListNode<T>
    {
        public T Val;
        public ListNode<T> Next;

        public ListNode(T x)
        {
            Val = x;
            Next = null;
        }
    }
}
